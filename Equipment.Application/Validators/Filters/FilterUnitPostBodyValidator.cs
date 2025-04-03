using Equipment.Application.Validators.Service;
using FluentValidation;
using SharedCommon.TechSchemaDomain.PostDTO.Units;

namespace Equipment.Application.Validators.Filters
{
    public class FilterUnitPostBodyValidator : AbstractValidator<FilterUnitPostBody>
    {
        public FilterUnitPostBodyValidator(ValidationService service)
        {
            RuleFor(filter => filter.EquipmentTypeId)
                .Must(equipmentId => Task.Run(() => service.EquipmentRepository.Get(equipmentId)).Result != null)
                .WithMessage("Equpment type not found.");

            RuleFor(filter => filter.StageTypeId)
                .Must(stageTypeId => Task.Run(() => service.StageRepository.Get(stageTypeId)).Result != null)
                .WithMessage("Stage type not found.");

            RuleForEach(filter => filter.Ports)
                .SetValidator(new FilterPortPostBodyValidator(service));
        }
    }

}
