using JobFinder.API;
using JobFinder.API.ErrorHandler;
using JobFinder.Application;
using JobFinder.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddWebAPI()
    .AddApplication()
    .AddInfrastructure();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapSwagger();

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
