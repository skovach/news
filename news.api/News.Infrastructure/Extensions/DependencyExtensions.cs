using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using News.Infrastructure.Interfaces;
using News.Infrastructure.Services;

namespace News.Infrastructure.Extensions;

public static class DependencyExtensions
{
    public static void RegisterInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton(x => new BlobServiceClient(configuration["AzureBlobStorage:ConnectionString"]));
        services.AddSingleton<IBlobStorageService, BlobStorageService>();

        
    }
}