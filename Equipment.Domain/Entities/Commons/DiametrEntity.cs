using SharedCommon.CDB_EntityBodies;

namespace Equipment.Domain.Entities.Commons
{
    public class DiametrEntity : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public int Size { get; set; }
    }
}
