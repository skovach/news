using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using News.Application.Dto;
using News.Domain.Entities;
using News.Infrastructure.Interfaces;
using News.Persistence;

namespace News.Application.UseCases.Command;

public class CreateArticleCommand(ArticleDto model) : IRequest<Article>
{
    public ArticleDto Model { get; } = model;
}

public class CreateArticleCommandHandler(IBlobStorageService blobStorageService, NewsDbContext context, IMapper mapper, ILogger<CreateArticleCommandHandler> logger) : IRequestHandler<CreateArticleCommand, Article>
{
    public async Task<Article> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var newArticle = mapper.Map<Article>(request.Model);
            newArticle.PublishedDate = DateTimeOffset.UtcNow;

            newArticle.ImageUrl = await blobStorageService.UploadImageAsync(request.Model.ImageFile);

            context.Articles.Add(newArticle);
            await context.SaveChangesAsync(cancellationToken);

            return newArticle;
        }
        catch (Exception e)
        {
            logger.LogError(e.Message);
            throw;
        }

    }
}