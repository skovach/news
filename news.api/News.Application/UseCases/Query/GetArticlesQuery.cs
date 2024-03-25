using MediatR;
using Microsoft.EntityFrameworkCore;
using News.Domain.Entities;
using News.Persistence;
using News.Persistence.Repositories;

namespace News.Application.UseCases.Query;

public class GetArticlesQuery : IRequest<IEnumerable<Article>>
{
}

public class GetArticlesQueryHandler(IArticleRepository repository) : IRequestHandler<GetArticlesQuery, IEnumerable<Article>>
{
    public async Task<IEnumerable<Article?>> Handle(GetArticlesQuery request, CancellationToken cancellationToken)
        => await repository.GetAllAsync(cancellationToken);
}