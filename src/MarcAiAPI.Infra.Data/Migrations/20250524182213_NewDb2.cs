using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarcAiAPI.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewDb2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreAddress_Stores_StoreId",
                table: "StoreAddress");

            migrationBuilder.AddForeignKey(
                name: "FK_StoreAddress_Stores_StoreId",
                table: "StoreAddress",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "StoreId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreAddress_Stores_StoreId",
                table: "StoreAddress");

            migrationBuilder.AddForeignKey(
                name: "FK_StoreAddress_Stores_StoreId",
                table: "StoreAddress",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "StoreId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
