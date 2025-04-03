using MediatR;

namespace Equipment.Application.UseCases_CQRS.Unit.Queries;

public class GetUnitRequest(long id) : IRequest<GetUnitResponce>
{
    public long Id { get; } = id;
}
