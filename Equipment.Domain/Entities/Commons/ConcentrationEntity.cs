using SharedCommon.CDB_EntityBodies;

namespace Equipment.Domain.Entities.Commons
{
    public class ConcentrationEntity: BaseEntity
    {
        public long ComponentId { get; set; }
        public ComponentEntity Component { get; set; } = new();
        public double Value { get; set; }
    }
}
