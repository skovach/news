// ArticlesController.cs

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using News.Domain.Entities;
using News.Persistence;

namespace News.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ArticlesController(NewsDbContext context) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Article>>> GetArticles()
    {
        return await context.Articles.ToListAsync();
    }
}