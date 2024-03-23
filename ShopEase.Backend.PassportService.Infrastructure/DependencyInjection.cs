﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Scrutor;
using ShopEase.Backend.Common.Messaging.Abstractions;
using ShopEase.Backend.PassportService.Application;
using ShopEase.Backend.PassportService.Infrastructure.Helpers;
using ShopEase.Backend.PassportService.Infrastructure.Idempotence;

namespace ShopEase.Backend.PassportService.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHelpers(configuration);
            services.AddBackgroundJobs(configuration);
            services.AddDomainEventHandlerWithDecorator();

            return services;
        }

        private static IServiceCollection AddHelpers(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AppSettings>(configuration.GetSection("AppSettings"));
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

            return services;
        }

        private static IServiceCollection AddBackgroundJobs(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddQuartz(configure =>
            {
                //var publishDomainEventJobKey = new JobKey(nameof(PublishDomainEventJob));

                //configure
                //    .AddJob<PublishDomainEventJob>(publishDomainEventJobKey)
                //    .AddTrigger(trigger =>
                //                    trigger
                //                        .ForJob(publishDomainEventJobKey)
                //                            .WithSimpleSchedule(schedule =>
                //                                schedule.WithIntervalInSeconds(60)
                //                                .RepeatForever()));

                List<BackgroundJobConfig>? backgroundJobs = configuration.GetSection("BackgroundJobs").Get<List<BackgroundJobConfig>>();

                if (backgroundJobs is not null && backgroundJobs.Count != 0)
                {
                    foreach (var backgroundJob in backgroundJobs)
                    {
                        if (backgroundJob.Enabled)
                        {
                            Type? jobType = AssemblyReference.Assembly.GetType($"ShopEase.Backend.PassportService.Infrastructure.BackgroundJobs.{backgroundJob.Name}");

                            if (jobType is not null)
                            {
                                var jobKey = new JobKey(backgroundJob.Name);

                                configure.AddJob(jobType, jobKey);
                                configure.AddTrigger(trigger =>
                                                        trigger
                                                            .ForJob(jobKey)
                                                            .WithCronSchedule(backgroundJob.Schedule));
                            }
                        }
                    }
                }

            });

            services.AddQuartzHostedService();

            return services;
        }

        private static IServiceCollection AddDomainEventHandlerWithDecorator(this IServiceCollection services)
        {
            services.Scan(
                selector => selector
                    .FromAssemblies(
                        Application.AssemblyReference.Assembly       
                    )
                    .AddClasses(classes => 
                        classes.Where(t => 
                            t.IsClass && 
                            !t.IsAbstract && 
                            t.GetInterfaces()
                                .Any(i => 
                                    i.IsGenericType && 
                                    i.GetGenericTypeDefinition() == typeof(IDomainEventHandler<>))))
                    .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());

            services.Decorate(typeof(IDomainEventHandler<>), typeof(IdempotentDomainEventHandler<>));

            return services;
        }
    }
}
