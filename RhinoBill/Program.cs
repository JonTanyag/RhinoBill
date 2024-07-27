using System.Reflection;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RhinoBill.Application;
using RhinoBill.Core;
using RhinoBill.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// Mediator
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(typeof(AddStudentCommand).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(UpdateStudentCommand).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(DeleteStudentCommand).GetTypeInfo().Assembly);

builder.Services.AddMediatR(typeof(AddCourseCommand).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(UpdateCourseCommand).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(DeleteCourseCommand).GetTypeInfo().Assembly);


builder.Services.AddMediatR(typeof(AddApplicationCommand).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(UpdateApplicationCommand).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(DeleteApplicationCommand).GetTypeInfo().Assembly);

builder.Services.AddMediatR(typeof(GetStudentsQuery).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(GetStudentByIdQuery).GetTypeInfo().Assembly);

builder.Services.AddMediatR(typeof(GetCourseQuery).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(GetCourseByIdQuery).GetTypeInfo().Assembly);

builder.Services.AddMediatR(typeof(GetApplicationQuery).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(GetApplicationByIdQuery).GetTypeInfo().Assembly);

// Validators


// DbContext
builder.Services.AddDbContext<RhinoBillDbContext>(options =>
                options.UseInMemoryDatabase("RhinoBillDb"));

// Services
builder.Services.AddTransient<IStudentService, StudentService>();
builder.Services.AddTransient<ICourseService, CourseService>();
builder.Services.AddTransient<IApplicationService, ApplicationService>();
builder.Services.AddSingleton<RandomGenerator>();

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

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

