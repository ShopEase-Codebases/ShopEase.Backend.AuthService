using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Polly;
using Polly.Retry;
using Quartz;
using ShopEase.Backend.Common.Messaging.Abstractions;
using ShopEase.Backend.Common.Messaging.Outbox;
using ShopEase.Backend.PassportService.Persistence;

namespace ShopEase.Backend.PassportService.Infrastructure.BackgroundJobs
{
    [DisallowConcurrentExecution]
    public class PublishDomainEventJob : IJob
    {
        private readonly AppDbContext _appDbContext;

        private readonly IEventPublisher _eventPublisher;

        public PublishDomainEventJob(AppDbContext appDbContext, IEventPublisher eventPublisher)
        {
            _appDbContext = appDbContext;
            _eventPublisher = eventPublisher;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            List<OutboxMessage> outboxMessages = await _appDbContext
                                                            .Set<OutboxMessage>()
                                                            .Where(obm => obm.ProcessedOnUtc == null)
                                                            .Take(10)
                                                            .ToListAsync(context.CancellationToken);

            foreach (OutboxMessage outboxMessage in outboxMessages)
            {
                IDomainEvent? domainEvent = JsonConvert.DeserializeObject<IDomainEvent>(
                                                                    outboxMessage.Content,
                                                                    new JsonSerializerSettings
                                                                    {
                                                                        TypeNameHandling = TypeNameHandling.All
                                                                    });

                if (domainEvent is null)
                {
                    //log
                    continue;
                }

                AsyncRetryPolicy retryPolicy = Policy
                                            .Handle<Exception>()
                                            .WaitAndRetryAsync(
                                                3, 
                                                attempt => TimeSpan
                                                            .FromMilliseconds(100 * attempt));

                PolicyResult policyResult = await retryPolicy
                                                    .ExecuteAndCaptureAsync(() => 
                                                        _eventPublisher
                                                            .Publish(domainEvent, context.CancellationToken));

                if (policyResult.FinalException is not null)
                {
                    // log
                    outboxMessage.Error = policyResult.FinalException.ToString();
                }

                outboxMessage.ProcessedOnUtc = DateTime.UtcNow;
            }

            await _appDbContext.SaveChangesAsync();
        }
    }
}
