using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Model.Entities
{
    public class SpellClass
    {
        public int IdSpell { get; set; }
        public int IdClass { get; set; }
        public Class Class { get; set; }
        public Spell Spell { get; set; }
    }
}
