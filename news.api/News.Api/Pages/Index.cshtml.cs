using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using News.Application.UseCases.Query;
using News.Domain.Entities;

namespace News.Api.Pages;

public class IndexModel(IMediator mediator) : PageModel
{
    public List<Domain.Entities.Article> Articles { get; private set; }

    public async Task OnGetAsync()
    {
        Articles = await mediator.Send(new GetArticlesQuery());
    }
}