using Microsoft.EntityFrameworkCore.Migrations;

namespace SL.API.Migrations
{
    public partial class added_properties_spell_class : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "components",
                table: "spell",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "spell",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "duration",
                table: "spell",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "magic_school",
                table: "spell",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "range",
                table: "spell",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "components",
                table: "spell");

            migrationBuilder.DropColumn(
                name: "description",
                table: "spell");

            migrationBuilder.DropColumn(
                name: "duration",
                table: "spell");

            migrationBuilder.DropColumn(
                name: "magic_school",
                table: "spell");

            migrationBuilder.DropColumn(
                name: "range",
                table: "spell");
        }
    }
}
