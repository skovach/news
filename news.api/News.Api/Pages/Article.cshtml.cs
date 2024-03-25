using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using News.Application.UseCases.Query;
using News.Domain.Entities;

namespace News.Api.Pages;

public class ArticleModel(IMediator mediator, IHttpClientFactory httpClientFactory) : PageModel
{
    private HttpClient httpClient =>  httpClientFactory.CreateClient(nameof(Article));
    public Article? Article { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var response = await httpClient.GetAsync($"{httpClient.BaseAddress}/{id}");
        if (response.IsSuccessStatusCode)
        {
            Article = await response.Content.ReadFromJsonAsync<Article>();
        }

        if (Article == null)
        {
            return RedirectToPage("/Index");
        }

        return Page();
    }
}