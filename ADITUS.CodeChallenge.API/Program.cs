using System.Reflection;
using System.Text.Json.Serialization;
using ADITUS.CodeChallenge.API.Configuration;
using Application;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApplicationServices();

builder.Services.Configure<StatisticServiceConfiguration>(builder.Configuration.GetSection(ServiceNameConfiguration.ServiceConfigurationName));
builder.Services.AddControllers().AddJsonOptions(x =>
{
    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddHttpClient("StatisticService", (serviceProvider, httpClient) =>
{
    var config = serviceProvider.GetRequiredService<IOptions<StatisticServiceConfiguration>>().Value;
    httpClient.BaseAddress = new Uri(config.Url);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
