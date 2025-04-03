using Equipment.Domain.Entities.ExternalProgrammsInfos.Fields.Eplan;
using Equipment.Domain.Entities.ExternalProgrammsInfos.Fields.Revit;
using SharedCommon.CDB_EntityBodies;

namespace Equipment.Domain.Entities.ExternalProgrammsInfos
{
    public class ExternalProgrammsInfo : BaseEntity
    {
        public long? EplanId { get; set; }
        public EplanBlockEntity? Eplan { get; set; }
        public long? RevitId { get; set; }
        public RevitBlockEntity? Revit { get; set; }
    }
}
