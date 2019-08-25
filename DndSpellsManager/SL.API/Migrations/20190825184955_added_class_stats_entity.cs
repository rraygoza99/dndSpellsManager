using Microsoft.EntityFrameworkCore.Migrations;

namespace SL.API.Migrations
{
    public partial class added_class_stats_entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "class_level_stats",
                columns: table => new
                {
                    id_class = table.Column<int>(nullable: false),
                    level = table.Column<int>(nullable: false),
                    proficiency_bonus = table.Column<int>(nullable: false),
                    cantrips_known = table.Column<int>(nullable: false),
                    spells_known = table.Column<int>(nullable: false),
                    spell_slot_1 = table.Column<int>(nullable: false),
                    spell_slot_2 = table.Column<int>(nullable: false),
                    spell_slot_3 = table.Column<int>(nullable: false),
                    spell_slot_4 = table.Column<int>(nullable: false),
                    spell_slot_5 = table.Column<int>(nullable: false),
                    spell_slot_6 = table.Column<int>(nullable: false),
                    spell_slot_7 = table.Column<int>(nullable: false),
                    spell_slot_8 = table.Column<int>(nullable: false),
                    spell_slot_9 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_class_level_stats", x => new { x.id_class, x.level });
                    table.ForeignKey(
                        name: "FK_class_level_stats_class_id_class",
                        column: x => x.id_class,
                        principalTable: "class",
                        principalColumn: "id_class",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "class_level_stats");
        }
    }
}
