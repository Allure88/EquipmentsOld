using Equipment.Application.Validators.Filters.Parts;
using Equipment.Application.Validators.Service;
using FluentValidation;
using SharedCommon.TechSchemaDomain.PostDTO.Ports;

namespace Equipment.Application.Validators.Filters
{
    public class FilterPortPostBodyValidator : AbstractValidator<FilterPortPostBody>
    {
        public FilterPortPostBodyValidator(ValidationService service)
        {
            RuleFor(port => port.PipeTypeId)
                .Must(pipeTypeId => Task.Run(() => service.PipeRepository.Get(pipeTypeId)).Result != null)
                .WithMessage("Pipe type not found.");

            RuleFor(port => port.DiametrId)
                .Must(diametrId => Task.Run(() => service.DiametrRepository.Get(diametrId)).Result != null)
                .WithMessage("Diametr not found.");

            RuleForEach(port => port.Distributions)
                .SetValidator(new DistributionPostBodyValidator(service.ComponentRepository));

            RuleForEach(port => port.PDK)
                .SetValidator(new ConcentrationPostBodyValidator(service.ComponentRepository));
        }
    }
}
