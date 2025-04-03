using AutoMapper;
using Equipment.Application.Contracts.Persistence;
using Equipment.Domain.Entities.Commons;
using MediatR;
using SharedCommon.CDB_EntityBodies;

namespace Equipment.Application.UseCases_CQRS.Common.Commands.Diametr
{
    public class PostAddDiametrRequest(DiametrBody body) : IRequest<PostAddDiametrResponse>
    {
        public DiametrBody Body { get; set; } = body;
    }

    public class PostAddDiametrResponse(DiametrEntity body)
    {
        public DiametrEntity Body { get; set; } = body;
    }

    public class PostAddDiametrRequestHandler(IGenericRepository<DiametrEntity> repository, IMapper mapper) : IRequestHandler<PostAddDiametrRequest, PostAddDiametrResponse>
    {
        public async Task<PostAddDiametrResponse> Handle(PostAddDiametrRequest request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<DiametrEntity>(request.Body);
            var adddedEntity = await repository.Add(entity);
            return new PostAddDiametrResponse(adddedEntity);
        }
    }
}
