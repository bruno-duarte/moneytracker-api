using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using MoneyTracker.Api.DependencyInjection;
using Asp.Versioning;
using Asp.Versioning.ApiExplorer;


var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllers(options =>
    {
        options.Filters.Add<GlobalExceptionFilter>();
    })
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling =
            Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    });
var apiVersioning = builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
});
apiVersioning.AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    var provider = builder.Services.BuildServiceProvider()
        .GetRequiredService<IApiVersionDescriptionProvider>();

    foreach (var desc in provider.ApiVersionDescriptions)
    {
        c.SwaggerDoc(desc.GroupName, new OpenApiInfo
        {
            Title = $"MoneyTracker API",
            Version = desc.GroupName,
            Description = "API responsible for managing financial transactions, categories and reporting functionalities.",
            Contact = new OpenApiContact
            {
                Name = "Bruno Duarte",
                Email = "fbrunoduarte@outlook.com"
            },
            License = new OpenApiLicense
            {
                Name = "MIT License",
                Url = new Uri("https://opensource.org/licenses/MIT")
            }
        });
    }

    var xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml", SearchOption.TopDirectoryOnly);
    foreach (var xml in xmlFiles)
    {
        c.IncludeXmlComments(xml, includeControllerXmlComments: true);
    }

    c.EnableAnnotations();

    // Remove ProblemDetails
    c.MapType<ProblemDetails>(() => new OpenApiSchema { });
});
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
builder.Services.AddRouting(options =>
{
    options.LowercaseUrls = true;
    options.LowercaseQueryStrings = true;
});

builder.Services.AddMoneyTrackerDependencies(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

    app.UseSwaggerUI(options =>
    {
        foreach (var desc in provider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint($"/swagger/{desc.GroupName}/swagger.json", desc.GroupName.ToUpperInvariant());
            options.RoutePrefix = string.Empty;
        }
    });
}

app.UseSwagger();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();
