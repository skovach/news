using System.Reflection;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using News.Application.Extensions;
using News.Application.UseCases.Query;
using News.Infrastructure.Extensions;
using News.Persistence;
using News.Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRazorPages();
builder.Services.AddMediatR(cfg=> cfg.RegisterServicesFromAssemblies(typeof(GetArticlesQuery).GetTypeInfo().Assembly));

builder.Services.AddControllers();

builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

builder.Services.RegisterPersistence(builder.Configuration);
builder.Services.RegisterApplication(builder.Configuration);
builder.Services.RegisterInfrastructure(builder.Configuration);

if (!builder.Environment.IsDevelopment())
{
    builder.WebHost.UseUrls("http://*:" + Environment.GetEnvironmentVariable("PORT"));
}

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<NewsDbContext>();
    dbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.Run();
