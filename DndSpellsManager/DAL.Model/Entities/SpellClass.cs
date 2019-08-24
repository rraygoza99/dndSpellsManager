using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Model.Entities
{
    [Table("spell_class")]
    public class SpellClass
    {
        [Column("id_spell")]
        public int IdSpell { get; set; }

        [Column("id_class")]
        public int IdClass { get; set; }

        [InverseProperty("SpellsClass"), ForeignKey("IdClass")]
        public Class Class { get; set; }

        [InverseProperty("SpellsClass"), ForeignKey("IdSpell")]
        public Spell Spell { get; set; }
    }
}
