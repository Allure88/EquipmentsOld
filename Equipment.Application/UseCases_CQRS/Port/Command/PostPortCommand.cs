using Equipment.Domain.Entities.Ports;
using MediatR;

namespace Equipment.Application.UseCases_CQRS.Port.Command;

public class PostPortCommand(IPort port) : IRequest<PostPortResponce>
{
    public IPort Port { get; } = port;
}
