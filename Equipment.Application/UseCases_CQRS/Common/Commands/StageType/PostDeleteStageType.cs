using Equipment.Application.Contracts.Persistence;
using Equipment.Domain.Entities.Commons;
using MediatR;

namespace Equipment.Application.UseCases_CQRS.Common.Commands.StageType
{
    public class PostDeleteStageTypeRequest(long id) : IRequest<PostDeleteStageTypeResponse>
    {
        public long Id { get; set; } = id;
    }

    public class PostDeleteStageTypeResponse(long id)
    {
        public long Id { get; set; } = id;
    }

    public class PostDeleteStageTypeRequestHandler(IGenericRepository<StageTypeEntity> repository) : IRequestHandler<PostDeleteStageTypeRequest, PostDeleteStageTypeResponse>
    {
        public async Task<PostDeleteStageTypeResponse> Handle(PostDeleteStageTypeRequest request, CancellationToken cancellationToken)
        {
            var entity = await repository.Get(request.Id);
            if (entity != null)
            {
                await repository.Delete(entity);
                return new PostDeleteStageTypeResponse(request.Id);
            }

            return new PostDeleteStageTypeResponse(-1);
        }
    }
}
