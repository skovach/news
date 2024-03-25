using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using News.Application.Dto;
using News.Application.UseCases.Command;
using News.Domain.Entities;

namespace News.Api.Pages;

public class Create(IMediator mediator, IHttpClientFactory httpClientFactory) : PageModel
{
    private HttpClient httpClient =>  httpClientFactory.CreateClient(nameof(Article));
    
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

        using var formData = new MultipartFormDataContent();
        formData.Add(new StringContent(Article.Title), nameof(Article.Title));
        formData.Add(new StringContent(Article.Content), nameof(Article.Content));
        formData.Add(new StringContent(Article.AuthorName), nameof(Article.AuthorName));
        formData.Add(new StringContent(((int)Article.Category).ToString()), nameof(Article.Category));

        if (Article.ImageFile != null)
        {
            if (Article.ImageFile.Length > 0)
            {
                var streamContent = new StreamContent(Article.ImageFile.OpenReadStream());
                streamContent.Headers.ContentType = new MediaTypeHeaderValue(Article.ImageFile.ContentType);
                formData.Add(streamContent, nameof(Article.ImageFile), Article.ImageFile.FileName);
            }
        }

        var response = await httpClient.PostAsync(httpClient.BaseAddress.ToString(), formData);
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Could not create article");
        }

        return RedirectToPage("/Manage");
    }
}