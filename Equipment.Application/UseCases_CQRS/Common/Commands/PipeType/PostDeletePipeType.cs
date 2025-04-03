using Equipment.Application.Contracts.Persistence;
using Equipment.Domain.Entities.Commons;
using MediatR;

namespace Equipment.Application.UseCases_CQRS.Common.Commands.PipeType
{
    public class PostDeletePipeTypeRequest(long id) : IRequest<PostDeletePipeTypeResponse>
    {
        public long Id { get; set; } = id;
    }

    public class PostDeletePipeTypeResponse(long id)
    {
        public long Id { get; set; } = id;
    }

    public class PostDeletePipeTypeRequestHandler(IGenericRepository<PipeTypeEntity> repository) : IRequestHandler<PostDeletePipeTypeRequest, PostDeletePipeTypeResponse>
    {
        public async Task<PostDeletePipeTypeResponse> Handle(PostDeletePipeTypeRequest request, CancellationToken cancellationToken)
        {
            var entity = await repository.Get(request.Id);
            if (entity != null)
            {
                await repository.Delete(entity);
                return new PostDeletePipeTypeResponse(request.Id);
            }

            return new PostDeletePipeTypeResponse(-1);
        }
    }
}
