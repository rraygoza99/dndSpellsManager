using AutoMapper;
using BL.BusinessLogic.LogicHandler;
using DAL.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.BusinessLogic.ViewModel.Mapping
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Spellbook, SpellbookViewModel>();
        }
    }
}
