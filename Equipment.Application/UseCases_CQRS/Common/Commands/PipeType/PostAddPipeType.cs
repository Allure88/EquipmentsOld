using AutoMapper;
using Equipment.Application.Contracts.Persistence;
using Equipment.Domain.Entities.Commons;
using MediatR;
using SharedCommon.CDB_EntityBodies;

namespace Equipment.Application.UseCases_CQRS.Common.Commands.PipeType
{
    public class PostAddPipeTypeRequest(PipeTypeBody body) : IRequest<PostAddPipeTypeResponse>
    {
        public PipeTypeBody Body { get; set; } = body;
    }

    public class PostAddPipeTypeResponse(PipeTypeEntity body)
    {
        public PipeTypeEntity Body { get; set; } = body;
    }

    public class PostAddPipeTypeRequestHandler(IGenericRepository<PipeTypeEntity> repository, IMapper mapper) : IRequestHandler<PostAddPipeTypeRequest, PostAddPipeTypeResponse>
    {
        public async Task<PostAddPipeTypeResponse> Handle(PostAddPipeTypeRequest request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<PipeTypeEntity>(request.Body);
            var addedEntity = await repository.Add(entity);
            return new PostAddPipeTypeResponse(addedEntity);
        }
    }
}
