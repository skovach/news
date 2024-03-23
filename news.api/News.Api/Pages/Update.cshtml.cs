using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using News.Application.Dto;
using News.Application.UseCases.Command;
using News.Application.UseCases.Query;
using News.Domain.Entities;

namespace News.Api.Pages;

public class Update(IMediator mediator, IMapper mapper) : PageModel
{
    [BindProperty]
    public int ArticleId { get; set; }
    
    [BindProperty]
    public ArticleUpdateDto Article { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var article = await mediator.Send(new GetArticleQuery(id));

        if (article == null)
        {
            return RedirectToPage("/Manage");
        }

        Article = mapper.Map<ArticleUpdateDto>(article);

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await mediator.Send(new UpdateArticleCommand(ArticleId, Article));
        return RedirectToPage("/Manage");
    }
}