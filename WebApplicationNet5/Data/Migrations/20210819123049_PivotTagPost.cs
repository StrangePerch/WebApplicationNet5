using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicationNet5.Data.Migrations
{
    public partial class PivotTagPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostTag_Posts_PostId",
                table: "PostTag");

            migrationBuilder.DropForeignKey(
                name: "FK_PostTag_Tags_TagsId",
                table: "PostTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostTag",
                table: "PostTag");

            migrationBuilder.RenameTable(
                name: "PostTag",
                newName: "PivotProductTag");

            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "PivotProductTag",
                newName: "PostsId");

            migrationBuilder.RenameIndex(
                name: "IX_PostTag_TagsId",
                table: "PivotProductTag",
                newName: "IX_PivotProductTag_TagsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PivotProductTag",
                table: "PivotProductTag",
                columns: new[] { "PostsId", "TagsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PivotProductTag_Posts_PostsId",
                table: "PivotProductTag",
                column: "PostsId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PivotProductTag_Tags_TagsId",
                table: "PivotProductTag",
                column: "TagsId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PivotProductTag_Posts_PostsId",
                table: "PivotProductTag");

            migrationBuilder.DropForeignKey(
                name: "FK_PivotProductTag_Tags_TagsId",
                table: "PivotProductTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PivotProductTag",
                table: "PivotProductTag");

            migrationBuilder.RenameTable(
                name: "PivotProductTag",
                newName: "PostTag");

            migrationBuilder.RenameColumn(
                name: "PostsId",
                table: "PostTag",
                newName: "PostId");

            migrationBuilder.RenameIndex(
                name: "IX_PivotProductTag_TagsId",
                table: "PostTag",
                newName: "IX_PostTag_TagsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostTag",
                table: "PostTag",
                columns: new[] { "PostId", "TagsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PostTag_Posts_PostId",
                table: "PostTag",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostTag_Tags_TagsId",
                table: "PostTag",
                column: "TagsId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
