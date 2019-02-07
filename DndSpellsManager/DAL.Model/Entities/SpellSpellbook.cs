using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Model.Entities
{
    public class SpellSpellbook
    {
        public int IdSpellbook { get; set; }
        public int IdSpell { get; set; }
        public Spellbook Spellbook { get; set; }
        public Spell Spell { get; set; }
    }
}
