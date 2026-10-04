using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using nest.core.aplication.auth;
using nest.core.security.Extensions;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

if (Environment.GetEnvironmentVariable("IS_LAMBDA") != null)
    builder.Services.AddAWSLambdaHosting(LambdaEventSource.HttpApi);

// Add services custom
builder.Configuration.AddJsonFile("appsettings.json", optional: true)
                     .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                     .AddUserSecrets<Program>()
                     .AddEnvironmentVariables();

DbContextSelector.SelectProvider(builder, !MigrationService.IsMigration());

builder.Services.ConfigureAplication(builder.Configuration);
builder.Services.AddHealthChecks().AddCheck("self", () => HealthCheckResult.Healthy(), ["live"]);
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader()
               .WithExposedHeaders("Content-Disposition", "X-Custom-Header", "Authorization");
        builder.SetIsOriginAllowed(_ => true);
    });
});
// End services custom

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    }); ;
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("/", new OpenApiInfo
    {
        Title = "Nest Services",
        Version = "V1"
    });
    foreach (var endpoint in ConfigureEndpoints.Endpoints)
    {
        c.SwaggerDoc(endpoint.Key, new OpenApiInfo
        {
            Title = endpoint.Value.Title,
            Version = endpoint.Value.Version
        });
    }
    c.DocInclusionPredicate((docName, apiDesc) =>
    {
        var relativePath = apiDesc.RelativePath;
        if (string.IsNullOrEmpty(relativePath)) return false;
        return relativePath.StartsWith(docName, StringComparison.OrdinalIgnoreCase);
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Ingrese el token JWT en este formato: Bearer {token}",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement((document) => new OpenApiSecurityRequirement()
    {
        [new OpenApiSecuritySchemeReference("Bearer", document)] = []
    });
});
builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(option =>
{
    option.SaveToken = true;
    option.TokenValidationParameters = new TokenValidationParameters
    {
        SaveSigninToken = true,
        ValidateIssuer = true,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});
builder.Services.AddAuthorization();

var app = builder.Build();
await MigrationResolver.ExecuteMigration(app);
if(!string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("BASE_URL")))
    app.UsePathBase(Environment.GetEnvironmentVariable("BASE_URL"));
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    foreach (var endpoint in ConfigureEndpoints.Endpoints)
        c.SwaggerEndpoint($"./{endpoint.Key}/swagger.json", endpoint.Value.Title);
});
app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.UseAuthentication();
app.UseAuthorization();
app.MapHealthChecks("/health/live", new HealthCheckOptions {
    ResponseWriter = async (ctx, report) =>
    {
        ctx.Response.ContentType = "application/json";
        var result = JsonSerializer.Serialize(new
        {
            status = report.Status.ToString(),
            results = report.Entries.Select(e => new
            {
                key = e.Key,
                status = e.Value.Status.ToString(),
                description = e.Value.Description
            })
        });
        await ctx.Response.WriteAsync(result);
    }
});
app.UseMiddleware<ErrorHandlingMiddleware>();
app.MapControllers();
app.Run();