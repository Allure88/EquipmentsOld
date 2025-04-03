using Equipment.Domain.Entities.Base;
using Equipment.Domain.Entities.Ports;
using SharedCommon.CDB_EntityBodies;

namespace Equipment.Domain.Entities.Units
{
    public abstract class InfoUnit : BaseEntity, IObjectInfo
    {
        public string Name { get; set; } = string.Empty;
        public CompanyEntity Company { get; set; } = new();
        public long CompanyId { get; set; }
        public List<Port> Ports { get; set; } = new();
        public int Dimensions { get; set; }
    }
}
