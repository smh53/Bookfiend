using Bookfiend.Application.BackgroundServices;
using Bookfiend.Application.Behaviors;
using Bookfiend.Application.Hubs;
using Bookfiend.Application.MessageBroker;
using FluentValidation;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bookfiend.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());
        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddScoped(
            typeof(IPipelineBehavior<,>),
            typeof(ValidationBehavior<,>));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddSingleton(sp => new ConnectionFactory() { Uri = new Uri(configuration.GetConnectionString("RabbitMqConnection")), DispatchConsumersAsync = true });
        services.AddSingleton<RabbitMqClientService>();
        services.AddSingleton<IRabbitMqPublisher,RabbitMqPublisher>();
        services.AddSingleton<IUserIdProvider, CustomSignalRUserIdProvider>();
       

        services.AddHostedService<AuthorBackgroundService>();
        
        return services;
    }

   
}
