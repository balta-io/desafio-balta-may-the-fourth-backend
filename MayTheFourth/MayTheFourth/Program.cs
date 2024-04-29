using MayTheFourth.Infra.Context;
using MayTheFourth.Interfaces.Services;
using MayTheFourth.Mappings.Filme;
using MayTheFourth.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
ConfigureServices(builder);

var app = builder.Build();
ConfigureApiServices(app);

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.Run();

void ConfigureServices(WebApplicationBuilder builder)
{
    builder.Services.AddDbContext<MayTheFourthDataContext>();
    builder.Services.AddScoped<IFilmeService, FilmeService>();
}

void ConfigureApiServices(WebApplication webApplication)
{
    webApplication.FilmeMapEndpoints();
}