using Casino.BLL;
using Casino.BLL_EF;
using Casino.DAL;
using Casino.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddBLL();
// Add DbContext for Entity Framework Core
builder.Services.AddDbContext<CasinoDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Identity
builder.Services.AddIdentity<User, IdentityRole<int>>(options =>
{

})
    .AddEntityFrameworkStores<CasinoDbContext>();// This line configures EF Core to store Identity data in CasinoDbContext

// Configure cookie settings
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Account/AccessDenied";
});

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("CasinoClient", policy =>
    {
        policy.WithOrigins(builder.Configuration.GetSection("AppConfig:Audience").Value!)
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

// Add AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

// Add HttpContextAccessor
builder.Services.AddHttpContextAccessor();

// Add scoped services for UserManager and SignInManager
builder.Services.AddScoped<UserManager<User>>();
builder.Services.AddScoped<SignInManager<User>>();

var app = builder.Build();

// Use CORS
app.UseCors("CasinoClient");

// Configure HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
