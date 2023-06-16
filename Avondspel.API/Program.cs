using Avondspel.API.Data;
using Avondspel.API.Services;
using Avondspel.Infrastructure.Data;
using Avondspel.Infrastructure.Repositories;
using Avondspel.Services.IRepositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(x =>
x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

//Normale databse connection
builder.Services.AddDbContext<AvondspelDbContext>(opts =>
{
    opts.UseSqlServer(
        builder.Configuration["ConnectionStrings:AvondspelPortalConnection"]);
});

builder.Services.AddScoped<IRepositoryBordspellenAvond, RepositoryBordspellenAvond>();
builder.Services.AddScoped<IRepositoryGebruiker, RepositoryGebruiker>();
builder.Services.AddScoped<ITokenService, TokenService>();

//Identity database connection
builder.Services.AddDbContext<Avondspel.Infrastructure.Data.IdentityDbContext>(opts =>
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
    .AddEntityFrameworkStores<Avondspel.Infrastructure.Data.IdentityDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddGraphQLServer().AddQueryType<Query>().AddProjections().AddFiltering().AddSorting();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.Map("/api/BordspelAvond", VerifyToken);
app.MapControllers();
app.MapGraphQL("/graphql");

app.Run();

static void VerifyToken(IApplicationBuilder app, IConfiguration configuration)
{
    app.Run(async context =>
    {
        var handler = new JwtSecurityTokenHandler();
        try
        {
            var jwt = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", string.Empty);
            handler.ValidateToken(jwt, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("AppSettings:Token").Value)),
                ValidateIssuer = false,
                ValidateAudience = false,
            }, out SecurityToken validatedToken);
        }
        catch
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Invalid jwt");
        }
    });
}