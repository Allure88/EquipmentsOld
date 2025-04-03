using Equipment.Application.Adapters;
using Equipment.Application.Contracts.Persistence;
using MediatR;
using SharedCommon.TechSchemaDomain;

namespace Equipment.Application.UseCases_CQRS.Filters.Queries
{
    public class GetFilterBodyRequest(long id) : IRequest<GetFilterBodyResponse>
    {
        public long Id { get; set; } = id;
    }

    public class GetFilterBodyResponse(FilterUnitBody? body)
    {
        public FilterUnitBody? Body { get; set; } = body;
    }

    public class GetFilterBodyRequestHandler(IFilterRepository repository) : IRequestHandler<GetFilterBodyRequest, GetFilterBodyResponse>
    {
        public async Task<GetFilterBodyResponse> Handle(GetFilterBodyRequest request, CancellationToken cancellationToken)
        {
            var entity = await repository.Get(request.Id);
            var mappedEntity = entity?.ToFilterBody();
            return new GetFilterBodyResponse(mappedEntity);
        }
    }
}
