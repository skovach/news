using Microsoft.AspNetCore.Http;

namespace News.Infrastructure.Interfaces;

public interface IBlobStorageService
{
    Task<string> UploadImageAsync(IFormFile image);
}