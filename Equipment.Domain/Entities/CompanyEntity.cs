using Equipment.Domain.Entities.Commons;
using SharedCommon.CDB_EntityBodies;

namespace Equipment.Domain.Entities;

public class CompanyEntity : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public List<StageTypeEntity>? Stage { get; set; }
}
