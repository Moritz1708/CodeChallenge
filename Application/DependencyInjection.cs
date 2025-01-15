using System.Reflection;
using Application.Behaviors;
using Application.Services.Events;
using Application.Services.Statistic;
using Infrastructure.Services.Events;
using Infrastructure.Services.Statistic;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddSingleton<IEventService, EventService>();
        services.AddScoped<IStatisticService, StatisticService>();
        
        services.AddMediatR(x =>
        {
            x.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
            x.AddOpenBehavior(typeof(ValidationBehavior<,>));
            x.AddOpenBehavior(typeof(LoggingBehavior<,>));
        });
        
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
    }
}