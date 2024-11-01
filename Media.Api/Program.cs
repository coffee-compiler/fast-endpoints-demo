using FastEndpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFastEndpoints();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseFastEndpoints();

app.Run();
