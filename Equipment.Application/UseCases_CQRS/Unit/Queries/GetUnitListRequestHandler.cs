using Equipment.Application.Contracts.Persistence;
using Equipment.Domain.Entities.Units;
using MediatR;

namespace Equipment.Application.UseCases_CQRS.Unit.Queries
{
    public class GetUnitListRequestHandler(IUnitRepository unitRepository) : IRequestHandler<GetUnitListRequest, GetUnitListResponce>
    {
        public async Task<GetUnitListResponce> Handle(GetUnitListRequest request, CancellationToken cancellationToken)
        {
            List<IUnit> coll = await unitRepository.GetAll();
            return new GetUnitListResponce(coll);
        }
    }
}
