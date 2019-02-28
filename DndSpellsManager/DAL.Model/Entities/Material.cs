using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Model.Entities
{
    [Table("material")]
    public class Material
    {
        public Material()
        {
            SpellMaterials = new HashSet<SpellMaterial>();
        }

        [Column("id_material")]
        public int Id { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("gold_cost")]
        public int GoldCost { get; set; }

        [Column("electrum_cost")]
        public int ElectrumCost { get; set; }

        [Column("cupper_cost")]
        public int CupperCost { get; set; }

        [Column("silver_cost")]
        public int SilverCost { get; set; }

        [InverseProperty("Material")]
        public ICollection<SpellMaterial> SpellMaterials { get; set; }
    }
}
