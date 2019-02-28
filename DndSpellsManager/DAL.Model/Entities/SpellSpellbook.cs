using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Model.Entities
{
    [Table("spell_spellbook")]
    public class SpellSpellbook
    {
        [Column("id_spellbook")]
        public int IdSpellbook { get; set; }

        [Column("id_spell")]
        public int IdSpell { get; set; }

        [InverseProperty("SpellbookSpells"), ForeignKey("IdSpellbook")]
        public Spellbook Spellbook { get; set; }

        [InverseProperty("SpellbookSpells"), ForeignKey("IdSpell")]
        public Spell Spell { get; set; }
    }
}
