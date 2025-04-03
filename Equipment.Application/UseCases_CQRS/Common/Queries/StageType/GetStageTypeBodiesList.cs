using Equipment.Application.Contracts.Persistence;
using Equipment.Domain.Entities.Commons;
using MediatR;

namespace Equipment.Application.UseCases_CQRS.Common.Queries.StageType
{
    public class GetStageTypeBodiesListRequest : IRequest<GetStageTypeBodiesListResponse> { }

    public class GetStageTypeBodiesListResponse(List<StageTypeEntity> stageTypes)
    {
        public List<StageTypeEntity> Bodies { get; set; } = stageTypes;
    }

    public class GetStageTypeBodiesListRequestHandler(IGenericRepository<StageTypeEntity> repository) : IRequestHandler<GetStageTypeBodiesListRequest, GetStageTypeBodiesListResponse>
    {
        public async Task<GetStageTypeBodiesListResponse> Handle(GetStageTypeBodiesListRequest request, CancellationToken cancellationToken)
        {
            var entity = await repository.GetAll();
            return new GetStageTypeBodiesListResponse(entity);
        }
    }
}
