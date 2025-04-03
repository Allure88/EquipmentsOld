using Equipment.Domain.Entities.Base;
using Equipment.Domain.Entities.Commons;
using SharedCommon.CDB_EntityBodies;

namespace Equipment.Domain.Entities.Units
{
    public abstract class Unit : BaseEntity, IObject //для всех закупных
    {
        public string RArticle { get; set; } = string.Empty;
        public string? Code1C { get; set; }
        public CompanyEntity Company { get; set; } = new();
        public long CompanyId { get; set; }
        public MaterialEntity Material { get; set; } = new();
        public string Name { get; set; } = string.Empty;
    }

}