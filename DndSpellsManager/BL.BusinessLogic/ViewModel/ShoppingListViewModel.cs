using System;
using System.Collections.Generic;
using System.Text;

namespace BL.BusinessLogic.ViewModel
{
    public class ShoppingListViewModel
    {
        public List<ShoppingMaterialViewModel> Materials { get; set; }
        public int TotalGold { get; set; }
        public int TotalElectrum { get; set; }
        public int TotalSilver { get; set; }
        public int TotalCupper { get; set; }
    }

    public class ShoppingMaterialViewModel : MaterialViewModel
    {
        public int Quantity { get; set; }
    }
}
