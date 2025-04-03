using AutoMapper;
using Equipment.Application.Contracts.Persistence;
using Equipment.Domain.Entities.Commons;
using MediatR;
using SharedCommon.CDB_EntityBodies;

namespace Equipment.Application.UseCases_CQRS.Common.Queries.Material
{
    public class GetMaterialBodiesListRequest : IRequest<GetMaterialBodiesListResponse> {}

    public class GetMaterialBodiesListResponse(List<MaterialEntity> bodies)
    {
        public List<MaterialEntity> Bodies { get; set; } = bodies;
    }

    public class GetMaterialBodiesListRequestHandler(IGenericRepository<MaterialEntity> repository) : IRequestHandler<GetMaterialBodiesListRequest, GetMaterialBodiesListResponse>
    {
        public async Task<GetMaterialBodiesListResponse> Handle(GetMaterialBodiesListRequest request, CancellationToken cancellationToken)
        {
            var entity = await repository.GetAll();
            return new GetMaterialBodiesListResponse(entity);
        }
    }
}
