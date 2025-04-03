using Equipment.Domain.Entities.Units;
using MediatR;

namespace Equipment.Application.UseCases_CQRS.Unit.Commands
{
    public class PostUnitCommand(IUnit unit) : IRequest<PostUnitResponce>
    {
        public IUnit Unit { get; } = unit;
    }

}
