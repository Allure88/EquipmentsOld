using Equipment.Application.Contracts.Persistence;
using MediatR;
using System.Net;

namespace Equipment.Application.UseCases_CQRS.Unit.Commands
{
    public class PutUnitResponceHandler(IUnitRepository unitRepository) : IRequestHandler<PutUnitCommand, PutUnitResponce>
    {
        public async  Task<PutUnitResponce> Handle(PutUnitCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await unitRepository.Update(request.Unit);
                return new PutUnitResponce("Updated") { Success = true, StatusCode = HttpStatusCode.OK.ToString() };
            }
            catch (Exception ex)
            {

                return new PutUnitResponce("Updated") { Success = false, StatusCode = HttpStatusCode.InternalServerError.ToString() , Message = ex.ToString()};
            }
        }
    }

}
