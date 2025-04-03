using Equipment.Domain.Entities.Units;

namespace Equipment.Domain.Entities.Ports
{
    public class CommonInlinePort : Port
    {

        public long CommonInlineUnitId { get; set; }
        public CommonInlineUnitEntity CommonInlineUnit { get; set; } = new();
        //public override Unit GetParent() => CommonInlineUnit;
    }

    public class PumpInlinePort : Port
    {
        public long PumpUnitId { get; set; }
        public PumpInlineUnitEntity PumpUnit { get; set; } = new();
        //public override Unit GetParent() => PumpUnit;
    }
}
