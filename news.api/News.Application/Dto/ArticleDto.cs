using News.Domain.Enums;

namespace News.Application.Dto;

public class ArticleUpdateDto
{
    public string Title { get; set; }
    public string Content { get; set; }
    
    public Category Category { get; set; }
    public string AuthorName { get; set; }
}