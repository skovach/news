using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using News.Application.Profiles;

namespace News.Application.Extensions;

public static class DependencyExtensions
{
    public static void RegisterApplication(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddAutoMapper(typeof(ArticleProfile).Assembly);
        
        serviceCollection.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
        
    }
}