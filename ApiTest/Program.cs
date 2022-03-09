using Application;
using ExchangeApiClient;
using Hangfire;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Test API",
        Description = "Test API for showcasing several patterns and approaches to coding in general",
        Version = "v1"
    });
});

builder.Services.AddInfrastructure();
builder.Services.AddApplicationServices();
builder.Services.UseHangfire();
builder.Services.AddExchangeApiClient();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseHangfireDashboard();

await Task.Run(() => ApplicationStartup.StartRecurringHangfireTasks());

app.Run();
