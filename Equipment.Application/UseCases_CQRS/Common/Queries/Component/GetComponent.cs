using AutoMapper;
using Equipment.Application.Contracts.Persistence;
using Equipment.Domain.Entities;
using MediatR;
using SharedCommon.CDB_EntityBodies;

namespace Equipment.Application.UseCases_CQRS.Common.Queries.Component
{
    public class GetComponentRequest(long id) : IRequest<GetComponentResponse>
    {
        public long Id { get; set; } = id;
    }

    public class GetComponentResponse(ComponentBody body)
    {
        public ComponentBody Body { get; set; } = body;
    }

    public class GetComponentRequestHandler(IGenericRepository<ComponentEntity> repository, IMapper mapper) : IRequestHandler<GetComponentRequest, GetComponentResponse>
    {
        public async Task<GetComponentResponse> Handle(GetComponentRequest request, CancellationToken cancellationToken)
        {
            var entity = await repository.Get(request.Id);
            var mappedEntity = mapper.Map<ComponentBody>(entity);
            return new GetComponentResponse(mappedEntity);
        }
    }
}
