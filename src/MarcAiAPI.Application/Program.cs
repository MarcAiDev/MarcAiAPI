using MarcAiAPI.Domain.Interfaces.Person;
using MarcAiAPI.Domain.Interfaces.Store;
using MarcAiAPI.Infra.Data.Context;
using MarcAiAPI.Infra.Data.Repository.Store;
using MarcAiAPI.Service.Service.Person;
using MarcAiAPI.Service.Service.Store;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using MarcAiAPI.Domain.Entities.Store;
using MarcAiAPI.Domain.Entities.User;
using MarcAiAPI.Domain.Interfaces.Marketplace;
using MarcAiAPI.Infra.Data.Repository.User;
using MarcAiAPI.Service.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext with PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register FluentValidation validators explicitly
builder.Services.AddScoped<IValidator<UserEntity>, UserValidator>();
builder.Services.AddScoped<IValidator<StoreEntity>, StoreValidator>();

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