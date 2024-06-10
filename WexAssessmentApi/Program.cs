using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WexAssessmentApi.Models;
using WexAssessmentApi.Repositories;
using Duende.IdentityServer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Duende.IdentityServer.Models;
using WexAssessmentApi.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure IdentityServer
builder.Services.AddIdentityServer()
    .AddInMemoryClients(IdentityServerConfig.GetClients())
    .AddInMemoryApiScopes(IdentityServerConfig.GetApiScopes())
    .AddInMemoryApiResources(IdentityServerConfig.GetApiResources())
    .AddInMemoryIdentityResources(IdentityServerConfig.GetIdentityResources())
    .AddDeveloperSigningCredential();

// Configure authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = "https://localhost:7238";
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false
        };
    });

builder.Services.AddAuthorization();

// Add scoped repositories
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseIdentityServer();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }

public static class IdentityServerConfig
{
    public static IEnumerable<Duende.IdentityServer.Models.Client> GetClients()
    {
        return new List<Duende.IdentityServer.Models.Client>
        {
            new Duende.IdentityServer.Models.Client
            {
                ClientId = "client",
                AllowedGrantTypes = Duende.IdentityServer.Models.GrantTypes.ClientCredentials,
                ClientSecrets = { new Duende.IdentityServer.Models.Secret("secret".Sha256()) },
                AllowedScopes = { "api1" }
            }
        };
    }

    public static IEnumerable<Duende.IdentityServer.Models.ApiScope> GetApiScopes()
    {
        return new List<Duende.IdentityServer.Models.ApiScope>
        {
            new Duende.IdentityServer.Models.ApiScope("api1", "My API")
        };
    }

    public static IEnumerable<Duende.IdentityServer.Models.ApiResource> GetApiResources()
    {
        return new List<Duende.IdentityServer.Models.ApiResource>();
    }

    public static IEnumerable<Duende.IdentityServer.Models.IdentityResource> GetIdentityResources()
    {
        return new List<Duende.IdentityServer.Models.IdentityResource>();
    }
}
