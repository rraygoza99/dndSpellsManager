using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Model.Entities
{
    public class Spell
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public ICollection<SpellSpellbook> SpellSpellbooks { get; set; }
        public ICollection<SpellMaterial> SpellMaterials { get; set; }
    }
}
