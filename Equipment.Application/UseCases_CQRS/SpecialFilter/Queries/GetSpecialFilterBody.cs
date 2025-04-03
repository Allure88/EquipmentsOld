using AutoMapper;
using Equipment.Application.Contracts.Persistence;
using MediatR;
using SharedCommon.TechSchemaDomain.PhysSchemeSubDomain.GetBodies;

namespace Equipment.Application.UseCases_CQRS.SpecialFilter.Queries
{
    public class GetSpecialFilterBodyRequest(long id) : IRequest<GetSpecialFilterBodyResponse>
    {
        public long Id { get; set; } = id;
    }

    public class GetSpecialFilterBodyResponse(PhysUnitGetBody physUnit)
    {
        public PhysUnitGetBody PhysUnit { get; set; } = physUnit;
    }

    public class GetSpecialFilterBodyRequestHandler(ISpecificFilterRepository repository, IMapper mapper) : IRequestHandler<GetSpecialFilterBodyRequest, GetSpecialFilterBodyResponse>
    {
        public async Task<GetSpecialFilterBodyResponse> Handle(GetSpecialFilterBodyRequest request, CancellationToken cancellationToken)
        {
            var entity = await repository.Get(request.Id);
            var mappedEntity = mapper.Map<PhysUnitGetBody>(entity);
            return new GetSpecialFilterBodyResponse(mappedEntity);
        }
    }
}
