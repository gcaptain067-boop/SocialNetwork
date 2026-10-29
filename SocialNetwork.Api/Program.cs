using Microsoft.AspNetCore.Identity;
using SocialNetwork.Api.Data;
using SocialNetwork.Api.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();



builder.Services.AddDbContext<AppDbContext>(o =>
    o.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddIdentityCore<ApplicationUser>(o =>
{
    o.User.RequireUniqueEmail = true;

    o.Lockout.AllowedForNewUsers = true;
    o.Lockout.MaxFailedAccessAttempts = 5;
    o.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);

    o.Password.RequiredLength = 8;
    o.Password.RequireUppercase = true;
    o.Password.RequireLowercase = true;
    o.Password.RequireDigit = true;
    o.Password.RequireNonAlphanumeric = true;
})
.AddRoles<IdentityRole<Guid>>()
.AddEntityFrameworkStores<AppDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
