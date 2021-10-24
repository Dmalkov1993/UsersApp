using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace UsersApp.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDefaultMassTransit(this IServiceCollection services, string host, string username, string password)
        {
            services.AddMassTransit(configurator => // Настройка кролика
            {
                configurator.UsingRabbitMq((context, factoryConfigurator) =>
                {
                    factoryConfigurator.Host(new Uri(host),
                        hostConfigurator =>
                        {
                            hostConfigurator.Username(username);
                            hostConfigurator.Password(password);
                        });
                    factoryConfigurator.ConfigureEndpoints(context);
                });
            });
            services.AddMassTransitHostedService();
        }
    }
}
