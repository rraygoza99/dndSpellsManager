using Microsoft.EntityFrameworkCore.Migrations;

namespace SL.API.Migrations
{
    public partial class change_spellbook_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_spell_spellbook_spellbool_id_spellbook",
                table: "spell_spellbook");

            migrationBuilder.DropForeignKey(
                name: "FK_spellbool_user_id_user",
                table: "spellbool");

            migrationBuilder.DropPrimaryKey(
                name: "PK_spellbool",
                table: "spellbool");

            migrationBuilder.RenameTable(
                name: "spellbool",
                newName: "spellbook");

            migrationBuilder.RenameIndex(
                name: "IX_spellbool_id_user",
                table: "spellbook",
                newName: "IX_spellbook_id_user");

            migrationBuilder.AddPrimaryKey(
                name: "PK_spellbook",
                table: "spellbook",
                column: "id_spellbook");

            migrationBuilder.AddForeignKey(
                name: "FK_spell_spellbook_spellbook_id_spellbook",
                table: "spell_spellbook",
                column: "id_spellbook",
                principalTable: "spellbook",
                principalColumn: "id_spellbook",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_spellbook_user_id_user",
                table: "spellbook",
                column: "id_user",
                principalTable: "user",
                principalColumn: "id_user",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_spell_spellbook_spellbook_id_spellbook",
                table: "spell_spellbook");

            migrationBuilder.DropForeignKey(
                name: "FK_spellbook_user_id_user",
                table: "spellbook");

            migrationBuilder.DropPrimaryKey(
                name: "PK_spellbook",
                table: "spellbook");

            migrationBuilder.RenameTable(
                name: "spellbook",
                newName: "spellbool");

            migrationBuilder.RenameIndex(
                name: "IX_spellbook_id_user",
                table: "spellbool",
                newName: "IX_spellbool_id_user");

            migrationBuilder.AddPrimaryKey(
                name: "PK_spellbool",
                table: "spellbool",
                column: "id_spellbook");

            migrationBuilder.AddForeignKey(
                name: "FK_spell_spellbook_spellbool_id_spellbook",
                table: "spell_spellbook",
                column: "id_spellbook",
                principalTable: "spellbool",
                principalColumn: "id_spellbook",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_spellbool_user_id_user",
                table: "spellbool",
                column: "id_user",
                principalTable: "user",
                principalColumn: "id_user",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
