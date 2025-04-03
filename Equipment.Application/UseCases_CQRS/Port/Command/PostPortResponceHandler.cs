using Equipment.Application.Contracts.Persistence;
using MediatR;

namespace Equipment.Application.UseCases_CQRS.Port.Command;

public class PostPortResponceHandler(IPortRepository portRepository) : IRequestHandler<PostPortCommand, PostPortResponce>
{
    public Task<PostPortResponce> Handle(PostPortCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
