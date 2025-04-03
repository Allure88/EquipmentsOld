using DrawingBackend.Application.Models;
using Equipment.Domain.Entities.Ports;

namespace Equipment.Application.UseCases_CQRS.Port.Queries;

public class GetPortResponce(IPort? port) : BaseResponse(port)
{
    public IPort? Port { get; } = port;
}
