using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Model.Entities
{
    public class Material
    {
        public int Id { get; set; }
        public int Description { get; set; }
        public int GoldCost { get; set; }
        public int ElectrumCost { get; set; }
        public int CupperCost { get; set; }
        public int SilverCost { get; set; }

        public ICollection<SpellMaterial> SpellMaterials { get; set; }
    }
}
