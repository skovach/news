using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using News.Application.UseCases.Query;
using News.Domain.Entities;
using News.Domain.Enums;

namespace News.Api.Pages;

public class IndexModel(IMediator mediator, IHttpClientFactory httpClientFactory) : PageModel
{
    private HttpClient httpClient =>  httpClientFactory.CreateClient(nameof(Article));
    public List<Article>? Articles { get; private set; }

    public async Task OnGetAsync(Category? category)
    {
        var url = category == null ? httpClient.BaseAddress.ToString() : $"{httpClient.BaseAddress}/category/{category}";
        var response = await httpClient.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            Articles = await response.Content.ReadFromJsonAsync<List<Article>>();
        }
    }
}