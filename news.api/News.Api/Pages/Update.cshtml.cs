using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using News.Application.Dto;
using News.Application.UseCases.Command;
using News.Application.UseCases.Query;
using News.Domain.Entities;

namespace News.Api.Pages;

public class Update(IMediator mediator, IMapper mapper, IHttpClientFactory httpClientFactory) : PageModel
{
    private HttpClient httpClient =>  httpClientFactory.CreateClient(nameof(Article));
    
    [BindProperty]
    public int ArticleId { get; set; }
    
    [BindProperty]
    public ArticleUpdateDto Model { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var article = await mediator.Send(new GetArticleQuery(id));

        if (article == null)
        {
            return RedirectToPage("/Manage");
        }
        ArticleId = article.Id;
        Model = mapper.Map<ArticleUpdateDto>(article);

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        using var formData = new MultipartFormDataContent();
        formData.Add(new StringContent(Model.Title), nameof(Model.Title));
        formData.Add(new StringContent(Model.Content), nameof(Model.Content));
        formData.Add(new StringContent(Model.AuthorName), nameof(Model.AuthorName));
        formData.Add(new StringContent(Model.ImageUrl ?? string.Empty), nameof(Model.ImageUrl));
        formData.Add(new StringContent(((int)Model.Category).ToString()), nameof(Model.Category));

        if (Model.ImageFile != null)
        {
            if (Model.ImageFile.Length > 0)
            {
                var streamContent = new StreamContent(Model.ImageFile.OpenReadStream());
                streamContent.Headers.ContentType = new MediaTypeHeaderValue(Model.ImageFile.ContentType);
                formData.Add(streamContent, nameof(Model.ImageFile), Model.ImageFile.FileName);
            }
        }

        var response = await httpClient.PutAsync($"{httpClient.BaseAddress.ToString()}/{ArticleId}", formData);
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Could not update article");
        }
        
        return RedirectToPage("/Manage");
    }
}