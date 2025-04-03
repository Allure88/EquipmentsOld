using Equipment.Application.Validators.ExternalProgramm.Eplan;
using Equipment.Application.Validators.Service;
using FluentValidation;
using SharedCommon.EplanShcemaApi.Bodies.Post;


namespace Equipment.Application.Validators.ExternalProgramm
{
    public class ExternalProgrammValidator : AbstractValidator<ExternalProgrammPostBody>
    {
        public ExternalProgrammValidator(ValidationService validation)
        {
            RuleFor(externalProgramm => externalProgramm.Eplan)
                .SetValidator(new EplanBlockValidator(validation));
        }
    }
}
