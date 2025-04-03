using Equipment.Domain.Entities.ExternalProgrammsInfos.Base;

namespace Equipment.Domain.Entities.ExternalProgrammsInfos.Fields.Revit;

public class RevitBlockEntity : Config
{
    public string FamilyFilePath { get; set; } = string.Empty;
}
