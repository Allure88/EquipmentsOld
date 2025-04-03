using DrawingBackend.Application.Models;
using Equipment.Domain.Entities.Ports;

namespace Equipment.Application.UseCases_CQRS.Port.Queries;

public class GetPortListResponce(List<IPort> port) : BaseResponse(port)
{
    public List<IPort> Ports { get; } = port;
}
