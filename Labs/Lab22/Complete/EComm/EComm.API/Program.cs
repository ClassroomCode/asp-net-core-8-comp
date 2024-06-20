using EComm.API.Auth;
using EComm.Core;
using EComm.Infrastructure;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication("MyCustomAuth")
  .AddScheme<AuthenticationSchemeOptions, MyCustomAuthHandler>
    ("MyCustomAuth", options => { });

builder.Services.AddAuthorization(options => {
    options.AddPolicy("AdminsOnly", policy =>
      policy.RequireClaim(ClaimTypes.Role, "Admin"));
});

builder.Services.AddCors(options => {
    options.AddPolicy(name: "AllowedOrigins",
        builder => {
            builder.WithOrigins("http://localhost:5229",
                          "https://localhost:7207");
        });
});

var connStr = builder.Configuration.GetConnectionString("ECommConnection");
if (connStr == null) {
    throw new Exception("Missing connection string");
}
else {
    builder.Services.AddScoped<IRepository>(sp =>
      RepositoryFactory.Create(connStr));
}

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowedOrigins");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
