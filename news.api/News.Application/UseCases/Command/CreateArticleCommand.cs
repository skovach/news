using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using News.Application.Dto;
using News.Domain.Entities;
using News.Infrastructure.Interfaces;
using News.Persistence;
using News.Persistence.Repositories;

namespace News.Application.UseCases.Command;

public class CreateArticleCommand(ArticleDto model) : IRequest<Article>
{
    public ArticleDto Model { get; } = model;
}

public class CreateArticleCommandHandler(IBlobStorageService blobStorageService, IArticleRepository repository, IMapper mapper, ILogger<CreateArticleCommandHandler> logger) : IRequestHandler<CreateArticleCommand, Article>
{
    public async Task<Article> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var newArticle = mapper.Map<Article>(request.Model);
            newArticle.PublishedDate = DateTimeOffset.UtcNow;

            newArticle.ImageUrl = await blobStorageService.UploadImageAsync(request.Model.ImageFile);

            await repository.AddAsync(newArticle, cancellationToken);
            await repository.SaveAsync(cancellationToken);

            return newArticle;
        }
        catch (Exception e)
        {
            logger.LogError(e.Message);
            throw;
        }

    }
}