using Microsoft.EntityFrameworkCore;
using NLog.Extensions.Logging;
using System.Text.Json.Serialization;
using WorldRank.Application.Interfaces;
using WorldRank.Application.Services;
using WorldRank.Application.Strategies;
using WorldRank.Infrastructure.Caching;

//using WorldRank.Gateway;
using WorldRank.Infrastructure.Persistence;
using WorldRank.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);


// Logging via NLog (same nlog.config layout as the Console app).
//builder.Logging.ClearProviders();
builder.Logging.AddNLog("nlog.config");

//builder.Host.UseServiceProviderFactory();

builder.Services.AddDbContext<WorldRankDbContext>(options => {
    options.UseSqlServer("Server=MYDESKTOP\\SQLEXPRESS;Database=WorldRank;Integrated Security=true; TrustServerCertificate=true");
});

//Repositories/services
builder.Services.AddScoped<IPlayerRepository, DBPlayerRepository>();
builder.Services.AddScoped<IWalletRepository, DbWalletRepository>();
builder.Services.AddScoped<IPlayerService, PlayerService>(); 
builder.Services.AddScoped<IWalletService, WalletService>();


builder.Services.AddSingleton<IFundsStrategy, AddFundsStrategy>();
builder.Services.AddSingleton<IFundsStrategy, SubtractFundsStrategy>();
builder.Services.AddSingleton<IFundsStrategy, ForceSubtractFundsStrategy>();

// Single-instance in-memory cache (Day 6). Redis would replace this behind a load balancer.
builder.Services.AddMemoryCache();
builder.Services.AddSingleton<ICache, MemoryCacheStore>();

//Accept / emit enums (e.g. Currency) as their string names, not numbers.
builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

// Swagger / OpenAPI — interactive API docs at /swagger.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builer.Services.AddHttpClient<IEcbHttpClient, EcbHTTPClient>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapGet("/", () => Results.Redirect("/swagger")); 
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();