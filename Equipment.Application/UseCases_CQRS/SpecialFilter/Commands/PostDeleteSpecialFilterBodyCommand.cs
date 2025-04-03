using Equipment.Application.Contracts.Persistence;
using MediatR;

namespace Equipment.Application.UseCases_CQRS.SpecialFilter.Commands
{
    public class PostDeleteSpecialFilterBodyCommand(long id) : IRequest<PostDeleteSpecialFilterBodyResponse>
    {
        public long Id { get; set; } = id;
    }

    public class PostDeleteSpecialFilterBodyResponse(long id)
    {
        public long Id { get; set; } = id;
    }

    public class PostDeleteSpecialFilterBodyCommandHandler(ISpecificFilterRepository repository) : IRequestHandler<PostDeleteSpecialFilterBodyCommand, PostDeleteSpecialFilterBodyResponse>
    {
        public async Task<PostDeleteSpecialFilterBodyResponse> Handle(PostDeleteSpecialFilterBodyCommand request, CancellationToken cancellationToken)
        {
            var entity = await repository.Get(request.Id);
            if (entity != null)
            {
                await repository.Delete(entity);
                return new PostDeleteSpecialFilterBodyResponse(request.Id);
            }

            return new PostDeleteSpecialFilterBodyResponse(-1);
        }
    }
}
