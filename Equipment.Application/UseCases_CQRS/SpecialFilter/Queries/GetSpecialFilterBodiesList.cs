using AutoMapper;
using Equipment.Application.Contracts.Persistence;
using Equipment.Domain.Entities.Units;
using MediatR;
using SharedCommon.Responces;
using SharedCommon.TechSchemaDomain.PhysSchemeSubDomain.GetBodies;

namespace Equipment.Application.UseCases_CQRS.SpecialFilter.Queries
{
    public class GetSpecialFilterBodiesListRequest : IRequest<GetSpecialFilterBodiesListResponce> { }

    public class GetSpecialFilterBodiesListResponce(List<PhysUnitGetBody> units)
    {
        public List<PhysUnitGetBody> Units { get; } = units;
    }

    public class GetSpecialFilterBodiesListRequestHandler(ISpecificFilterRepository filterRepository, IMapper mapper) : IRequestHandler<GetSpecialFilterBodiesListRequest, GetSpecialFilterBodiesListResponce>
    {
        public async Task<GetSpecialFilterBodiesListResponce> Handle(GetSpecialFilterBodiesListRequest request, CancellationToken cancellationToken)
        {
            List<SpecificFilterEntity> entities = await filterRepository.GetAll();

            var mappedEntities = entities.Select(sfe => mapper.Map<PhysUnitGetBody>(sfe)).ToList();
            return new GetSpecialFilterBodiesListResponce(mappedEntities);
        }
    }
}
