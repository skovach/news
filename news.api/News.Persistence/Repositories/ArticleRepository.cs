using Microsoft.EntityFrameworkCore;
using News.Domain.Entities;
using News.Domain.Enums;

namespace News.Persistence.Repositories
{
    public class ArticleRepository(NewsDbContext context) : IArticleRepository
    {
        public async Task<IEnumerable<Article?>> GetAllAsync(CancellationToken cancellationToken = default) => 
            await context.Articles
                .OrderByDescending(x => x.PublishedDate)
                .ToListAsync(cancellationToken: cancellationToken);
        
        
        public async Task<IEnumerable<Article?>> GetByCategoryAsync(Category category, CancellationToken cancellationToken = default) => 
            await context.Articles
                .Where(x => x.Category == category)
                .OrderByDescending(x => x.PublishedDate)
                .ToListAsync(cancellationToken: cancellationToken);
        

        public async Task<Article?> GetByIdAsync(int id, CancellationToken cancellationToken = default) =>
            await context.Articles.FindAsync(id, cancellationToken);
        

        public async Task AddAsync(Article? article, CancellationToken cancellationToken = default)
        {
            await context.Articles.AddAsync(article,  cancellationToken);
        }

        public void Update(Article? article)
        {
            context.Articles.Update(article);
        }

        public void Delete(Article? article)
        {
            context.Articles.Remove(article);
        }

        public async Task SaveAsync(CancellationToken cancellationToken = default)
        {
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}