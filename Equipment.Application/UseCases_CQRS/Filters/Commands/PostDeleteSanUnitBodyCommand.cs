using Equipment.Application.Contracts.Persistence;
using MediatR;

namespace Equipment.Application.UseCases_CQRS.Filters.Commands
{
    public class PostDeleteSanUnitBodyCommand(long id) : IRequest<PostDeleteSanUnitBodyResponse>
    {
        public long Id { get; set; } = id;
    }

    public class PostDeleteSanUnitBodyResponse(long id)
    {
        public long Id { get; set; } = id;
    }

    public class PostDeleteSanUnitBodyCommandHandler(IFilterRepository repository) : IRequestHandler<PostDeleteSanUnitBodyCommand, PostDeleteSanUnitBodyResponse>
    {
        public async Task<PostDeleteSanUnitBodyResponse> Handle(PostDeleteSanUnitBodyCommand request, CancellationToken cancellationToken)
        {
            var entity = await repository.Get(request.Id);
            if (entity != null)
            {
                await repository.Delete(entity);
                return new PostDeleteSanUnitBodyResponse(request.Id);
            }

            return new PostDeleteSanUnitBodyResponse(-1);
        }
    }
}
