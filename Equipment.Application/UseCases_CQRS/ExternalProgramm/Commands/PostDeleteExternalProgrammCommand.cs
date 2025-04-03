using Equipment.Application.Contracts.Persistence;
using MediatR;

namespace Equipment.Application.UseCases_CQRS.ExternalProgramm.Commands
{
    public class PostDeleteExternalProgrammCommand(long id) : IRequest<PostDeleteExternalProgrammResponse>
    {
        public long Id { get; set; } = id;
    }

    public class PostDeleteExternalProgrammResponse(long id)
    {
        public long Id { get; set; } = id;
    }

    public class PostDeleteExternalProgrammCommandHandler(IExternalProgrammRepository repository) : IRequestHandler<PostDeleteExternalProgrammCommand, PostDeleteExternalProgrammResponse>
    {
        public async Task<PostDeleteExternalProgrammResponse> Handle(PostDeleteExternalProgrammCommand request, CancellationToken cancellationToken)
        {
            var entity = await repository.Get(request.Id);
            if (entity != null)
            {
                await repository.Delete(entity);
                return new PostDeleteExternalProgrammResponse(request.Id);
            }

            return new PostDeleteExternalProgrammResponse(-1);
        }
    }
}
