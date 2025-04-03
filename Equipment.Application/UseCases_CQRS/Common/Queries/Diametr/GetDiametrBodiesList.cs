using AutoMapper;
using Equipment.Application.Contracts.Persistence;
using Equipment.Domain.Entities.Commons;
using MediatR;
using SharedCommon.CDB_EntityBodies;

namespace Equipment.Application.UseCases_CQRS.Common.Queries.Diametr
{
    public class GetDiametrBodiesListRequest : IRequest<GetDiametrBodiesListResponse> { }

    public class GetDiametrBodiesListResponse(List<DiametrEntity> bodies)
    {
        public List<DiametrEntity> Bodies { get; set; } = bodies;
    }

    public class GetDiametrBodiesListRequestHandler(IGenericRepository<DiametrEntity> repository) : IRequestHandler<GetDiametrBodiesListRequest, GetDiametrBodiesListResponse>
    {
        public async Task<GetDiametrBodiesListResponse> Handle(GetDiametrBodiesListRequest request, CancellationToken cancellationToken)
        {
            var entity = await repository.GetAll();
            return new GetDiametrBodiesListResponse(entity);
        }
    }
}
