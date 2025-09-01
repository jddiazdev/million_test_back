using Microsoft.Extensions.Options;
using million.api.Filters;
using million.api.Middlewares;
using million.application;
using million.application.services;
using million.domain.interfaces;
using million.infrastructure.persistence;
using million.infrastructure.repositories;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


// Configuración de Mongo
builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("MongoDb")
);


builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();
    var connectionString = configuration.GetValue<string>("MongoDb:ConnectionString");

    if (string.IsNullOrEmpty(connectionString))
        throw new InvalidOperationException("MongoDB connection string is not configured.");

    return new MongoClient(connectionString);
});


builder.Services.AddScoped<IMongoDatabase>(sp =>
{
    var client = sp.GetRequiredService<IMongoClient>();
    var settings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;

    if (string.IsNullOrEmpty(settings.DatabaseName))
        throw new InvalidOperationException("MongoDB database name is not configured.");

    return client.GetDatabase(settings.DatabaseName);
});



builder.Services.AddControllers(options =>
{
    options.Filters.Add<ApiResponseFilter>();
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReact",
            policy => policy
                .WithOrigins("http://localhost:3000")
                .AllowAnyHeader()
                .AllowAnyMethod());

});


builder.Services.AddScoped<PropertyService>();
builder.Services.AddScoped<IPropertyRepository, PropertyRepository>();

builder.Services.AddScoped<OwnerService>();
builder.Services.AddScoped<IOwnerRepository, OwnerRepository>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// builder.Services.AddOpenApi();

var app = builder.Build();


app.UseCors("AllowReact");


// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.MapOpenApi();
// }

// app.UseHttpsRedirection();

// app.UseAuthorization();

app.UseExceptionMiddleware();


app.MapControllers();

app.Run();
