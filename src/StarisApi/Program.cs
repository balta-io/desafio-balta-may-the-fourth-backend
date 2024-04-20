using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using StarisApi.Configurations.Attributtes;
using StarisApi.DbContexts;
using StarisApi.Endpoints;
using StarisApi.Endpoints.Characters;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.EnableAnnotations();
    opt.DescribeAllParametersInCamelCase();
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "StarisApi", Version = "v1" });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    opt.IncludeXmlComments(xmlPath);

    opt.OperationFilter<ParameterAttribute>();
});

builder.Services.AddDbContext<SqliteContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddTransient<SqliteContext>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.MapGroup("/api").MapEndpoints();

app.Run();
