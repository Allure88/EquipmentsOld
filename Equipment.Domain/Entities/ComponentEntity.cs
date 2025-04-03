using Equipment.Domain.Entities.OldEnums;
using SharedCommon.CDB_EntityBodies;

namespace Equipment.Domain.Entities
{
    public class ComponentEntity : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ComponentState ComponentState { get; set; }
        public double MollMass { get; set; }
        public double MaxConcntration{ get; set; } // г/л
        public int Charge { get; set; } //г/моль
        public bool IsCounterIon { get; set; }
        public bool IsReagent { get; set; }
        public double GetMassEquivalent() => MollMass / Charge;
    }
}
