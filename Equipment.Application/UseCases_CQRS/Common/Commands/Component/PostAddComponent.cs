using AutoMapper;
using Equipment.Application.Contracts.Persistence;
using Equipment.Domain.Entities;
using MediatR;
using SharedCommon.CDB_EntityBodies;

namespace Equipment.Application.UseCases_CQRS.Common.Commands.Component
{
    public class PostAddComponentRequest(ComponentBody body) : IRequest<PostAddComponentResponse>
    {
        public ComponentBody Body { get; set; } = body;
    }

    public class PostAddComponentResponse(ComponentEntity body)
    {
        public ComponentEntity Body { get; set; } = body;
    }

    public class PostAddComponentRequestHandler(IGenericRepository<ComponentEntity> repository, IMapper mapper) : IRequestHandler<PostAddComponentRequest, PostAddComponentResponse>
    {
        public async Task<PostAddComponentResponse> Handle(PostAddComponentRequest request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<ComponentEntity>(request.Body);
            var addedEntity = await repository.Add(entity);
            return new PostAddComponentResponse(addedEntity);
        }
    }
}
