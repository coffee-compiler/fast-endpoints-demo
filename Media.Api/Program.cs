using FastEndpoints;
using FluentValidation;
using Media.Api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var assembly = typeof(Program).Assembly;

builder.Services.AddDbContext<AppDbContext>(o => o.UseInMemoryDatabase("AppDb"));

builder.Services.AddMediatR(c => c.RegisterServicesFromAssembly(assembly));
builder.Services.AddValidatorsFromAssembly(assembly);

builder.Services.AddAuthentication()
    .AddJwtBearer(o =>
    {
        o.Audience = builder.Configuration["Authentication:Audience"];
        o.Authority = builder.Configuration["Authentication:Authority"];
        o.RequireHttpsMetadata = false;
    });

builder.Services.AddAuthorization();
builder.Services.AddFastEndpoints();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.UseDefaultExceptionHandler();

app.UseFastEndpoints(c =>
{
    c.Endpoints.RoutePrefix = "api";
});

app.Run();
