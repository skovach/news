using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace News.Persistence.Extensions;

public static class DependencyExtensions
{
    public static void RegisterPersistence(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddDbContext<NewsDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("News")));

    }
}