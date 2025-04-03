using Equipment.Domain.Entities.Commons;
using Equipment.Domain.Entities.Ports;
using SharedCommon.CDB_EntityBodies;

namespace Equipment.Domain.Entities.Units;

public class FilterUnitEntity : BaseEntity
{
    public long EquipmentTypeId {  get; set; }
    public EquipmentTypeEntity EquipmentType { get; set; } = new();
    public long StageTypeId {  get; set; }
    public StageTypeEntity StageType { get; set; } = new();

    public List<FilterPortEntity> Ports { get; set; } = [];
    public List<Port> GetPorts() => [.. Ports];
    public List<SpecificFilterEntity> AttachedTo { get; set; } = []; //навигационное
}



