using Equipment.Application.Validators.Service;
using FluentValidation;
using SharedCommon.EplanShcemaApi.Bodies.Post;

namespace Equipment.Application.Validators.ExternalProgramm.Eplan
{
    public class EplanBlockValidator : AbstractValidator<EplanBlockPostBody?>
    {
        public EplanBlockValidator(ValidationService service)
        {
            RuleFor(eplan => eplan.Ports)
            .NotNull().WithMessage("Ports cannot be null")
            .ForEach(port => port.SetValidator(new EplanPortValidator(service)));
        }
    }
}
