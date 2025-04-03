using Equipment.Domain.Entities.ExternalProgrammsInfos.Base;
using SharedCommon;
using SharedCommon.EplanShcemaApi.EplanDB;

namespace Equipment.Domain.Entities.ExternalProgrammsInfos.Fields.Eplan;

public class EplanBlockEntity : Config//IEplanDBBlock
{
    public List<string> Articles { get; set; } = [];
    public string EmaMacroPath { get; set; } = string.Empty;
    public string EmvMacroPath { get; set; } = string.Empty;
    public Point TopLeftRel { get; set; }
    public Point InsertionPointRel { get; set; }
    public float Height { get; set; }
    public List<EplanPortEntity> Ports { get; set; } = [];
    public RepresentationType RepresentationType { get; set; }
    public int Variant { get; set; }
    public float Width { get; set; }
}
