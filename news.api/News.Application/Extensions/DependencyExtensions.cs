using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using News.Application.Profiles;
using News.Domain.Entities;

namespace News.Application.Extensions;

public static class DependencyExtensions
{
    public static void RegisterApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(typeof(ArticleProfile).Assembly);
        
        services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
        
        services.AddHttpClient(nameof(Article), client =>
        {
            var baseUrl = configuration.GetValue<string>("ApiUrl");
            client.BaseAddress = new Uri($"{baseUrl}/Articles");
        });
    }
}