using FastEndpoints;
using Media.Api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(o => o.UseInMemoryDatabase("AppDb"));

builder.Services.AddFastEndpoints();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseFastEndpoints();

app.Run();
