using Backend.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

var postgresConnection = builder.Configuration.GetConnectionString("Postgres")
    ?? throw new InvalidOperationException("Connection string 'Postgres' is not configured.");

builder.Services.AddInfrastructure(postgresConnection);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
