using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SL.API.Migrations
{
    public partial class first_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "class",
                columns: table => new
                {
                    id_class = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_class", x => x.id_class);
                });

            migrationBuilder.CreateTable(
                name: "material",
                columns: table => new
                {
                    id_material = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(nullable: true),
                    gold_cost = table.Column<int>(nullable: false),
                    electrum_cost = table.Column<int>(nullable: false),
                    cupper_cost = table.Column<int>(nullable: false),
                    silver_cost = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_material", x => x.id_material);
                });

            migrationBuilder.CreateTable(
                name: "spell",
                columns: table => new
                {
                    id_spell = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    level = table.Column<int>(nullable: false),
                    spell_type = table.Column<int>(nullable: false),
                    deleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spell", x => x.id_spell);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id_user = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id_user);
                });

            migrationBuilder.CreateTable(
                name: "spell_class",
                columns: table => new
                {
                    id_spell = table.Column<int>(nullable: false),
                    id_class = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spell_class", x => new { x.id_class, x.id_spell });
                    table.ForeignKey(
                        name: "FK_spell_class_class_id_class",
                        column: x => x.id_class,
                        principalTable: "class",
                        principalColumn: "id_class",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_spell_class_spell_id_spell",
                        column: x => x.id_spell,
                        principalTable: "spell",
                        principalColumn: "id_spell",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "spell_material",
                columns: table => new
                {
                    id_spell = table.Column<int>(nullable: false),
                    id_material = table.Column<int>(nullable: false),
                    quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spell_material", x => new { x.id_material, x.id_spell });
                    table.ForeignKey(
                        name: "FK_spell_material_material_id_material",
                        column: x => x.id_material,
                        principalTable: "material",
                        principalColumn: "id_material",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_spell_material_spell_id_spell",
                        column: x => x.id_spell,
                        principalTable: "spell",
                        principalColumn: "id_spell",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "spellbool",
                columns: table => new
                {
                    id_spellbook = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    id_user = table.Column<int>(nullable: false),
                    name_character = table.Column<string>(nullable: true),
                    id_class = table.Column<int>(nullable: false),
                    level_character = table.Column<int>(nullable: false),
                    principal_focus_type = table.Column<int>(nullable: false),
                    side_focus_type = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spellbool", x => x.id_spellbook);
                    table.ForeignKey(
                        name: "FK_spellbool_user_id_user",
                        column: x => x.id_user,
                        principalTable: "user",
                        principalColumn: "id_user",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "spell_spellbook",
                columns: table => new
                {
                    id_spellbook = table.Column<int>(nullable: false),
                    id_spell = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spell_spellbook", x => new { x.id_spell, x.id_spellbook });
                    table.ForeignKey(
                        name: "FK_spell_spellbook_spell_id_spell",
                        column: x => x.id_spell,
                        principalTable: "spell",
                        principalColumn: "id_spell",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_spell_spellbook_spellbool_id_spellbook",
                        column: x => x.id_spellbook,
                        principalTable: "spellbool",
                        principalColumn: "id_spellbook",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_spell_class_id_spell",
                table: "spell_class",
                column: "id_spell");

            migrationBuilder.CreateIndex(
                name: "IX_spell_material_id_spell",
                table: "spell_material",
                column: "id_spell");

            migrationBuilder.CreateIndex(
                name: "IX_spell_spellbook_id_spellbook",
                table: "spell_spellbook",
                column: "id_spellbook");

            migrationBuilder.CreateIndex(
                name: "IX_spellbool_id_user",
                table: "spellbool",
                column: "id_user");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "spell_class");

            migrationBuilder.DropTable(
                name: "spell_material");

            migrationBuilder.DropTable(
                name: "spell_spellbook");

            migrationBuilder.DropTable(
                name: "class");

            migrationBuilder.DropTable(
                name: "material");

            migrationBuilder.DropTable(
                name: "spell");

            migrationBuilder.DropTable(
                name: "spellbool");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
