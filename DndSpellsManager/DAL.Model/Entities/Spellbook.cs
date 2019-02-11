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
        public ICollection<SpellSpellbook> Spells { get; set; }
    }
}
