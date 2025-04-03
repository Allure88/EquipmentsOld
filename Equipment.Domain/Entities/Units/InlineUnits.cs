using Equipment.Domain.Entities.Commons;
using Equipment.Domain.Entities.Ports;
using SharedCommon.CDB_EntityBodies;

namespace Equipment.Domain.Entities.Units;

public abstract class InlineUnit : Unit
{
    public List<EquipmentPort> PorstsAttachedTo { get; set; } = []; // навигаионное свойство
    public abstract List<Port> GetPorts();
}

public class CommonInlineUnitEntity: InlineUnit
{
    public List<CommonInlinePort> Ports { get; set; } = [];
    public override List<Port> GetPorts() => [.. Ports];

}

public class PumpInlineUnitEntity : InlineUnit
{
    public double Waterflow { get; }
    public double Pressurre { get; }
    public double Voltage { get; set; }
    public List<PumpInlinePort> PumpPorts { get; set; } = [];
    public override List<Port> GetPorts() => [.. PumpPorts];

}
