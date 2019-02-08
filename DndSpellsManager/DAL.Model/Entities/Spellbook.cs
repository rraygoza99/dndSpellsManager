using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Model.Entities
{
    public class Spellbook
    {
        public Spellbook()
        {
            Spells = new HashSet<Spell>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Spell> Spells { get; set; }
    }
}
