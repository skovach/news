using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using News.Application.Dto;
using News.Application.UseCases.Command;
using News.Application.UseCases.Query;

namespace News.Api.Pages;

public class Update(IMediator mediator) : PageModel
{
    [BindProperty]
    public int ArticleId { get; set; }

    [BindProperty]
    public string Title { get; set; }

    [BindProperty]
    public string Content { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var article = await mediator.Send(new GetArticleQuery(id));

        if (article == null)
        {
            return RedirectToPage("/Manage");
        }

        ArticleId = article.Id;
        Title = article.Title;
        Content = article.Content;

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await mediator.Send(new UpdateArticleCommand(ArticleId, new ArticleUpdateDto { Title = this.Title, Content = this.Content }));
        return RedirectToPage("/Manage");
    }
}