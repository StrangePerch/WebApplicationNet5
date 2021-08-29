using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicationNet5.Data.Migrations
{
    public partial class CatalogChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Catalogs_Catalogs_ParentCatalogId",
                table: "Catalogs");

            migrationBuilder.AlterColumn<int>(
                name: "ParentCatalogId",
                table: "Catalogs",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Catalogs_Catalogs_ParentCatalogId",
                table: "Catalogs",
                column: "ParentCatalogId",
                principalTable: "Catalogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Catalogs_Catalogs_ParentCatalogId",
                table: "Catalogs");

            migrationBuilder.AlterColumn<int>(
                name: "ParentCatalogId",
                table: "Catalogs",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Catalogs_Catalogs_ParentCatalogId",
                table: "Catalogs",
                column: "ParentCatalogId",
                principalTable: "Catalogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
