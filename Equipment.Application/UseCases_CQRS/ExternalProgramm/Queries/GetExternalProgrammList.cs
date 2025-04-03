using AutoMapper;
using Equipment.Application.Contracts.Persistence;
using Equipment.Domain.Entities.ExternalProgrammsInfos;
using MediatR;
using SharedCommon.EplanShcemaApi.Bodies.Get;

namespace Equipment.Application.UseCases_CQRS.ExternalProgramm.Queries
{
    public class GetExternalProgrammListRequest() : IRequest<GetExternalProgrammListResponse> { }

    public class GetExternalProgrammListResponse(List<ExternalProgrammGetBody> externalProgramms)
    {
        public List<ExternalProgrammGetBody> ExternalProgramms { get; set; } = externalProgramms;
    }

    public class GetExternalProgrammListRequestHandler(IExternalProgrammRepository repository, IMapper mapper) : IRequestHandler<GetExternalProgrammListRequest, GetExternalProgrammListResponse>
    {
        public async Task<GetExternalProgrammListResponse> Handle(GetExternalProgrammListRequest request, CancellationToken cancellationToken)
        {
            List<ExternalProgrammsInfo> entities = await repository.GetAll();

            var body = entities.Select(ent => mapper.Map<ExternalProgrammGetBody>(ent)).ToList();
            return new GetExternalProgrammListResponse(body);
        }
    }
}
