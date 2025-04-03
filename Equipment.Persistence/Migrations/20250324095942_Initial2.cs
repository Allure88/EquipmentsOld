using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Equipment.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExternalProgrammsInfos_EplanBlocks_EplanId",
                table: "ExternalProgrammsInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_ExternalProgrammsInfos_RevitBlockEntity_RevitId",
                table: "ExternalProgrammsInfos");

            migrationBuilder.AlterColumn<long>(
                name: "RevitId",
                table: "ExternalProgrammsInfos",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "EplanId",
                table: "ExternalProgrammsInfos",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_ExternalProgrammsInfos_EplanBlocks_EplanId",
                table: "ExternalProgrammsInfos",
                column: "EplanId",
                principalTable: "EplanBlocks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExternalProgrammsInfos_RevitBlockEntity_RevitId",
                table: "ExternalProgrammsInfos",
                column: "RevitId",
                principalTable: "RevitBlockEntity",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExternalProgrammsInfos_EplanBlocks_EplanId",
                table: "ExternalProgrammsInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_ExternalProgrammsInfos_RevitBlockEntity_RevitId",
                table: "ExternalProgrammsInfos");

            migrationBuilder.AlterColumn<long>(
                name: "RevitId",
                table: "ExternalProgrammsInfos",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "EplanId",
                table: "ExternalProgrammsInfos",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ExternalProgrammsInfos_EplanBlocks_EplanId",
                table: "ExternalProgrammsInfos",
                column: "EplanId",
                principalTable: "EplanBlocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExternalProgrammsInfos_RevitBlockEntity_RevitId",
                table: "ExternalProgrammsInfos",
                column: "RevitId",
                principalTable: "RevitBlockEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
