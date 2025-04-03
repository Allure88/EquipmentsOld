using AutoMapper;
using Equipment.Domain.Entities.ExternalProgrammsInfos;
using Equipment.Domain.Entities.ExternalProgrammsInfos.Base;
using Equipment.Domain.Entities.ExternalProgrammsInfos.Fields.Eplan;
using SharedCommon.EplanShcemaApi.Bodies.Base;
using SharedCommon.EplanShcemaApi.Bodies.Get;
using SharedCommon.EplanShcemaApi.Bodies.Post;

namespace Equipment.Application.Mapper
{
    public class EplanEntityAutoMapper : Profile
    {
        public EplanEntityAutoMapper()
        {
            CreateMap<Config, ConfigBody>();

            CreateMap<EplanBlockEntity, EplanBlockGetBody>()
                .IncludeBase<Config, ConfigBody>();

            CreateMap<EplanPortEntity, EplanPortGetBody>()
                .ForMember(ep => ep.PipeTypeName, opt => opt.MapFrom(src => src.PipeType.Value));
            CreateMap<ExternalProgrammsInfo, ExternalProgrammGetBody>();

            CreateMap<EplanBlockPostBody, EplanBlockEntity>();
            CreateMap<EplanPortPostBody, EplanPortEntity>();
            CreateMap<ExternalProgrammPostBody, ExternalProgrammsInfo>();
        }
    }
}
