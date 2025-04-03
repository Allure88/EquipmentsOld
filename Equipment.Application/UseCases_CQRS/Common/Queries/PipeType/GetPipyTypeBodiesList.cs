using AutoMapper;
using Equipment.Application.Contracts.Persistence;
using Equipment.Domain.Entities.Commons;
using MediatR;
using SharedCommon.CDB_EntityBodies;

namespace Equipment.Application.UseCases_CQRS.Common.Queries.PipeType
{
    public class GetPipyTypeBodiesListRequest : IRequest<GetPipeTypeBodiesListResponse> { }
    public class GetPipeTypeBodiesListResponse(List<PipeTypeEntity> bodies)
    {
        public List<PipeTypeEntity> Bodies { get; set; } = bodies;
    }

    public class GetPipyTypeBodiesListRequestHandler(IGenericRepository<PipeTypeEntity> repository) : IRequestHandler<GetPipyTypeBodiesListRequest, GetPipeTypeBodiesListResponse>
    {
        public async Task<GetPipeTypeBodiesListResponse> Handle(GetPipyTypeBodiesListRequest request, CancellationToken cancellationToken)
        {
            var entity = await repository.GetAll();
            return new GetPipeTypeBodiesListResponse(entity);
        }
    }
}
