using MediatR;
using Microsoft.AspNetCore.Mvc;
using News.Application.Dto;
using News.Application.UseCases.Command;
using News.Application.UseCases.Query;
using News.Domain.Entities;

namespace News.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ArticlesController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public Task<List<Article>> GetArticles() => mediator.Send(new GetArticlesQuery());

    [HttpGet("{id}")]
    public async Task<ActionResult<Article>> GetArticleById(int id)
    {
        var article = await mediator.Send(new GetArticleQuery(id));
        return article == null ? new NotFoundResult() : Ok(article);
    }
    
    [HttpPost]
    public async Task<ActionResult<Article>> CreateArticle([FromBody] ArticleDto model)
    {
        var article = await mediator.Send(new CreateArticleCommand(model));
        return Ok(article);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateArticle(int id, [FromBody] ArticleUpdateDto model)
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