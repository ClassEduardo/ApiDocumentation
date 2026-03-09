using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();

var app = builder.Build();

app.MapOpenApi();
app.MapScalarApiReference();
app.MapControllers();

app.UseHttpsRedirection();


app.Run();