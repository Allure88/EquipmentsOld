using AutoMapper;
using Equipment.Application.Contracts.Persistence;
using Equipment.Domain.Entities;
using MediatR;
using SharedCommon.CDB_EntityBodies;

namespace Equipment.Application.UseCases_CQRS.Common.Queries.Component
{
    public class GetComponentBodiesListRequest() : IRequest<GetComponentBodiesListResponse> { }

    public class GetComponentBodiesListResponse(List<ComponentEntity> bodies)
    {
        public List<ComponentEntity> Bodies { get; set; } = bodies;
    }

    public class GetComponentBodiesListRequestHandler(IGenericRepository<ComponentEntity> repository) : IRequestHandler<GetComponentBodiesListRequest, GetComponentBodiesListResponse>
    {
        public async Task<GetComponentBodiesListResponse> Handle(GetComponentBodiesListRequest request, CancellationToken cancellationToken)
        {
            var entity = await repository.GetAll();
            return new GetComponentBodiesListResponse(entity);
        }
    }
}
