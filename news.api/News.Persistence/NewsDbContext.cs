using Microsoft.EntityFrameworkCore;
using News.Domain.Entities;
using News.Persistence.EntityConfigurations;

namespace News.Persistence;

public class NewsDbContext(DbContextOptions<NewsDbContext> options) : DbContext(options)
{
    public DbSet<Article?> Articles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ArticleConfiguration).Assembly);
    }
}