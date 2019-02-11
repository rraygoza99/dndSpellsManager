using AutoMapper;
using BL.BusinessLogic.ViewModel;
using DAL.Data.Repository;
using DAL.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL.BusinessLogic.LogicHandler
{
    public class Functions
    {
        private readonly DndRepository _repository; 
        public Functions(DndRepository repository)
        {
            _repository = repository;
        }

        public void ClassifypellsByLevel(SpellbookViewModel spellbook)
        {

        }

        
    }
}
