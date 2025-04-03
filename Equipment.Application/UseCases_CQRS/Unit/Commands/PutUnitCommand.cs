using Equipment.Domain.Entities.Units;
using MediatR;

namespace Equipment.Application.UseCases_CQRS.Unit.Commands
{
    public class PutUnitCommand(IUnit unit) : IRequest<PutUnitResponce>
    {
        public IUnit Unit { get; } = unit;
    }

}
