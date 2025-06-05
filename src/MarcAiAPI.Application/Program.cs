using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using MarcAiAPI.Domain.Interfaces.Person;
using MarcAiAPI.Domain.Interfaces.Store;
using MarcAiAPI.Domain.Interfaces.Marketplace;
using MarcAiAPI.Infra.Data.Context;
using MarcAiAPI.Infra.Data.Repository.User;
using MarcAiAPI.Infra.Data.Repository.Store;
using MarcAiAPI.Service.Service.Person;
using MarcAiAPI.Service.Service.Store; 

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var frontendAppUrl = builder.Configuration.GetValue<string>("FrontendAppUrl") ?? "http://localhost:3000";

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowMyFrontend",
        policy =>
        {
            policy.WithOrigins(frontendAppUrl)
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders =
        ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
    options.KnownNetworks.Clear();
    options.KnownProxies.Clear();
});

// Repositórios
builder.Services.AddScoped<IStoreAddressRepository, StoreAddressRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IStoreRepository, StoreRepository>();
builder.Services.AddScoped<IMarketplaceRepository, MarketplaceRepository>();

// Serviços de Negócio
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IStoreService, StoreService>();
builder.Services.AddScoped<IMarketplaceService, MarketplaceService>();

// Application Insights
builder.Services.AddApplicationInsightsTelemetry();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    var logger = app.Services.GetRequiredService<ILogger<Program>>();
    logger.LogInformation("Aplicação iniciando em ambiente de Desenvolvimento.");
}

app.UseForwardedHeaders();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("AllowMyFrontend");
app.UseAuthorization();
app.MapControllers();

await app.RunAsync();