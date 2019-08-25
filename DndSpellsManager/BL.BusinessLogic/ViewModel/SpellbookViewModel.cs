using DAL.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.BusinessLogic.ViewModel
{
    public class SpellbookViewModel
    {
        public SpellbookViewModel()
        {
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdUser { get; set; }
        public string NameCharacter { get; set; }
        public int IdClass { get; set; }
        public int LevelCharacter { get; set; }
        public SpellType PrincipalFocusType { get; set; }
        public SpellType? SideFocusType { get; set; }
        public SpellsKnownViewModel Spells { get; set; }
        public SpellbookFocusType SpellbookFocusType { get; set; }
    }

    public class SpellbookFocusType
    {
        public int TotalSpells { get; set; }
        public int DamageSpells { get; set; }
        public int HealingSpells { get; set; }
        public int UtilitySpells { get; set; }
        public int MobilitySpell { get; set; }
    }
}
