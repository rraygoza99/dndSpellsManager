﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BL.BusinessLogic.ViewModel
{
    public class SpellViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
    }

    public class SpellsKnownViewModel
    {
        public SpellsKnownViewModel()
        {
            Level1 = new List<SpellViewModel>();
            Level2 = new List<SpellViewModel>();
            Level3 = new List<SpellViewModel>();
            Level4 = new List<SpellViewModel>();
            Level5 = new List<SpellViewModel>();
            Level6 = new List<SpellViewModel>();
            Level7 = new List<SpellViewModel>();
            Level8 = new List<SpellViewModel>();
            Level9 = new List<SpellViewModel>();
            Cantrips = new List<SpellViewModel>();
        }
        public List<SpellViewModel> Level1 { get; set; }
        public List<SpellViewModel> Level2 { get; set; }
        public List<SpellViewModel> Level3 { get; set; }
        public List<SpellViewModel> Level4 { get; set; }
        public List<SpellViewModel> Level5 { get; set; }
        public List<SpellViewModel> Level6 { get; set; }
        public List<SpellViewModel> Level7 { get; set; }
        public List<SpellViewModel> Level8 { get; set; }
        public List<SpellViewModel> Level9 { get; set; }
        public List<SpellViewModel> Cantrips { get; set; }
    }
}