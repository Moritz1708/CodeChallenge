var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApiService(builder.Configuration)
    .AddApplicationServices();

var app = builder.Build();

app.UseApiService();
app.Run();
