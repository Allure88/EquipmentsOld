using Equipment.Application.Contracts.Persistence;
using Equipment.Domain.Entities;
using FluentValidation;
using SharedCommon.TechSchemaDomain.PostDTO;

namespace Equipment.Application.Validators.Filters.Parts
{
    class DistributionPostBodyValidator : AbstractValidator<DistributionPostBody>
    {
        public DistributionPostBodyValidator(IGenericRepository<ComponentEntity> repository)
        {
            RuleFor(distribution => distribution.ComponentId)
                .Must(componentId => Task.Run(() =>
                    repository.Get(componentId)).Result != null
                )
                .WithMessage("Component not found.");
        }
    }
}
