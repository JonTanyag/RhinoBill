using System.Reflection;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using RhinoBill.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Mediator
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(typeof(AddStudentCommand).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(UpdateStudentCommand).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(DeleteStudentCommand).GetTypeInfo().Assembly);

// validators



builder.Services.AddControllers();
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

