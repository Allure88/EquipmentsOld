using AutoMapper;
using Equipment.Domain.Entities.Commons;
using Equipment.Domain.Entities.Ports;
using Equipment.Domain.Entities.Units;
using SharedCommon.TechSchemaDomain.PhysSchemeSubDomain.GetBodies;
using SharedCommon.TechSchemaDomain.PostBodies.Ports;
using SharedCommon.TechSchemaDomain.PostDTO.Ports;
using SharedCommon.TechSchemaDomain.PostDTO.Units;

namespace Equipment.Application.Mapper
{
    public class FilterAutoMapper : Profile
    {
        public FilterAutoMapper()
        {
            CreateMap<FilterUnitPostBody, FilterUnitEntity>();

            CreateMap<FilterPortEntity, PhysPortGetBody>()
                .ForMember(dest => dest.PipeTypeName,
                    opt => opt.MapFrom(src => src.PipeType != null ?  src.PipeType.Value : null))
                .ForMember(dest => dest.DiametrName,
                    opt => opt.MapFrom(src => src.Diametr != null ? src.Diametr.Name : null));


            CreateMap<FilterPortPostBody, FilterPortEntity>()
                .IncludeBase<EquipmentPortPostBody, EquipmentPort>();
        }
    }
}
