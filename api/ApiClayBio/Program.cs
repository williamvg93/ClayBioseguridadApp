var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}




/* 
Api
dotnet add package AspNetCoreRateLimit --version 5.0.0
dotnet add package AutoMapper --version 12.0.1
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer --version 8.0.2
dotnet add package Asp.Versioning.Mvc --version 8.0.0
dotnet add package Microsoft.EntityFrameworkCore.Design --version 8.0.2

Domain
dotnet add package FluentValidation.AspNetCore --version 11.3.0
dotnet add package itext7.pdfhtml --version 5.0.2
dotnet add package Microsoft.EntityFrameworkCore --version 8.0.2

Persistence
dotnet add package Microsoft.EntityFrameworkCore --version 8.0.2
dotnet add package Pomelo.EntityFrameworkCore.MySql --version 7.0.0

*/