using System;
using API.Models;
using API.Services;

string allowedOrigins = "_allowedOrigins";
WebApplicationBuilder builder = WebApplication.CreateBuilder(args: args);

//CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: allowedOrigins,
        policy =>
        {
            policy.WithOrigins("*");
        }
    );
});

// MongoDB configuration
builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDB"));
builder.Services.AddSingleton<MongoDBService>();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

WebApplication? app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(allowedOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
