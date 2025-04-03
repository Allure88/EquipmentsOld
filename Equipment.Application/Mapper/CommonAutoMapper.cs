using AutoMapper;
using Equipment.Domain.Entities;
using Equipment.Domain.Entities.Commons;
using Equipment.Domain.Entities.Ports;
using Equipment.Domain.Entities.Units;
using SharedCommon.CDB_EntityBodies;
using SharedCommon.TechSchemaDomain.PhysSchemeSubDomain.GetBodies.Unit;
using SharedCommon.TechSchemaDomain.PhysSchemeSubDomain.PostBodies.Unit;
using SharedCommon.TechSchemaDomain.PostBodies.Ports;
using SharedCommon.TechSchemaDomain.PostDTO;
using SharedCommon.TechSchemaDomain.PostDTO.Ports;
using SharedCommon.TechSchemaDomain.PostDTO.Units;

namespace Equipment.Application.Mapper
{
    public class CommonAutoMapper : Profile
    {
        public CommonAutoMapper()
        {
            CreateMap<PortOtherBody, Port>();

            CreateMap<DistributionPostBody, DistributionEntity>();
            CreateMap<ConcentrationPostBody, ConcentrationEntity>();

            CreateMap<EquipmentUnitBody, EquipmentUnit>();

            CreateMap<EquipmentUnit, PhysEquipmentUnitGetBody>()
                .ForMember(dest => dest.MaterialName,
                opt => opt.MapFrom(src => src.Material.Name))
                .ForMember(dest => dest.CompanyName,
                opt => opt.MapFrom(src => src.Company.Name));

            CreateMap<PhysEquipmentUnitPostBody, EquipmentUnit>();

            CreateMap<EquipmentPortPostBody, EquipmentPort>()
                .IncludeBase<PortOtherBody, Port>();

            CreateMap<StageTypeEntity, StageTypeBody>().ReverseMap();
            CreateMap<PipeTypeEntity, PipeTypeBody>().ReverseMap();
            CreateMap<EquipmentTypeEntity, EquipmentTypeBody>().ReverseMap();
            CreateMap<MaterialEntity, MaterialBody>().ReverseMap();
            CreateMap<DiametrEntity, DiametrBody>().ReverseMap();
            CreateMap<CompanyEntity,  CompanyBody>().ReverseMap();
            CreateMap<ComponentEntity, ComponentBody>().ReverseMap();
        }
    }
}
