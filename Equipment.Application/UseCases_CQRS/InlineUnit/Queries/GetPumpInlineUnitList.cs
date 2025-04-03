using Equipment.Application.Contracts.Persistence;
using Equipment.Domain.Entities.Units;
using MediatR;
using SharedCommon.Responces;

namespace Equipment.Application.UseCases_CQRS.InlineUnit.Queries
{
    #region RqRs
    public class GetPumpInlineUnitListRequest : IRequest<GetPumpInlineUnitListResponce> { }
    public class GetPumpInlineUnitListResponce(List<PumpInlineUnitEntity> units) : BaseResponse(units)
    {
        public List<PumpInlineUnitEntity> Units { get; } = units;
    } 
    #endregion

    public class GetPumpInlineUnitListRequestHandler(IPumpInlineUnitRepository unitRepository) : IRequestHandler<GetPumpInlineUnitListRequest, GetPumpInlineUnitListResponce>
    {
        public async Task<GetPumpInlineUnitListResponce> Handle(GetPumpInlineUnitListRequest request, CancellationToken cancellationToken)
        {
            var coll = await unitRepository.GetAll();
            return new GetPumpInlineUnitListResponce(coll);
        }
    }

}
