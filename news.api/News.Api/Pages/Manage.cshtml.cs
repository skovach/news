using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using News.Application.UseCases.Query;

namespace News.Api.Pages;

public class Manage(IMediator mediator) : PageModel
{
    public List<Domain.Entities.Article> Articles { get; private set; }

    public async Task OnGetAsync()
    {
        Articles = (await mediator.Send(new GetArticlesQuery())).ToList();
    }
}