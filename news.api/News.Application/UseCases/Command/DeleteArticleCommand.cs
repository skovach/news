using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using News.Persistence;

namespace News.Application.UseCases.Command;

public class DeleteArticleCommand(int id) : IRequest<bool>
{
    public int Id { get; } = id;
}

public class DeleteArticleCommandHandler(NewsDbContext context, ILogger<DeleteArticleCommandHandler> logger) : IRequestHandler<DeleteArticleCommand, bool>
{
    public async Task<bool> Handle(DeleteArticleCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var article = await context.Articles.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);

            if (article == null)
            {
                return false;
            }

            context.Articles.Remove(article);
            await context.SaveChangesAsync(cancellationToken);

            return true;
        }
        catch (Exception e)
        {
            logger.LogError(e.Message);
            throw;
        }

    }
}