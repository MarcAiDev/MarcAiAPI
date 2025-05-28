using MarcAiAPI.Domain.Interfaces.Person;
using MarcAiAPI.Domain.Interfaces.Store;
using MarcAiAPI.Infra.Data.Context;
using MarcAiAPI.Infra.Data.Repository.Store;
using MarcAiAPI.Service.Service.Person;
using MarcAiAPI.Service.Service.Store;
using Microsoft.EntityFrameworkCore;
using MarcAiAPI.Domain.Interfaces.Marketplace;
using MarcAiAPI.Infra.Data.Repository.User;
using MarcAiAPI.Service.I.A;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient<ClassificationApiService>(client =>
{
    // Define a URL base da API
    client.BaseAddress = new Uri("http://localhost:5000/");
});

// Add DbContext with PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add controller and Swagger services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Repositories
builder.Services.AddScoped<IStoreAddressRepository, StoreAddressRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IStoreRepository, StoreRepository>();
builder.Services.AddScoped<IMarketplaceRepository, MarketplaceRepository>();


// Services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IStoreService, StoreService>();
builder.Services.AddScoped<IMarketplaceService, MarketplaceService>();

var app = builder.Build();


// Obtém o serviço do container de DI e executa o método
var apiService = app.Services.GetRequiredService<ClassificationApiService>();

// Chama o método para um usuário com ID 1, por exemplo
await apiService.SendClassificationRequestAsync(1);

// Configure HTTP pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

await app.RunAsync();