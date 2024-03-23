using Microsoft.AspNetCore.Http;
using News.Domain.Enums;

namespace News.Application.Dto;

public class ArticleDto
{
    public string Title { get; set; }
    public string Content { get; set; }

    public Category Category { get; set; }
    public string AuthorName { get; set; }
    public IFormFile ImageFile { get; set; }
}