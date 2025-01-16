namespace ADITUS.CodeChallenge.API;

public static class DependencyInjection
{
    public static IServiceCollection AddApiService(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<StatisticServiceConfiguration>(configuration.GetSection(ServiceNameConfiguration.ServiceConfigurationName));
        services.AddControllers().AddJsonOptions(x =>
        {
            x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });
        services.AddSwaggerGen();
        services.AddHttpClient("StatisticService", (serviceProvider, httpClient) =>
        {
            var config = serviceProvider.GetRequiredService<IOptions<StatisticServiceConfiguration>>().Value;
            httpClient.BaseAddress = new Uri(config.Url);
        });
        return services;
    }
    
    public static WebApplication UseApiService(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.UseExceptionHandler(x => {});

        return app;
    }
}