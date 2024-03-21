using System.Reflection;
using Microsoft.EntityFrameworkCore;
using News.Application.Extensions;
using News.Application.UseCases.Query;
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

builder.Services.RegisterPersistence(builder.Configuration);
builder.Services.RegisterApplication(builder.Configuration);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<NewsDbContext>();
    dbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.Run();
