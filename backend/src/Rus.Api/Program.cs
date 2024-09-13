using Rus.Api;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json"))
    .AddJsonFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
        $"appsettings.{builder.Environment.EnvironmentName}.json"), optional: true)
    .AddEnvironmentVariables();

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddApiInfrastructure(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseCors(c => c
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();