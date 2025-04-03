using Equipment.Application.Contracts.Persistence;
using Equipment.Domain.Entities.Units;
using MediatR;
using SharedCommon.Responces;

namespace Equipment.Application.UseCases_CQRS.InlineUnit.Queries;

#region RqRs
public class GetPumpInlineUnitRequest(long id) : IRequest<GetPumpInlineUnitResponce>
{
    public long Id { get; } = id;
}

public class GetPumpInlineUnitResponce(PumpInlineUnitEntity? unit) : BaseResponse(unit)
{
    public PumpInlineUnitEntity? Unit { get; } = unit;
} 
#endregion

public class GetPumpInlineUnitRequestHandler(IPumpInlineUnitRepository unitRepository) : IRequestHandler<GetPumpInlineUnitRequest, GetPumpInlineUnitResponce>
{
    public async Task<GetPumpInlineUnitResponce> Handle(GetPumpInlineUnitRequest request, CancellationToken cancellationToken)
    {
        var unit = await unitRepository.Get(request.Id);
        return new GetPumpInlineUnitResponce(unit);
    }
}
