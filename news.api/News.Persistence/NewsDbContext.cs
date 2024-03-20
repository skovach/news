using Microsoft.EntityFrameworkCore;
using News.Domain.Entities;

namespace News.Persistence;

public class NewsDbContext(DbContextOptions<NewsDbContext> options) : DbContext(options)
{
    public DbSet<Article> Articles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}