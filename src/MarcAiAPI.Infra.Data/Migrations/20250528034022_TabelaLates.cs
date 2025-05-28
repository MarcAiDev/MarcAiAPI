using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarcAiAPI.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class TabelaLates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Longitude",
                table: "StoreAddress",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<string>(
                name: "Latitude",
                table: "StoreAddress",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<string>(
                name: "Longitude",
                table: "Marketplaces",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<string>(
                name: "Latitude",
                table: "Marketplaces",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Longitude",
                table: "StoreAddress",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<decimal>(
                name: "Latitude",
                table: "StoreAddress",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<decimal>(
                name: "Longitude",
                table: "Marketplaces",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<decimal>(
                name: "Latitude",
                table: "Marketplaces",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);
        }
    }
}
