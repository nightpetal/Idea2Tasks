using Idea2Tasks.Backend.Data;
using Idea2Tasks.Backend.Repositories;
using Idea2Tasks.Backend.Repositories.Interface;
using Idea2Tasks.Backend.Services;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<IProjectRepo, ProjectRepo>();
builder.Services.AddScoped<ISubTaskRepo, SubTaskRepo>();

builder.Services.AddDbContext<AppDb>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddHttpClient<GeminiService>();

var apiKey = builder.Configuration["AppSettings:ApiKey"];
builder.Services.Configure<AppSettingsOptions>(
    builder.Configuration.GetSection("AppSettings"));
builder.Services.AddTransient<GeminiService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy
            .WithOrigins(
                "http://127.0.0.1:5500",
                "http://localhost:5500",
                "http://localhost:5173",
                "http://127.0.0.1:5173",
                "http://192.168.100.3:5173"
            )
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDb>();
    db.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

// app.UseHttpsRedirection();
app.UseCors("AllowFrontend");

app.UseAuthorization();

app.MapControllers();

app.Run();
