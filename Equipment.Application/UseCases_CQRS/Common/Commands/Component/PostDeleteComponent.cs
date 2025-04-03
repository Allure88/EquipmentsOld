using Equipment.Application.Contracts.Persistence;
using Equipment.Domain.Entities;
using MediatR;

namespace Equipment.Application.UseCases_CQRS.Common.Commands.Component
{
    public class PostDeleteComponentRequest(long id) : IRequest<PostDeleteComponentResponse>
    {
        public long Id { get; set; } = id;
    }

    public class PostDeleteComponentResponse(long id)
    {
        public long Id { get; set; } = id;
    }

    public class PostDeleteComponentRequestHandler(IGenericRepository<ComponentEntity> repository) : IRequestHandler<PostDeleteComponentRequest, PostDeleteComponentResponse>
    {
        public async Task<PostDeleteComponentResponse> Handle(PostDeleteComponentRequest request, CancellationToken cancellationToken)
        {
            var entity = await repository.Get(request.Id);
            if (entity != null)
            {
                await repository.Delete(entity);
                return new PostDeleteComponentResponse(request.Id);
            }

            return new PostDeleteComponentResponse(-1);
        }
    }
}
