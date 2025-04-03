using AutoMapper;
using Equipment.Application.Contracts.Persistence;
using Equipment.Domain.Entities;
using MediatR;
using SharedCommon.CDB_EntityBodies;

namespace Equipment.Application.UseCases_CQRS.Common.Commands.Company
{
    public class PostAddCompanyRequest(CompanyBody body) : IRequest<PostAddCompanyResponse>
    {
        public CompanyBody Body { get; set; } = body;
    }

    public class PostAddCompanyResponse(CompanyEntity body)
    {
        public CompanyEntity Body { get; set; } = body;
    }

    public class PostAddCompanyRequestHandler(ICompanyRepository repository, IMapper mapper) : IRequestHandler<PostAddCompanyRequest, PostAddCompanyResponse>
    {
        public async Task<PostAddCompanyResponse> Handle(PostAddCompanyRequest request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<CompanyEntity>(request.Body);
            var addedEntity = await repository.Add(entity);
            return new PostAddCompanyResponse(addedEntity);
        }
    }
}
