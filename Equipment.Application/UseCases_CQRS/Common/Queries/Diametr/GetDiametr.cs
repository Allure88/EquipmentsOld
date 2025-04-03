using AutoMapper;
using Equipment.Application.Contracts.Persistence;
using Equipment.Domain.Entities.Commons;
using MediatR;
using SharedCommon.CDB_EntityBodies;

namespace Equipment.Application.UseCases_CQRS.Common.Queries.Diametr
{
    public class GetDiametrRequest(long id) : IRequest<GetDiametrResponse>
    {
        public long Id { get; set; } = id;
    }

    public class GetDiametrResponse(DiametrBody body)
    {
        public DiametrBody Body { get; set; } = body;
    }

    public class GetDiametrRequestHandler(IGenericRepository<DiametrEntity> repository, IMapper mapper) : IRequestHandler<GetDiametrRequest, GetDiametrResponse>
    {
        public async Task<GetDiametrResponse> Handle(GetDiametrRequest request, CancellationToken cancellationToken)
        {
            var entity = await repository.Get(request.Id);
            var mappedEntity = mapper.Map<DiametrBody>(entity);
            return new GetDiametrResponse(mappedEntity);
        }
    }
}
