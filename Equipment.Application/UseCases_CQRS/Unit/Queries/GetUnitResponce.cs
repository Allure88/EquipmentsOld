using DrawingBackend.Application.Models;
using Equipment.Domain.Entities.Units;

namespace Equipment.Application.UseCases_CQRS.Unit.Queries;

public class GetUnitResponce(IUnit? unit) : BaseResponse(unit)
{
    public IUnit? Unit { get; } = unit;
}
