using eCommerce.Infrastructure;
using eCommerce.Core;
using eCommerce.API.Middlewares;
using System.Text.Json.Serialization;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add infrastructure 
builder.Services.AddInfrastructure();
builder.Services.AddCore();

// Add Api Explorer services 
builder.Services.AddEndpointsApiExplorer(); 

builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

builder.Services.AddFluentValidationAutoValidation();


//Add Swagger 
builder.Services.AddSwaggerGen();

// Add Cors services 
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

var app = builder.Build();


app.UseExceptionHandlingMiddleware();


// Routing 
app.UseRouting();
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors();


//Auth 
app.UseAuthentication();
app.UseAuthorization();

//Controller routes
app.MapControllers();


app.Run();
