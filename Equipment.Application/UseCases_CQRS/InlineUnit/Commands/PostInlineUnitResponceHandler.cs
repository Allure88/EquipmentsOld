using Equipment.Application.Contracts.Persistence;
using MediatR;

namespace Equipment.Application.UseCases_CQRS.InlineUnit.Commands
{
    public class PostInlineUnitResponceHandler(IPumpInlineUnitRepository unitRepository) : IRequestHandler<PostInlineUnitCommand, PostInlineUnitResponce>
    {
        public Task<PostInlineUnitResponce> Handle(PostInlineUnitCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

}
