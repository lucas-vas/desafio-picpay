using DesafioPicPay.Application.Features.User.Commands.CreateTransaction;
using DesafioPicPay.Application.Services;
using DesafioPicPay.Application.Services.Interfaces;
using DesafioPicPay.Domain.Interfaces;
using DesafioPicPay.Infra.Data.Context;
using DesafioPicPay.Infra.Data.Integration.Uow;
using DesafioPicPay.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("Database");

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddMediatR(config => {
    config.RegisterServicesFromAssemblyContaining<CreateTransactionCommand>();
});

builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<ITransactionService, TransactionService>();
builder.Services.AddTransient<IAuthorizerTransactionService, AuthorizerTransactionService>();

builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
