using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Model.Entities
{
    [Table("spell_material")]
    public class SpellMaterial
    {
        [Column("id_spell")]
        public int IdSpell { get; set; }

        [Column("id_material")]
        public int IdMaterial { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }

        [InverseProperty("SpellMaterials"), ForeignKey("IdSpell")]
        public Spell Spell { get; set; }

        [InverseProperty("SpellMaterials"), ForeignKey("IdMaterial")]
        public Material Material { get; set; }
    }
}
