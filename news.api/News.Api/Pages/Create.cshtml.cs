using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using News.Application.Dto;
using News.Application.UseCases.Command;

namespace News.Api.Pages;

public class Create(IMediator mediator) : PageModel
{
    [BindProperty]
    public ArticleDto Article { get; set; }
    
    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var article = await mediator.Send(new CreateArticleCommand(Article));

        return RedirectToPage("/Manage");
    }
}