using System;
using System.Collections.Generic;
using System.Text;

namespace BL.BusinessLogic.ViewModel
{
    public class MaterialViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int GoldCost { get; set; }
        public int ElectrumCost { get; set; }
        public int CupperCost { get; set; }
        public int SilverCost { get; set; }
    }
}
