using Equipment.Application.Contracts.Persistence;
using MediatR;
using System.Net;

namespace Equipment.Application.UseCases_CQRS.Port.Command;

public class PutPortResponceHandler(IPortRepository portRepository) : IRequestHandler<PutPortCommand, PutPortResponce>
{
    public async Task<PutPortResponce> Handle(PutPortCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await portRepository.Update(request.Port);
            return new PutPortResponce("Добавлено") { Success = true, StatusCode = HttpStatusCode.OK.ToString(), Message = "Added" };
        }
        catch (Exception e)
        {
            return new PutPortResponce("Не добавлено") { Success = false, StatusCode = HttpStatusCode.InternalServerError.ToString(), Message = e.ToString(), Errors = [e.ToString()] };
        }
    }
}
