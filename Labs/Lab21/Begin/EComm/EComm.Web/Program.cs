using EComm.Core;
using EComm.Infrastructure;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAuthentication(
  CookieAuthenticationDefaults.AuthenticationScheme)
  .AddCookie(options => { options.LoginPath = "/login"; });

builder.Services.AddAuthorization(options => {
    options.AddPolicy("AdminsOnly", policy =>
      policy.RequireClaim(ClaimTypes.Role, "Admin"));
});

var connStr = builder.Configuration.GetConnectionString("ECommConnection");
if (connStr == null) {
    throw new Exception("Missing connection string");
}
else {
    builder.Services.AddScoped<IRepository>(sp =>
      RepositoryFactory.Create(connStr));
}

builder.Services.AddMemoryCache();
builder.Services.AddSession();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/servererror");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/clienterror", "?statuscode={0}");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
