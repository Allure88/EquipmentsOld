using SharedCommon.CDB_EntityBodies;

namespace Equipment.Domain.Entities.Commons
{
    public class StageTypeEntity : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public long? CompanyEntityId { get; set; }
    }
}
