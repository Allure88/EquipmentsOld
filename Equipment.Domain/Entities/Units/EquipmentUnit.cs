using Equipment.Domain.Entities.Commons;
using Equipment.Domain.Entities.ExternalProgrammsInfos;
using Equipment.Domain.Entities.Ports;
using SharedCommon.CDB_EntityBodies;

namespace Equipment.Domain.Entities.Units;
public abstract class EquipmentUnit : Unit
{
    public long MaterialId { get; set; }
    public long ExternalProgrammsInfoId { get; set; }
    public ExternalProgrammsInfo ExternalProgrammsInfo { get; set; } = new();
    public abstract List<Port> GetPorts();
}


public class SpecificFilterEntity : EquipmentUnit //конкретно продаваемая единица оборудования
{
    public string Description { get; set; } = string.Empty;
    public double WaterflowMax { get; set; }
    public double WaterflowMin { get; set; }
    public long FilterUnitId { get; set; }
    public FilterUnitEntity FilterUnit { get; set; } = new();
    public List<InlineUnit> inlineUnits { get; set; } = new();
    public override List<Port> GetPorts() => FilterUnit.GetPorts();
}



