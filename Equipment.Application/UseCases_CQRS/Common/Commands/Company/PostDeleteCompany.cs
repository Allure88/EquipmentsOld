using Equipment.Application.Contracts.Persistence;
using Equipment.Domain.Entities;
using MediatR;

namespace Equipment.Application.UseCases_CQRS.Common.Commands.Company
{
    public class PostDeleteCompanyRequest(long id) : IRequest<PostDeleteCompanyResponse>
    {
        public long Id { get; set; } = id;
    }

    public class PostDeleteCompanyResponse(long id)
    {
        public long Id { get; set; } = id;
    }

    public class PostDeleteCompanyRequestHandler(ICompanyRepository repository) : IRequestHandler<PostDeleteCompanyRequest, PostDeleteCompanyResponse>
    {
        public async Task<PostDeleteCompanyResponse> Handle(PostDeleteCompanyRequest request, CancellationToken cancellationToken)
        {
            var entity = await repository.Get(request.Id);
            if (entity != null)
            {
                await repository.Delete(entity);
                return new PostDeleteCompanyResponse(request.Id);
            }

            return new PostDeleteCompanyResponse(-1);
        }
    }
}
