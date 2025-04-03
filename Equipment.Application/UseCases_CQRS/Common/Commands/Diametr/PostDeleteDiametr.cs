using Equipment.Application.Contracts.Persistence;
using Equipment.Domain.Entities.Commons;
using MediatR;

namespace Equipment.Application.UseCases_CQRS.Common.Commands.Diametr
{
    public class PostDeleteDiametrRequest(long id) : IRequest<PostDeleteDiametrResponse>
    {
        public long Id { get; set; } = id;
    }

    public class PostDeleteDiametrResponse(long id)
    {
        public long Id { get; set; } = id;
    }

    public class PostDeleteDiametrRequestHandler(IGenericRepository<DiametrEntity> repository) : IRequestHandler<PostDeleteDiametrRequest, PostDeleteDiametrResponse>
    {
        public async Task<PostDeleteDiametrResponse> Handle(PostDeleteDiametrRequest request, CancellationToken cancellationToken)
        {
            var entity = await repository.Get(request.Id);
            if (entity != null)
            {
                await repository.Delete(entity);
                return new PostDeleteDiametrResponse(request.Id);
            }

            return new PostDeleteDiametrResponse(-1);
        }
    }
}
