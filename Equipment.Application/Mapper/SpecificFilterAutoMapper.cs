using AutoMapper;
using Equipment.Domain.Entities.Ports;
using Equipment.Domain.Entities.Units;
using SharedCommon.TechSchemaDomain.PhysSchemeSubDomain.GetBodies;
using SharedCommon.TechSchemaDomain.PhysSchemeSubDomain.GetBodies.Unit;
using SharedCommon.TechSchemaDomain.PhysSchemeSubDomain.PostBodies;
using SharedCommon.TechSchemaDomain.PhysSchemeSubDomain.PostBodies.Unit;

namespace Equipment.Application.Mapper
{
    public class SpecificFilterAutoMapper : Profile
    {
        public SpecificFilterAutoMapper()
        {
            CreateMap<SpecificFilterEntity, PhysUnitGetBody>()
                .ForMember(desc => desc.InputPorts, opt => opt.MapFrom((src, dest, destMember, context) =>
                    src.FilterUnit != null
                        ? src.FilterUnit.Ports
                            .Where(p => p.Type == PortDirectionType.Input)
                            .Select(p => context.Mapper.Map<PhysPortGetBody>(p))
                            .ToList()
                        : new List<PhysPortGetBody>()))
                .ForMember(desc => desc.OutputPorts, opt => opt.MapFrom((src, dest, destMember, context) =>
                    src.FilterUnit != null
                        ? src.FilterUnit.Ports
                            .Where(p => p.Type == PortDirectionType.Output)
                            .Select(p => context.Mapper.Map<PhysPortGetBody>(p))
                            .ToList()
                        : new List<PhysPortGetBody>()))

                .IncludeBase<EquipmentUnit, PhysEquipmentUnitGetBody>();

            CreateMap<PhysUnitPostBody, SpecificFilterEntity>()
                .IncludeBase<PhysEquipmentUnitPostBody, EquipmentUnit>();
        }
    }
}
