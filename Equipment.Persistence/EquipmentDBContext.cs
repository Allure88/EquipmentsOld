using Equipment.Domain.Entities;
using Equipment.Domain.Entities.Commons;
using Equipment.Domain.Entities.ExternalProgrammsInfos;
using Equipment.Domain.Entities.ExternalProgrammsInfos.Fields.Eplan;
using Equipment.Domain.Entities.Ports;
using Equipment.Domain.Entities.Units;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SharedCommon;

namespace Equipment.Persistence;


public class EquipmentDBContext : DbContext
{
    public EquipmentDBContext(DbContextOptions<EquipmentDBContext> opts) : base(opts)
    {
        
    }

    public DbSet<CompanyEntity> Companies { get; set; }//repo
    public DbSet<Port> Ports { get; set; }

    public DbSet<PumpInlineUnitEntity> PumpInlineUnits { get; set; } //repo
    public DbSet<CommonInlineUnitEntity> CommonInlineUnits { get; set; } //repo

    public DbSet<FilterUnitEntity> Filters { get; set; } //для Ярослава в Автосхемы
    public DbSet<SpecificFilterEntity> SpecificFilters { get; set; } // для Самойлина А. в физ схемы

    public DbSet<DistributionEntity> Distributions { get; set; }// repo
    public DbSet<ComponentEntity> Components { get; set; }//repo
    public DbSet<StageTypeEntity> StageTypes { get; set; }
    public DbSet<PipeTypeEntity> PipeTypes { get; set; }
    public DbSet<EquipmentTypeEntity> EquipmentTypes { get; set; }
    public DbSet<DiametrEntity> Diametrs { get; set; }


    public DbSet<MaterialEntity> Materials { get; set; }
    public DbSet<EplanBlockEntity> EplanBlocks { get; set; }
    public DbSet<ExternalProgrammsInfo> ExternalProgrammsInfos { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<EplanBlockEntity>(entity =>
            {
                entity.Property(p => p.Articles).HasConversion(
                    x => JsonConvert.SerializeObject(x),
                    x => JsonConvert.DeserializeObject<List<string>>(x) ?? new()
                    );

                entity.Property(p => p.TopLeftRel)
                        .HasConversion(
                                x => JsonConvert.SerializeObject(x),
                                x => x != null ? JsonConvert.DeserializeObject<Point>(x) : new Point(0f, 0f)
                            );

                entity.Property(p => p.InsertionPointRel)
                        .HasConversion(
                                x => JsonConvert.SerializeObject(x),
                                x => x != null ? JsonConvert.DeserializeObject<Point>(x) : new Point(0f, 0f)
                            );
            });

        modelBuilder
            .Entity<EplanPortEntity>(entity =>
            {
                entity.Property(p => p.PositionRel)
                        .HasConversion(
                            x => JsonConvert.SerializeObject(x),
                            x => x != null ? JsonConvert.DeserializeObject<Point>(x) : new Point(0f, 0f)
                        );
            });
    }
}
