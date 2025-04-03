using Equipment.Application.Adapters;
using Equipment.Application.Contracts.Persistence;
using Equipment.Domain.Entities.Units;
using MediatR;
using SharedCommon.Responces;
using SharedCommon.TechSchemaDomain;

namespace Equipment.Application.UseCases_CQRS.Filters.Queries
{
    #region RqRs
    public class GetFilterBodiesListRequest : IRequest<GetFilterBodiesListResponce> { }
    public class GetFilterBodiesListResponce(List<FilterUnitBody> units)
    {
        public List<SanUnitBody> Units { get; } = [..units];
    }
    #endregion

    public class GetFilterBodiesListRequestHandler(IFilterRepository filterRepository) : IRequestHandler<GetFilterBodiesListRequest, GetFilterBodiesListResponce>
    {
        public async Task<GetFilterBodiesListResponce> Handle(GetFilterBodiesListRequest request, CancellationToken cancellationToken)
        {
            List<FilterUnitEntity> entities = await filterRepository.GetAll();

            var bodies = entities.Select(e => e.ToFilterBody()).ToList();

            return new GetFilterBodiesListResponce(bodies);
        }
    }

}
