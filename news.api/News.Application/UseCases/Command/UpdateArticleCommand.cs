using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using News.Application.Dto;
using News.Domain.Entities;
using News.Persistence;

namespace News.Application.UseCases.Command;

public class UpdateArticleCommand(int id, ArticleUpdateDto model) : IRequest<Article?>
{
    public int Id { get; } = id;
    public ArticleUpdateDto Model { get; } = model;
}

public class UpdateArticleCommandHandler(NewsDbContext context) : IRequestHandler<UpdateArticleCommand, Article?>
{
    public async Task<Article?> Handle(UpdateArticleCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var article = await context.Articles.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);

            if (article == null)
            {
                return null;
            }

            article.Title = request.Model.Title;
            article.Content = request.Model.Content;
            
            context.Articles.Update(article);
            await context.SaveChangesAsync(cancellationToken);

            return article;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

    }
}