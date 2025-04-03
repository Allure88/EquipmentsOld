using AutoMapper;
using Equipment.Application.Contracts.Persistence;
using Equipment.Domain.Entities.Commons;
using MediatR;
using SharedCommon.CDB_EntityBodies;

namespace Equipment.Application.UseCases_CQRS.Common.Commands.Material
{
    public class PostAddMaterialRequest(MaterialBody body) : IRequest<PostAddMaterialResponse>
    {
        public MaterialBody Body { get; set; } = body;
    }

    public class PostAddMaterialResponse(MaterialEntity body)
    {
        public MaterialEntity Body { get; set; } = body;
    }

    public class PostAddMaterialRequestHandler(IGenericRepository<MaterialEntity> repository, IMapper mapper) : IRequestHandler<PostAddMaterialRequest, PostAddMaterialResponse>
    {
        public async Task<PostAddMaterialResponse> Handle(PostAddMaterialRequest request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<MaterialEntity>(request.Body);
            var addedEntity = await repository.Add(entity);
            return new PostAddMaterialResponse(addedEntity);
        }
    }
}
