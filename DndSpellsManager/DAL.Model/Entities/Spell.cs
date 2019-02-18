using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Model.Entities
{
    public class Spell
    {
        public Spell()
        {
            SpellSpellbooks = new HashSet<SpellSpellbook>();
            SpellMaterials = new HashSet<SpellMaterial>();
            SpellClasses = new HashSet<SpellClass>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public SpellType SpellType { get; set; }
        public ICollection<SpellSpellbook> SpellSpellbooks { get; set; }
        public ICollection<SpellMaterial> SpellMaterials { get; set; }
        public ICollection<SpellClass> SpellClasses { get; set; }
    }

    public enum SpellType
    {
        Damage = 1,
        Healing = 2,
        Utility = 3,
        Mobility = 4
    }
}
