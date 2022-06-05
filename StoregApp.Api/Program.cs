using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using StoregApp.Application;
using StoregApp.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddFluentValidation();
builder.Services.AddAplicationServices();
builder.Services.AddDbContext<StoreGContext>(options => options.UseSqlServer("name=ConnectionStrings:StoreG"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.MapControllers();

app.Run();
