using Adapters.Extensions;
using API.Filters;
using API.HealthChecks;
using Application.Extensions;
using External.Clients.Auth;
using External.Extensions;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

#region Configure Services

var configuration = builder.Configuration;

builder.Services.AddCustomHealthChecks(configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();

    // Configuração de autenticação JWT no Swagger
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});

builder.Services.AddControllers(options =>
{
    options.Filters.Add<TransactionalContextFilter>();
});

builder.Services.AddAuth(configuration);
builder.Services.AddExternalDependencies(configuration);
builder.Services.AddAdaptersDependencies();
builder.Services.AddApplicationDependencies();

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.CreateDatabase(configuration);
    //app.CreateQueuesIfNotExist();
}

app.UseAuthentication();
app.UseAuthorization();

app.UseCustomHealthChecks();
app.UseHttpsRedirection();
app.MapControllers().RequireAuthorization();

app.Run();
