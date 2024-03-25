using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using News.Persistence;
using News.Persistence.Repositories;

namespace News.Application.UseCases.Command;

public class DeleteArticleCommand(int id) : IRequest<bool>
{
    public int Id { get; } = id;
}

public class DeleteArticleCommandHandler(IArticleRepository repository, ILogger<DeleteArticleCommandHandler> logger) : IRequestHandler<DeleteArticleCommand, bool>
{
    public async Task<bool> Handle(DeleteArticleCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var article = await repository.GetByIdAsync(request.Id, cancellationToken: cancellationToken);

            if (article == null)
            {
                return false;
            }

            repository.Delete(article);
            await repository.SaveAsync(cancellationToken);

            return true;
        }
        catch (Exception e)
        {
            logger.LogError(e.Message);
            throw;
        }

    }
}