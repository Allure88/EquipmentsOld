using Equipment.Domain.Entities.Commons;
using Equipment.Domain.Entities.Units;

namespace Equipment.Domain.Entities.Ports
{
    public interface IEquipmentPort
    {
        List<InlineUnit> InlineUnits { get; set; }
    }



    public class EquipmentPort : Port, IEquipmentPort
    {
        public long PipeTypeId { get; set; }
        public PipeTypeEntity PipeType { get; set; } = new();
        public List<InlineUnit> InlineUnits { get; set; } = [];
        //public override Unit GetParent() { throw new NotImplementedException(); }
    }

    public class FilterPortEntity : EquipmentPort
    {
        //out
        public string Guid { get; set; } = string.Empty;
        public double UnaccountedComponent { get; }
        public double HumidityCoefficient { get; }
        public List<DistributionEntity> Distributions { get; } = [];

        //input
        public List<ConcentrationEntity> PDK { get; } = [];

        public long FilterUnitId { get; set; }
        public FilterUnitEntity FilterUnit { get; set; } = new();

        //public override Unit GetParent() => FilterUnit;
    }

}
