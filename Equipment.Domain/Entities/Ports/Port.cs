using Equipment.Domain.Entities.Commons;
using SharedCommon.CDB_EntityBodies;

namespace Equipment.Domain.Entities.Ports
{
    public enum PortDirectionType { Input, Output };
    public abstract class Port : BaseEntity
    {
        public long DiametrId {  get; set; }
        public DiametrEntity Diametr { get; set; } = new();
        public string Name { get; set; } = string.Empty;
        public PortDirectionType Type { get; set; }
        public int PortNumber { get; set; } //для упорядоченной выдачи
        public double Pressure { get; set; }
        //public abstract Unit GetParent();
    }

}
