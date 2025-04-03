using MediatR;

namespace Equipment.Application.UseCases_CQRS.Port.Queries;

public class GetPortRequest(long id) : IRequest<GetPortResponce>
{
    public long Id { get; } = id;
}
