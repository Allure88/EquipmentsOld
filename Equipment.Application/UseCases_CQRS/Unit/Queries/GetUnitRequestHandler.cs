using Equipment.Application.Contracts.Persistence;
using MediatR;

namespace Equipment.Application.UseCases_CQRS.Unit.Queries;

public class GetUnitRequestHandler(IUnitRepository unitRepository) : IRequestHandler<GetUnitRequest, GetUnitResponce>
{
    public async Task<GetUnitResponce> Handle(GetUnitRequest request, CancellationToken cancellationToken)
    {
        var unit = await unitRepository.Get(request.Id);
        return new GetUnitResponce(unit);
    }
}
