using AutoMapper;
using Equipment.Application.Contracts.Persistence;
using Equipment.Application.Validators.ExternalProgramm;
using Equipment.Application.Validators.Service;
using Equipment.Domain.Entities.ExternalProgrammsInfos;
using MediatR;
using SharedCommon.EplanShcemaApi.Bodies.Get;
using SharedCommon.EplanShcemaApi.Bodies.Post;
using SharedCommon.Responces;

namespace Equipment.Application.UseCases_CQRS.ExternalProgramm.Commands
{
    public class PostAddExternalProgrammCommand(ExternalProgrammPostBody externalProgramm) : IRequest<PostAddExternalProgrammResponse>
    {
        public ExternalProgrammPostBody ExternalProgramm { get; set; } = externalProgramm;
    }

    public class PostAddExternalProgrammResponse(ExternalProgrammGetBody? externalProgrammsInfo)
    {
        public ExternalProgrammGetBody? ExternalProgrammsInfo { get; set; } = externalProgrammsInfo;
    }

    public class PostAddExternalProgrammCommandHandler(IExternalProgrammRepository repository,
        IMapper mapper,
        ValidationService service) : IRequestHandler<PostAddExternalProgrammCommand, PostAddExternalProgrammResponse>
    {
        public async Task<PostAddExternalProgrammResponse> Handle(PostAddExternalProgrammCommand request, CancellationToken cancellationToken)
        {
            var validation = new ExternalProgrammValidator(service);
            validation.Validate(request.ExternalProgramm);

            var externalProgramm = mapper.Map<ExternalProgrammsInfo>(request.ExternalProgramm);
            var addedEntity = await repository.Add(externalProgramm);
            var mappedEntity = mapper.Map<ExternalProgrammGetBody>(addedEntity);
            return new PostAddExternalProgrammResponse(mappedEntity);
        }
    }
}
