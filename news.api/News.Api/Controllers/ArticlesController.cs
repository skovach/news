using MediatR;
using Microsoft.AspNetCore.Mvc;
using News.Application.Dto;
using News.Application.UseCases.Command;
using News.Application.UseCases.Query;
using News.Domain.Entities;
using News.Domain.Enums;

namespace News.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ArticlesController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public Task<IEnumerable<Article>> GetArticles([FromQuery] Category category) => mediator.Send(new GetArticlesQuery());

    [HttpGet("{id}")]
    public async Task<ActionResult<Article>> GetArticleById(int id)
    {
        var article = await mediator.Send(new GetArticleQuery(id));
        return article == null ? new NotFoundResult() : Ok(article);
    }
    
    [HttpGet("category/{category}")]
    public async Task<IEnumerable<Article>> GetArticleById(Category category) =>
        await mediator.Send(new GetArticlesByCategoryQuery(category));

    
    [HttpPost]
    public async Task<ActionResult<Article>> CreateArticle([FromForm] ArticleDto model)
    {
        var article = await mediator.Send(new CreateArticleCommand(model));
        return Ok(article);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateArticle(int id, [FromForm] ArticleUpdateDto model)
    {
        var result = await mediator.Send(new UpdateArticleCommand(id, model));

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteArticle(int id)
    {
        var command = new DeleteArticleCommand(id);
        var result = await mediator.Send(new DeleteArticleCommand(id));

        if (!result)
        {
            return NotFound();
        }

        return Ok();
    }
}