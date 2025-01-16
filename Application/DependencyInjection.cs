namespace Application;

public static class DependencyInjection
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddSingleton<IEventService, EventService>();
        services.AddScoped<IStatisticService, StatisticService>();
        services.AddScoped<IHardwareService, HardwareService>();
        
        services.AddMediatR(x =>
        {
            x.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
            x.AddOpenBehavior(typeof(ValidationBehavior<,>));
            x.AddOpenBehavior(typeof(LoggingBehavior<,>));
        }); 
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddExceptionHandler<CustomExceptionHandler>();
    }
}