using Equipment.Application.Contracts.Persistence;
using Equipment.Domain.Entities.Ports;
using MediatR;

namespace Equipment.Application.UseCases_CQRS.Port.Queries;

public class GetPortRequestHandler(IPortRepository PortRepository) : IRequestHandler<GetPortRequest, GetPortResponce>
{
    public async Task<GetPortResponce> Handle(GetPortRequest request, CancellationToken cancellationToken)
    {
        var Port = await PortRepository.Get(request.Id);
        return new GetPortResponce(Port);
    }
}
