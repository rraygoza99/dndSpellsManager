using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Model.Entities
{
    public class SpellMaterial
    {
        public int IdSpell { get; set; }
        public int IdMaterial { get; set; }
        public int Quantity { get; set; }

        public Spell Spell { get; set; }
        public Material Material { get; set; }
    }
}
