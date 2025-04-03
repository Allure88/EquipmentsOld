using Equipment.Application.Contracts.Persistence;
using MediatR;

namespace Equipment.Application.UseCases_CQRS.Unit.Commands
{
    public class PostUnitResponceHandler(IUnitRepository unitRepository) : IRequestHandler<PostUnitCommand, PostUnitResponce>
    {
        public Task<PostUnitResponce> Handle(PostUnitCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

}
