using News.Domain.Enums;

namespace News.Domain.Entities;

public class Article
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTimeOffset PublishedDate { get; set; }
    public Category Category { get; set; }
    public string AuthorName { get; set; }
    public string ImageUrl { get; set; }
}