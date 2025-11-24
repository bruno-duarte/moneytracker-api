using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using MoneyTracker.Api.DependencyInjection;

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
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "MoneyTracker API",
        Version = "v1",
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


builder.Services.AddMoneyTrackerDependencies(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json","MoneyTracker API v1"));
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();
