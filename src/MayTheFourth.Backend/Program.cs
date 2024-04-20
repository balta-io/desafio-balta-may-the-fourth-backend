using MayTheFourth.Backend.Configurations;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApiConfiguration(builder.Configuration);

var app = builder.Build();
app.UseApiConfiguration(builder.Environment);

app.Run();
