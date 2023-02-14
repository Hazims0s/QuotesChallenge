using Application.Authers.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using AutoMapper;
using Application.Core;
using API.Extensions;
using API.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddApplicationIdentityServices(builder.Configuration);
var app = builder.Build();
app.UseMiddleware<ExceptionMiddleware>();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

try
{
    var context = services.GetRequiredService<DataContext>();
    context.Database.Migrate();
}
catch (Exception ex)
{

    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "Migrations Error ");
}

app.Run();
