using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Equipment.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EplanPortEntity_PipeTypeEntity_PipeTypeId",
                table: "EplanPortEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_Ports_DiametrEntity_DiametrId",
                table: "Ports");

            migrationBuilder.DropForeignKey(
                name: "FK_Ports_PipeTypeEntity_PipeTypeId",
                table: "Ports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PipeTypeEntity",
                table: "PipeTypeEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DiametrEntity",
                table: "DiametrEntity");

            migrationBuilder.RenameTable(
                name: "PipeTypeEntity",
                newName: "PipeTypes");

            migrationBuilder.RenameTable(
                name: "DiametrEntity",
                newName: "Diametrs");

            migrationBuilder.AddColumn<long>(
                name: "SpecificFilterEntityId",
                table: "InlineUnit",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PipeTypes",
                table: "PipeTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Diametrs",
                table: "Diametrs",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_InlineUnit_SpecificFilterEntityId",
                table: "InlineUnit",
                column: "SpecificFilterEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_EplanPortEntity_PipeTypes_PipeTypeId",
                table: "EplanPortEntity",
                column: "PipeTypeId",
                principalTable: "PipeTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InlineUnit_SpecificFilters_SpecificFilterEntityId",
                table: "InlineUnit",
                column: "SpecificFilterEntityId",
                principalTable: "SpecificFilters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ports_Diametrs_DiametrId",
                table: "Ports",
                column: "DiametrId",
                principalTable: "Diametrs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ports_PipeTypes_PipeTypeId",
                table: "Ports",
                column: "PipeTypeId",
                principalTable: "PipeTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EplanPortEntity_PipeTypes_PipeTypeId",
                table: "EplanPortEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_InlineUnit_SpecificFilters_SpecificFilterEntityId",
                table: "InlineUnit");

            migrationBuilder.DropForeignKey(
                name: "FK_Ports_Diametrs_DiametrId",
                table: "Ports");

            migrationBuilder.DropForeignKey(
                name: "FK_Ports_PipeTypes_PipeTypeId",
                table: "Ports");

            migrationBuilder.DropIndex(
                name: "IX_InlineUnit_SpecificFilterEntityId",
                table: "InlineUnit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PipeTypes",
                table: "PipeTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Diametrs",
                table: "Diametrs");

            migrationBuilder.DropColumn(
                name: "SpecificFilterEntityId",
                table: "InlineUnit");

            migrationBuilder.RenameTable(
                name: "PipeTypes",
                newName: "PipeTypeEntity");

            migrationBuilder.RenameTable(
                name: "Diametrs",
                newName: "DiametrEntity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PipeTypeEntity",
                table: "PipeTypeEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DiametrEntity",
                table: "DiametrEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EplanPortEntity_PipeTypeEntity_PipeTypeId",
                table: "EplanPortEntity",
                column: "PipeTypeId",
                principalTable: "PipeTypeEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ports_DiametrEntity_DiametrId",
                table: "Ports",
                column: "DiametrId",
                principalTable: "DiametrEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ports_PipeTypeEntity_PipeTypeId",
                table: "Ports",
                column: "PipeTypeId",
                principalTable: "PipeTypeEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
