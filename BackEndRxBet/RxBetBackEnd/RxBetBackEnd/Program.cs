using Infrastructure;
using Microsoft.EntityFrameworkCore;
using RxBetAuthorization.Interfaces.Auth;
using RxBetAuthorization.Services;
using RxBetBackEnd.Endpoints;
using RxBetDataBase;
using RxBetDataBase.Repositories;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var configuration = builder.Configuration;

builder.Services.AddDbContext<RxBetDbContext>(options =>
{
    options.UseNpgsql(configuration.GetConnectionString(nameof(RxBetDbContext)));
});

builder.Services.AddScoped<IJwtProvider, JwtProvider>();
builder.Services.AddScoped<IJwtOptions, JwtOptions>();
builder.Services.AddScoped <IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<UsersService>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapUsersEndpoints();

app.MapGet("/", () => "Hello World!");

app.Run();
