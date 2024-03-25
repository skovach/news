using News.Domain.Entities;
using News.Domain.Enums;

namespace News.Persistence.Repositories
{
    public interface IArticleRepository
    {
        Task<IEnumerable<Article?>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<Article?>> GetByCategoryAsync(Category category, CancellationToken cancellationToken = default);
        Task<Article?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task AddAsync(Article? article, CancellationToken cancellationToken = default);
        void Update(Article article);
        void Delete(Article article);
        Task SaveAsync(CancellationToken cancellationToken = default);
    }
}