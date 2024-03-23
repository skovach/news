using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using News.Infrastructure.Interfaces;

namespace News.Infrastructure.Services;

public class BlobStorageService(BlobServiceClient blobServiceClient, IConfiguration configuration)
    : IBlobStorageService
{
    private readonly string _containerName = configuration["AzureBlobStorage:ContainerName"];

    public async Task<string> UploadImageAsync(IFormFile image)
    {
        var containerClient = blobServiceClient.GetBlobContainerClient(_containerName);
        await containerClient.CreateIfNotExistsAsync();
        await containerClient.SetAccessPolicyAsync(PublicAccessType.Blob);

        var blobClient = containerClient.GetBlobClient(image.FileName);
        await blobClient.UploadAsync(image.OpenReadStream(), new BlobHttpHeaders { ContentType = image.ContentType });

        return blobClient.Uri.ToString();
    }
}