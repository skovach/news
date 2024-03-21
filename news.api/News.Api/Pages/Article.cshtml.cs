using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using News.Application.UseCases.Query;
using News.Domain.Entities;

namespace News.Api.Pages;

public class ArticleModel(IMediator mediator) : PageModel
{
    public Article Article { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Article = await mediator.Send(new GetArticleQuery(id));

        if (Article == null)
        {
            return RedirectToPage("/Index");
        }

        return Page();
    }
}