using AutoMapper;
using Equipment.Application.Contracts.Persistence;
using Equipment.Domain.Entities.Commons;
using MediatR;
using SharedCommon.CDB_EntityBodies;

namespace Equipment.Application.UseCases_CQRS.Common.Commands.StageType
{
    public class PostAddStageTypeRequest(StageTypeBody stageType) : IRequest<PostAddStageTypeResponse>
    {
        public StageTypeBody Body { get; set; } = stageType;
    }

    public class PostAddStageTypeResponse(StageTypeEntity stageType)
    {
        public StageTypeEntity Body { get; set; } = stageType;
    }

    public class PostAddStageTypeRequestHandler(IGenericRepository<StageTypeEntity> repository, IMapper mapper) : IRequestHandler<PostAddStageTypeRequest, PostAddStageTypeResponse>
    {
        public async Task<PostAddStageTypeResponse> Handle(PostAddStageTypeRequest request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<StageTypeEntity>(request.Body);
            var addedEntity = await repository.Add(entity);
            return new PostAddStageTypeResponse(addedEntity);
        }
    }
}
