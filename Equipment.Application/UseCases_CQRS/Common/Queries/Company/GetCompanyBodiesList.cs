using AutoMapper;
using Equipment.Application.Contracts.Persistence;
using Equipment.Domain.Entities;
using MediatR;
using SharedCommon.CDB_EntityBodies;

namespace Equipment.Application.UseCases_CQRS.Common.Queries.Company
{
    public class GetCompanyBodiesListRequest : IRequest<GetCompanyBodiesListResponse> { }

    public class GetCompanyBodiesListResponse(List<CompanyEntity> bodies)
    {
        public List<CompanyEntity> Bodies { get; set; } = bodies;
    }

    public class GetCompanyBodiesListRequestHandler(ICompanyRepository repository) : IRequestHandler<GetCompanyBodiesListRequest, GetCompanyBodiesListResponse>
    {
        public async Task<GetCompanyBodiesListResponse> Handle(GetCompanyBodiesListRequest request, CancellationToken cancellationToken)
        {
            var entity = await repository.GetAll();
            return new GetCompanyBodiesListResponse(entity);
        }
    }
}
