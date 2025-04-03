using Equipment.Application.Contracts.Persistence;
using MediatR;

namespace Equipment.Application.UseCases_CQRS.Port.Queries;

public class GetPortListRequestHandler(IPortRepository PortRepository) : IRequestHandler<GetPortListRequest, GetPortListResponce>
{
    public async Task<GetPortListResponce> Handle(GetPortListRequest request, CancellationToken cancellationToken)
    {
        var coll = await PortRepository.GetAll();
        return new GetPortListResponce(coll);
    }

   
}
