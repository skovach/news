using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace News.Persistence.Extensions;

public static class DependencyExtensions
{
    public static void RegisterPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("News");
        services.AddDbContext<NewsDbContext>(options =>
            options.UseNpgsql(connectionString));

    }
}