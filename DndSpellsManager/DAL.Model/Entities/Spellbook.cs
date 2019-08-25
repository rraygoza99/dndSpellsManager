using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Model.Entities
{
    [Table("spellbook")]
    public class Spellbook
    {
        public Spellbook()
        {
            SpellbookSpells = new HashSet<SpellSpellbook>();
        }

        [Column("id_spellbook")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("id_user")]
        public int IdUser { get; set; }

        [Column("name_character")]
        public string NameCharacter { get; set; }

        [Column("id_class")]
        public int IdClass { get; set; }

        [Column("level_character")]
        public int LevelCharacter { get; set; }

        [Column("principal_focus_type")]
        public SpellType PrincipalFocusType { get; set; }

        [Column("side_focus_type")]
        public SpellType ? SideFocusType { get; set; }

        [InverseProperty("Spellbook")]
        public ICollection<SpellSpellbook> SpellbookSpells { get; set; }

        [InverseProperty("Spellbooks"), ForeignKey("IdUser")]
        public User User { get; set; }
    }

    public enum Classes
    {
        Bard,
        Barbarian,
        Druid,
        Cleric,
        Figther,
        Monk,
        Paladin,
        Ranger,
        Rogue,
        Sorcerer,
        Warlock,
        Wizard
    }
}
