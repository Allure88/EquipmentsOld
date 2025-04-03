using SharedCommon.CDB_EntityBodies;

namespace Equipment.Domain.Entities.Commons;

public class MaterialEntity : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public bool IsNonСorrosive { get; set; }
}
