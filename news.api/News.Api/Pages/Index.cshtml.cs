using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using News.Application.UseCases.Query;
using News.Domain.Entities;
using News.Domain.Enums;

namespace News.Api.Pages;

public class IndexModel(IMediator mediator) : PageModel
{
    public List<Article> Articles { get; private set; }

    public async Task OnGetAsync(Category? category)
    {
        Articles = category == null 
            ? await mediator.Send(new GetArticlesQuery())
            : await mediator.Send(new GetArticlesByCategoryQuery(category!.Value));
    }
}