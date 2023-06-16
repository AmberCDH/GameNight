using Avondspel.Infrastructure.Data;
using Avondspel.Infrastructure.Repository;
using Avondspel.Services.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Avondspel.Infrastructure.Repositories;
using Avondspel.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

//Normale databse connection
builder.Services.AddDbContext<AvondspelDbContext>(opts =>
{
    opts.UseSqlServer(
        builder.Configuration["ConnectionStrings:AvondspelPortalConnection"]);
});

builder.Services.AddScoped<IRepositoryBordspellen, RepositoryBordspel>();
builder.Services.AddScoped<IRepositoryGebruiker, RepositoryGebruiker>();
builder.Services.AddScoped<IRepositoryBordspellenAvond, RepositoryBordspellenAvond>();
builder.Services.AddScoped<IRepositoryBordspelLijst, RepositoryBordspelLijst>();
builder.Services.AddScoped<IRepositoryEten, RepositoryEten>();
builder.Services.AddScoped<IBordspellenAvondDomainService, BordspellenAvondDomainService>();

//Identity database connection
builder.Services.AddDbContext<IdentityDbContext>(opts =>
{
    opts.UseSqlServer(
        builder.Configuration["ConnectionStrings:IdentityConnection"]);
});

//AddIdentity registers the services
builder.Services.AddIdentity<IdentityUser, IdentityRole>(config =>
{
    config.Password.RequiredLength = 4;
    config.Password.RequireDigit = false;
    config.Password.RequireNonAlphanumeric = false;
    config.Password.RequireUppercase = false;
})
    .AddEntityFrameworkStores<IdentityDbContext>()
    .AddDefaultTokenProviders();


builder.Services.ConfigureApplicationCookie(configure =>
{
    configure.Cookie.Name = "Identity.Cookie";
    configure.LoginPath = "/Home/Login";
});

builder.Services.AddAuthorization(config =>
{
     config.AddPolicy("Gebruiker", policyBuilder => policyBuilder.RequireClaim("UserType", "gebruiker"));
     config.AddPolicy("Organisator", policyBuilder => policyBuilder.RequireClaim("UserType", "organisator"));

});

var app = builder.Build();

app.UseStaticFiles();

//Who are you?
app.UseAuthentication();

//Are you allowed?
app.UseAuthorization();

app.MapDefaultControllerRoute();

//SeedData.EnsurePopulated(app);

app.Run();
