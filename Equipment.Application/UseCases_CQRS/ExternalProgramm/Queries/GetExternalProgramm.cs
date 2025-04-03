using AutoMapper;
using Equipment.Application.Contracts.Persistence;
using MediatR;
using SharedCommon.EplanShcemaApi.Bodies.Get;
using SharedCommon.Responces;

namespace Equipment.Application.UseCases_CQRS.ExternalProgramm.Queries
{
    public class GetExternalProgramRequest(long id) : IRequest<GetExternalProgramResponse>
    {
        public long Id { get; set; } = id;
    }

    public class GetExternalProgramResponse(ExternalProgrammGetBody externalProgramm)
    {
        public ExternalProgrammGetBody ExternalProgramm { get; set; } = externalProgramm;

    }

    public class GetExternalProgramRequestHandler(IExternalProgrammRepository repository, IMapper mapper) : IRequestHandler<GetExternalProgramRequest, GetExternalProgramResponse>
    {
        public async Task<GetExternalProgramResponse> Handle(GetExternalProgramRequest request, CancellationToken cancellationToken)
        {
            var entities = await repository.Get(request.Id);
            var externalProgramm = mapper.Map<ExternalProgrammGetBody>(entities);
            return new GetExternalProgramResponse(externalProgramm);
        }
    }
}
