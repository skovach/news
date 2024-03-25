using MediatR;
using Microsoft.EntityFrameworkCore;
using News.Domain.Entities;
using News.Domain.Enums;
using News.Persistence;
using News.Persistence.Repositories;

namespace News.Application.UseCases.Query;

public class GetArticlesByCategoryQuery(Category category) : IRequest<IEnumerable<Article>>
{
    public Category Category { get; } = category;
}

public class GetArticlesByCategoryQueryHandler(IArticleRepository repository) : IRequestHandler<GetArticlesByCategoryQuery, IEnumerable<Article>>
{
    public async Task<IEnumerable<Article?>> Handle(GetArticlesByCategoryQuery request, CancellationToken cancellationToken)
        => await repository.GetByCategoryAsync(request.Category, cancellationToken);
}