using DrawingBackend.Application.Models;
using Equipment.Domain.Entities.Units;

namespace Equipment.Application.UseCases_CQRS.Unit.Queries;

public class GetUnitListResponce(List<IUnit> units) : BaseResponse(units)
{
    public List<IUnit> Units { get; } = units;
}
