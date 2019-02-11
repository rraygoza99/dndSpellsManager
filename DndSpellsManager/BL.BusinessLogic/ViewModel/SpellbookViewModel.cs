using System;
using System.Collections.Generic;
using System.Text;

namespace BL.BusinessLogic.ViewModel
{
    public class SpellbookViewModel
    {
        public SpellbookViewModel()
        {
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdUser { get; set; }

        public SpellsKnownViewModel Spells { get; set; }
    }
}
