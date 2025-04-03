using MediatR;

namespace Equipment.Application.UseCases_CQRS.InlineUnit.Commands
{
    public class PostInlineUnitCommand(Domain.Entities.Units.InlineUnit unit) : IRequest<PostInlineUnitResponce>
    {
        public Domain.Entities.Units.InlineUnit Unit { get; } = unit;
    }

}
