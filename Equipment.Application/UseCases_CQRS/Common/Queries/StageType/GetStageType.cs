using AutoMapper;
using Equipment.Application.Contracts.Persistence;
using Equipment.Domain.Entities.Commons;
using MediatR;
using SharedCommon.CDB_EntityBodies;

namespace Equipment.Application.UseCases_CQRS.Common.Queries.StageType
{
    public class GetStageTypeRequest(long id) : IRequest<GetStageTypeResponse>
    {
        public long Id { get; set; } = id;
    }

    public class GetStageTypeResponse(StageTypeBody stageType)
    {
        public StageTypeBody Body { get; set; } = stageType;
    }

    public class GetStageTypeRequestHandler(IGenericRepository<StageTypeEntity> repository,
        IMapper mapper) : IRequestHandler<GetStageTypeRequest, GetStageTypeResponse>
    {
        public async Task<GetStageTypeResponse> Handle(GetStageTypeRequest request, CancellationToken cancellationToken)
        {
            var entity = await repository.Get(request.Id);
            var mappedEntity = mapper.Map<StageTypeBody>(entity);
            return new GetStageTypeResponse(mappedEntity);
        }
    }
}
