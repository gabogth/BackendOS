using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.OData;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using nest.core.aplication.auth;
using nest.core.datasource.Extensions;
using nest.core.dominio.Contabilidad.CuentaContableEntities;
using nest.core.dominio.Logistica;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
Console.WriteLine("Iniciando aplicación Datasource...");
if (ConfigVariables.IsLambda)
    builder.Services.AddAWSLambdaHosting(LambdaEventSource.HttpApi);

// Add services custom
builder.Configuration.AddJsonFile("appsettings.json", optional: true)
                     .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                     .AddUserSecrets<Program>()
                     .AddEnvironmentVariables();
DbContextSelector.SelectProvider(builder, true);
builder.Services.ConfigureAplication(builder.Configuration);
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});
// End services custom

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
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
builder.Services.AddHttpContextAccessor();
builder.Services
    .AddGraphQLServer()
    .AddDataSources()
    .AddFiltering()
    .AddSorting()
    .AddProjections()
    .AddErrorFilter(err =>
    {
        if (err.Exception is not null)
            return err.WithMessage(err.Exception.ToString());
        return err;
    });
builder.Services
    .AddControllers()
    .AddOData(options =>
        options.AddRouteComponents("odata", GetEdmModel())
               .Select().Filter().OrderBy().Expand().Count().SetMaxTop(null));


var app = builder.Build();
if (!string.IsNullOrEmpty(ConfigVariables.BaseUrl))
    app.UsePathBase(ConfigVariables.BaseUrl);
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors("CorsPolicy");
app.MapGraphQL($"/graphql");
app.MapNitroApp($"/my-graphql-ui");
app.UseMiddleware<ErrorHandlingMiddleware>();
app.MapControllers();
app.Run();


static IEdmModel GetEdmModel()
{
    var builder = new ODataConventionModelBuilder();
    builder.EntitySet<CuentaContable>("CuentaContable");
    return builder.GetEdmModel();
}
