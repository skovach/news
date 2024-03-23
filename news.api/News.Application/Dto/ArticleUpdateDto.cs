using Microsoft.AspNetCore.Http;
using News.Domain.Enums;

namespace News.Application.Dto;

public class ArticleUpdateDto
{
    public string Title { get; set; }
    public string Content { get; set; }

    public Category Category { get; set; }
    public string AuthorName { get; set; }
    public string ImageUrl { get; set; }
    public IFormFile? ImageFile { get; set; }
}