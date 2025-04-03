using Equipment.Application.Validators.Service;
using FluentValidation;
using SharedCommon.EplanShcemaApi.Bodies.Post;

namespace Equipment.Application.Validators.ExternalProgramm.Eplan
{
    public class EplanPortValidator : AbstractValidator<EplanPortPostBody>
    {
        public EplanPortValidator(ValidationService service)
        {
            RuleFor(eplanPort => eplanPort.PipeTypeId)
                .Must(pipeTypeId => Task.Run(() => service.PipeRepository.Get(pipeTypeId)).Result != null)
                .WithMessage("Pipe type not found.");
        }
    }
}
