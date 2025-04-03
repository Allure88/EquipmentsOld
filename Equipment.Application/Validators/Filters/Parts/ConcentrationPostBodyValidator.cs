using Equipment.Application.Contracts.Persistence;
using Equipment.Domain.Entities;
using FluentValidation;
using SharedCommon.TechSchemaDomain.PostDTO;

namespace Equipment.Application.Validators.Filters.Parts
{
    public class ConcentrationPostBodyValidator : AbstractValidator<ConcentrationPostBody>
    {
        public ConcentrationPostBodyValidator(IGenericRepository<ComponentEntity> repository)
        {
            RuleFor(concentration => concentration.ComponentId)
                .Must(componentId => Task.Run(() =>
                    repository.Get(componentId)).Result != null
                )
                .WithMessage("Component not found.");
        }
    }
}
