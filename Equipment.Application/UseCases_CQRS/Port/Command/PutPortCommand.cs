using Equipment.Domain.Entities.Ports;
using MediatR;

namespace Equipment.Application.UseCases_CQRS.Port.Command;

public class PutPortCommand(IPort port) : IRequest<PutPortResponce>
{
    public IPort Port { get; } = port;
}
