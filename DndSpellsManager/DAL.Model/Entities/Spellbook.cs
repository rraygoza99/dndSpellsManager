using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Model.Entities
{
    public class Spellbook
    {
        public Spellbook()
        {
            Spells = new HashSet<SpellSpellbook>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdUser { get; set; }
        public string NameCharacter { get; set; }
        public int IdClass { get; set; }
        public int LevelCharacter { get; set; }
        public SpellType PrincipalFocusType { get; set; }
        public SpellType ? SideFocusType { get; set; }

        public ICollection<SpellSpellbook> Spells { get; set; }
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
