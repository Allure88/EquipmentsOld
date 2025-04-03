using Equipment.Application.Contracts.Persistence;
using Equipment.Domain.Entities.Commons;
using MediatR;

namespace Equipment.Application.UseCases_CQRS.Common.Commands.Material
{
    public class PostDeleteMaterialRequest(long id) : IRequest<PostDeleteMaterialResponse>
    {
        public long Id { get; set; } = id;
    }

    public class PostDeleteMaterialResponse(long id)
    {
        public long Id { get; set; } = id;
    }

    public class PostDeleteMaterialRequestHandler(IGenericRepository<MaterialEntity> repository) : IRequestHandler<PostDeleteMaterialRequest, PostDeleteMaterialResponse>
    {
        public async Task<PostDeleteMaterialResponse> Handle(PostDeleteMaterialRequest request, CancellationToken cancellationToken)
        {
            var entity = await repository.Get(request.Id);
            if (entity != null)
            {
                await repository.Delete(entity);
                return new PostDeleteMaterialResponse(request.Id);
            }

            return new PostDeleteMaterialResponse(-1);
        }
    }
}
