using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Equipment.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TreatmentStrategyNoSQL",
                table: "Companies");

            migrationBuilder.AddColumn<long>(
                name: "CompanyEntityId",
                table: "StageTypes",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StageTypes_CompanyEntityId",
                table: "StageTypes",
                column: "CompanyEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_StageTypes_Companies_CompanyEntityId",
                table: "StageTypes",
                column: "CompanyEntityId",
                principalTable: "Companies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StageTypes_Companies_CompanyEntityId",
                table: "StageTypes");

            migrationBuilder.DropIndex(
                name: "IX_StageTypes_CompanyEntityId",
                table: "StageTypes");

            migrationBuilder.DropColumn(
                name: "CompanyEntityId",
                table: "StageTypes");

            migrationBuilder.AddColumn<string>(
                name: "TreatmentStrategyNoSQL",
                table: "Companies",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
