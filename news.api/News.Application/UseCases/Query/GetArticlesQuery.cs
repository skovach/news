using MediatR;
using Microsoft.EntityFrameworkCore;
using News.Domain.Entities;
using News.Persistence;

namespace News.Application.UseCases.Query;

public class GetArticlesQuery : IRequest<List<Article>>
{
}

public class GetArticlesQueryHandler(NewsDbContext context) : IRequestHandler<GetArticlesQuery, List<Article>>
{
    public Task<List<Article>> Handle(GetArticlesQuery request, CancellationToken cancellationToken)
        => context.Articles
            .OrderByDescending(x => x.PublishedDate)
            .ToListAsync(cancellationToken);
}