using Equipment.Domain.Entities.Commons;
using SharedCommon;
using SharedCommon.CDB_EntityBodies;
using SharedCommon.TechSchemaDomain.Enums;

namespace Equipment.Domain.Entities.ExternalProgrammsInfos.Fields.Eplan;

public class EplanPortEntity : BaseEntity//, IEplanDBPort
{
    public long PipeTypeId { get; set; }
    public PipeTypeEntity PipeType { get; set; } = new();
    public string Name { get; set; } = string.Empty;
    public PortSide PortSide { get; set; }
    public Point PositionRel { get; set; }
    public EplanBlockEntity EplainBlock { get; set; } = new();
}
