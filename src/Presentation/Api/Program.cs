using Api.Extensions;
using Api.Middlewares;
using Application.Extensions;
using Application.RabbitMq;
using Application.Redis;
using Domain.Extensions.ConfigurationExtensions;
using Infrastructure.Configuration.RedisConfiguration;
using Infrastructure.Extensions;
using Infrastructure.RabbitMq;
using Infrastructure.RedisClient;
using Microsoft.AspNetCore.RateLimiting;
using Serilog;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApi(builder.Configuration)
                .AddApplication()
                .AddInfrastructure();

builder.Services.AddScoped<IRedisManager, RedisManager>();
builder.Services.AddScoped<IRedisService, RedisService>();
builder.Services.AddScoped<IRabbitMqService, RabbitMqService>();
builder.Services.AddScoped<IPublisherService, PublisherService>();
builder.Services.AddScoped<RedisConfigurationSource>();
builder.Configuration.AddRedisConfiguration(builder.Services);




builder.Host.UseSerilog((context, configuration) =>
{
    configuration.ReadFrom.Configuration(context.Configuration);
});

builder.Services.AddRateLimiter(options =>
{
    options.RejectionStatusCode = 429;
    options.AddFixedWindowLimiter("fixed", limiter =>
    {
        limiter.Window = TimeSpan.FromSeconds(10);
        limiter.PermitLimit = 3;
        limiter.QueueLimit = 0;
        limiter.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
    });
});



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseRateLimiter();

app.MapControllers();

app.Run();
