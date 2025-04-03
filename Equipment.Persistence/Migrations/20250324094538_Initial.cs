using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Equipment.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    TreatmentStrategyNoSQL = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Components",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ComponentState = table.Column<int>(type: "integer", nullable: false),
                    MollMass = table.Column<double>(type: "double precision", nullable: false),
                    MaxConcntration = table.Column<double>(type: "double precision", nullable: false),
                    Charge = table.Column<int>(type: "integer", nullable: false),
                    IsCounterIon = table.Column<bool>(type: "boolean", nullable: false),
                    IsReagent = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Components", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiametrEntity",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Size = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiametrEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EplanBlocks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Articles = table.Column<string>(type: "text", nullable: false),
                    EmaMacroPath = table.Column<string>(type: "text", nullable: false),
                    EmvMacroPath = table.Column<string>(type: "text", nullable: false),
                    TopLeftRel = table.Column<string>(type: "text", nullable: false),
                    InsertionPointRel = table.Column<string>(type: "text", nullable: false),
                    Height = table.Column<float>(type: "real", nullable: false),
                    RepresentationType = table.Column<int>(type: "integer", nullable: false),
                    Variant = table.Column<int>(type: "integer", nullable: false),
                    Width = table.Column<float>(type: "real", nullable: false),
                    Hash = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EplanBlocks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IsNonСorrosive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PipeTypeEntity",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Value = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PipeTypeEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RevitBlockEntity",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FamilyFilePath = table.Column<string>(type: "text", nullable: false),
                    Hash = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RevitBlockEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StageTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StageTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InlineUnit",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    RArticle = table.Column<string>(type: "text", nullable: false),
                    Code1C = table.Column<string>(type: "text", nullable: true),
                    MaterialId = table.Column<long>(type: "bigint", nullable: false),
                    Discriminator = table.Column<string>(type: "character varying(34)", maxLength: 34, nullable: false),
                    Voltage = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InlineUnit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InlineUnit_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InlineUnit_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EplanPortEntity",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PipeTypeId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    PortSide = table.Column<int>(type: "integer", nullable: false),
                    PositionRel = table.Column<string>(type: "text", nullable: false),
                    EplainBlockId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EplanPortEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EplanPortEntity_EplanBlocks_EplainBlockId",
                        column: x => x.EplainBlockId,
                        principalTable: "EplanBlocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EplanPortEntity_PipeTypeEntity_PipeTypeId",
                        column: x => x.PipeTypeId,
                        principalTable: "PipeTypeEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExternalProgrammsInfos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EplanId = table.Column<long>(type: "bigint", nullable: false),
                    RevitId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalProgrammsInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExternalProgrammsInfos_EplanBlocks_EplanId",
                        column: x => x.EplanId,
                        principalTable: "EplanBlocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExternalProgrammsInfos_RevitBlockEntity_RevitId",
                        column: x => x.RevitId,
                        principalTable: "RevitBlockEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Filters",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EquipmentTypeId = table.Column<long>(type: "bigint", nullable: false),
                    StageTypeId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Filters_EquipmentTypes_EquipmentTypeId",
                        column: x => x.EquipmentTypeId,
                        principalTable: "EquipmentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Filters_StageTypes_StageTypeId",
                        column: x => x.StageTypeId,
                        principalTable: "StageTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ports",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DiametrId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    PortNumber = table.Column<int>(type: "integer", nullable: false),
                    Pressure = table.Column<double>(type: "double precision", nullable: false),
                    Discriminator = table.Column<string>(type: "character varying(21)", maxLength: 21, nullable: false),
                    CommonInlineUnitId = table.Column<long>(type: "bigint", nullable: true),
                    PipeTypeId = table.Column<long>(type: "bigint", nullable: true),
                    Guid = table.Column<string>(type: "text", nullable: true),
                    FilterUnitId = table.Column<long>(type: "bigint", nullable: true),
                    PumpUnitId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ports_DiametrEntity_DiametrId",
                        column: x => x.DiametrId,
                        principalTable: "DiametrEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ports_Filters_FilterUnitId",
                        column: x => x.FilterUnitId,
                        principalTable: "Filters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ports_InlineUnit_CommonInlineUnitId",
                        column: x => x.CommonInlineUnitId,
                        principalTable: "InlineUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ports_InlineUnit_PumpUnitId",
                        column: x => x.PumpUnitId,
                        principalTable: "InlineUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ports_PipeTypeEntity_PipeTypeId",
                        column: x => x.PipeTypeId,
                        principalTable: "PipeTypeEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecificFilters",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: false),
                    WaterflowMax = table.Column<double>(type: "double precision", nullable: false),
                    WaterflowMin = table.Column<double>(type: "double precision", nullable: false),
                    FilterUnitId = table.Column<long>(type: "bigint", nullable: false),
                    RArticle = table.Column<string>(type: "text", nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Code1C = table.Column<string>(type: "text", nullable: true),
                    MaterialId = table.Column<long>(type: "bigint", nullable: false),
                    ExternalProgrammsInfoId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecificFilters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecificFilters_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpecificFilters_ExternalProgrammsInfos_ExternalProgrammsInf~",
                        column: x => x.ExternalProgrammsInfoId,
                        principalTable: "ExternalProgrammsInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpecificFilters_Filters_FilterUnitId",
                        column: x => x.FilterUnitId,
                        principalTable: "Filters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpecificFilters_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConcentrationEntity",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ComponentId = table.Column<long>(type: "bigint", nullable: false),
                    Value = table.Column<double>(type: "double precision", nullable: false),
                    FilterPortEntityId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConcentrationEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConcentrationEntity_Components_ComponentId",
                        column: x => x.ComponentId,
                        principalTable: "Components",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConcentrationEntity_Ports_FilterPortEntityId",
                        column: x => x.FilterPortEntityId,
                        principalTable: "Ports",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Distributions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ComponentId = table.Column<long>(type: "bigint", nullable: false),
                    Percentage = table.Column<int>(type: "integer", nullable: false),
                    FilterPortEntityId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distributions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Distributions_Components_ComponentId",
                        column: x => x.ComponentId,
                        principalTable: "Components",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Distributions_Ports_FilterPortEntityId",
                        column: x => x.FilterPortEntityId,
                        principalTable: "Ports",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EquipmentPortInlineUnit",
                columns: table => new
                {
                    InlineUnitsId = table.Column<long>(type: "bigint", nullable: false),
                    PorstsAttachedToId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentPortInlineUnit", x => new { x.InlineUnitsId, x.PorstsAttachedToId });
                    table.ForeignKey(
                        name: "FK_EquipmentPortInlineUnit_InlineUnit_InlineUnitsId",
                        column: x => x.InlineUnitsId,
                        principalTable: "InlineUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipmentPortInlineUnit_Ports_PorstsAttachedToId",
                        column: x => x.PorstsAttachedToId,
                        principalTable: "Ports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConcentrationEntity_ComponentId",
                table: "ConcentrationEntity",
                column: "ComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_ConcentrationEntity_FilterPortEntityId",
                table: "ConcentrationEntity",
                column: "FilterPortEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Distributions_ComponentId",
                table: "Distributions",
                column: "ComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_Distributions_FilterPortEntityId",
                table: "Distributions",
                column: "FilterPortEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_EplanPortEntity_EplainBlockId",
                table: "EplanPortEntity",
                column: "EplainBlockId");

            migrationBuilder.CreateIndex(
                name: "IX_EplanPortEntity_PipeTypeId",
                table: "EplanPortEntity",
                column: "PipeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentPortInlineUnit_PorstsAttachedToId",
                table: "EquipmentPortInlineUnit",
                column: "PorstsAttachedToId");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalProgrammsInfos_EplanId",
                table: "ExternalProgrammsInfos",
                column: "EplanId");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalProgrammsInfos_RevitId",
                table: "ExternalProgrammsInfos",
                column: "RevitId");

            migrationBuilder.CreateIndex(
                name: "IX_Filters_EquipmentTypeId",
                table: "Filters",
                column: "EquipmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Filters_StageTypeId",
                table: "Filters",
                column: "StageTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InlineUnit_CompanyId",
                table: "InlineUnit",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_InlineUnit_MaterialId",
                table: "InlineUnit",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Ports_CommonInlineUnitId",
                table: "Ports",
                column: "CommonInlineUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Ports_DiametrId",
                table: "Ports",
                column: "DiametrId");

            migrationBuilder.CreateIndex(
                name: "IX_Ports_FilterUnitId",
                table: "Ports",
                column: "FilterUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Ports_PipeTypeId",
                table: "Ports",
                column: "PipeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ports_PumpUnitId",
                table: "Ports",
                column: "PumpUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecificFilters_CompanyId",
                table: "SpecificFilters",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecificFilters_ExternalProgrammsInfoId",
                table: "SpecificFilters",
                column: "ExternalProgrammsInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecificFilters_FilterUnitId",
                table: "SpecificFilters",
                column: "FilterUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecificFilters_MaterialId",
                table: "SpecificFilters",
                column: "MaterialId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConcentrationEntity");

            migrationBuilder.DropTable(
                name: "Distributions");

            migrationBuilder.DropTable(
                name: "EplanPortEntity");

            migrationBuilder.DropTable(
                name: "EquipmentPortInlineUnit");

            migrationBuilder.DropTable(
                name: "SpecificFilters");

            migrationBuilder.DropTable(
                name: "Components");

            migrationBuilder.DropTable(
                name: "Ports");

            migrationBuilder.DropTable(
                name: "ExternalProgrammsInfos");

            migrationBuilder.DropTable(
                name: "DiametrEntity");

            migrationBuilder.DropTable(
                name: "Filters");

            migrationBuilder.DropTable(
                name: "InlineUnit");

            migrationBuilder.DropTable(
                name: "PipeTypeEntity");

            migrationBuilder.DropTable(
                name: "EplanBlocks");

            migrationBuilder.DropTable(
                name: "RevitBlockEntity");

            migrationBuilder.DropTable(
                name: "EquipmentTypes");

            migrationBuilder.DropTable(
                name: "StageTypes");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Materials");
        }
    }
}
