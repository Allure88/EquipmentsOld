using AutoMapper;
using Equipment.Application.Contracts.Persistence;
using Equipment.Domain.Entities.Commons;
using MediatR;
using SharedCommon.CDB_EntityBodies;

namespace Equipment.Application.UseCases_CQRS.Common.Queries.Material
{
    public class GetMaterialRequest(long id) : IRequest<GetMaterialResponse>
    {
        public long Id { get; set; } = id;
    }

    public class GetMaterialResponse(MaterialBody body)
    {
        public MaterialBody Body { get; set; } = body;
    }

    public class GetMaterialRequestHandler(IGenericRepository<MaterialEntity> repository, IMapper mapper) : IRequestHandler<GetMaterialRequest, GetMaterialResponse>
    {
        public async Task<GetMaterialResponse> Handle(GetMaterialRequest request, CancellationToken cancellationToken)
        {
            var entity = await repository.Get(request.Id);
            var mappedEntity = mapper.Map<MaterialBody>(entity);
            return new GetMaterialResponse(mappedEntity);
        }
    }
}
