﻿using Microsoft.EntityFrameworkCore;
using ShopEase.Backend.Common.Messaging.Abstractions;
using ShopEase.Backend.Common.Messaging.Outbox;
using ShopEase.Backend.PassportService.Persistence;

namespace ShopEase.Backend.PassportService.Infrastructure.Idempotence
{
    /// <summary>
    /// Decorator of DomainEventHandler
    /// To Implement Idempotence Consumption
    /// </summary>
    /// <typeparam name="TDomainEvent"></typeparam>
    public sealed class IdempotentDomainEventHandler<TDomainEvent> : IDomainEventHandler<TDomainEvent>
        where TDomainEvent : IDomainEvent
    {
        private readonly IDomainEventHandler<TDomainEvent> _decoratedHandler;

        private readonly AppDbContext _appDbContext;

        public IdempotentDomainEventHandler(IDomainEventHandler<TDomainEvent> decoratedHandler, AppDbContext appDbContext)
        {
            _decoratedHandler = decoratedHandler;
            _appDbContext = appDbContext;
        }

        public async Task Handle(TDomainEvent domainEvent, CancellationToken cancellationToken)
        {
            var consumer = _decoratedHandler.GetType().Name;

            var isEventConsumed = await _appDbContext.Set<OutboxMessageConsumer>()
                                            .AnyAsync(
                                                obmCon =>
                                                    obmCon.Id == domainEvent.Id &&
                                                    obmCon.Name == consumer,
                                                cancellationToken);
            if (isEventConsumed) 
            { 
                return; 
            }

            await _decoratedHandler.Handle(domainEvent, cancellationToken);

            _appDbContext.Set<OutboxMessageConsumer>()
                    .Add(new()
                    {
                        Id = domainEvent.Id,
                        Name = consumer
                    });

            await _appDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
