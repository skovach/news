using MediatR;
using Microsoft.EntityFrameworkCore;
using News.Domain.Entities;
using News.Persistence;

namespace News.Application.UseCases.Query;

public class GetArticleQuery(int id) : IRequest<Article?>
{
    public int Id { get; } = id;
}

public class GetArticleQueryHandler(NewsDbContext context) : IRequestHandler<GetArticleQuery, Article?>
{
    public Task<Article?> Handle(GetArticleQuery request, CancellationToken cancellationToken)
        => context.Articles.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
}