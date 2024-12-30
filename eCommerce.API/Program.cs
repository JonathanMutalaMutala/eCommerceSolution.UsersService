using eCommerce.Infrastructure;
using eCommerce.Core;
using eCommerce.API.Middlewares;
using System.Text.Json.Serialization;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add infrastructure 
builder.Services.AddInfrastructure();
builder.Services.AddCore();


builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

builder.Services.AddFluentValidationAutoValidation(); 

var app = builder.Build();


app.UseExceptionHandlingMiddleware();


// Routing 
app.UseRouting();

//Auth 
app.UseAuthentication();
app.UseAuthorization();

//Controller routes
app.MapControllers();


app.Run();
