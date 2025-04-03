using AutoMapper;
using Equipment.Application.Contracts.Persistence;
using Equipment.Domain.Entities;
using MediatR;
using SharedCommon.CDB_EntityBodies;

namespace Equipment.Application.UseCases_CQRS.Common.Queries.Company
{
    public class GetCompanyRequest(long id) : IRequest<GetCompanyResponse>
    {
        public long Id { get; set; } = id;
    }

    public class GetCompanyResponse(CompanyBody body)
    {
        public CompanyBody Body { get; set; } = body;
    }

    public class GetCompanyRequestHandler(ICompanyRepository repository, IMapper mapper) : IRequestHandler<GetCompanyRequest, GetCompanyResponse>
    {
        public async Task<GetCompanyResponse> Handle(GetCompanyRequest request, CancellationToken cancellationToken)
        {
            var entity = await repository.Get(request.Id);
            var mappedEntity = mapper.Map<CompanyBody>(entity);
            return new GetCompanyResponse(mappedEntity);
        }
    }
}
