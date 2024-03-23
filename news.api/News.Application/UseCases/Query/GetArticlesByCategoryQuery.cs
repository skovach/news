using MediatR;
using Microsoft.EntityFrameworkCore;
using News.Domain.Entities;
using News.Domain.Enums;
using News.Persistence;

namespace News.Application.UseCases.Query;

public class GetArticlesByCategoryQuery(Category category) : IRequest<List<Article>>
{
    public Category Category { get; } = category;
}

public class GetArticlesByCategoryQueryHandler(NewsDbContext context) : IRequestHandler<GetArticlesByCategoryQuery, List<Article>>
{
    public Task<List<Article>> Handle(GetArticlesByCategoryQuery request, CancellationToken cancellationToken)
        => context.Articles
            .Where(x => x.Category == request.Category)
            .OrderByDescending(x => x.PublishedDate)
            .ToListAsync(cancellationToken);
}