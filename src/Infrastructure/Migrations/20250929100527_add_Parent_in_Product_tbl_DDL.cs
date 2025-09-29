using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add_Parent_in_Product_tbl_DDL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ParentPath",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ParentId",
                table: "Products",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Products_ParentId",
                table: "Products",
                column: "ParentId",
                principalTable: "Products",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Products_ParentId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ParentId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ParentPath",
                table: "Products");
        }
    }
}
