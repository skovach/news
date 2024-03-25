using MediatR;
using Microsoft.EntityFrameworkCore;
using News.Domain.Entities;
using News.Persistence;
using News.Persistence.Repositories;

namespace News.Application.UseCases.Query;

public class GetArticleQuery(int id) : IRequest<Article?>
{
    public int Id { get; } = id;
}

public class GetArticleQueryHandler(IArticleRepository repository) : IRequestHandler<GetArticleQuery, Article?>
{
    public Task<Article?> Handle(GetArticleQuery request, CancellationToken cancellationToken)
        => repository.GetByIdAsync(request.Id, cancellationToken);
}