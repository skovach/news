namespace News.Domain.Entities;

public class Article
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTimeOffset PublishedDate { get; set; }
}