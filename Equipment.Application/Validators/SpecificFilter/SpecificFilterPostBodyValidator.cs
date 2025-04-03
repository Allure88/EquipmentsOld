using Equipment.Application.Validators.Service;
using FluentValidation;
using SharedCommon.TechSchemaDomain.PhysSchemeSubDomain.PostBodies;

namespace Equipment.Application.Validators.SpecificFilter
{
    public class SpecificFilterPostBodyValidator : AbstractValidator<PhysUnitPostBody>
    {
        public SpecificFilterPostBodyValidator(ValidationService repository)
        {
            RuleFor(unit => unit.FilterUnitId)
                .Must(filterUnit => Task.Run(() =>
                    repository.FilterRepository.Get(filterUnit)).Result != null
                )
                .WithMessage("FilterUnit not found.");

            RuleFor(unit => unit.CompanyId)
                .Must(filterUnit => Task.Run(() =>
                    repository.CompanyRepository.Get(filterUnit)).Result != null
                )
                .WithMessage("Company not found.");

            RuleFor(unit => unit.MaterialId)
                .Must(filterUnit => Task.Run(() =>
                    repository.MaterialEntity.Get(filterUnit)).Result != null
                )
                .WithMessage("Material not found.");

            RuleFor(unit => unit.ExternalProgrammsInfoId)
                .Must(filterUnit => Task.Run(() =>
                    repository.ExternalProgrammRepository.Get(filterUnit)).Result != null
                )
                .WithMessage("External Programms Info not found.");
        }
    }
}
