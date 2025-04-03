using SharedCommon.CDB_EntityBodies;

namespace Equipment.Domain.Entities.Commons
{
    public class DistributionEntity : BaseEntity
    {
        public long ComponentId { get; set; }
        public ComponentEntity Component { get; set; } = new();
        public int Percentage { get; set; }
    }
}
