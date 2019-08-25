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
            CreateMap<SpellbookViewModel, Spellbook>();
            CreateMap<Spell, SpellViewModel>();
            CreateMap<SpellViewModel, Spell>();
            CreateMap<Class, ClassViewModel>();
            CreateMap<ClassViewModel, Class>();
            CreateMap<Material, MaterialViewModel>();
            CreateMap<MaterialViewModel, Material>();
            CreateMap<SpellSpellbook, SpellSpellbookViewModel>();
            CreateMap<SpellSpellbookViewModel, SpellSpellbook>();
            CreateMap<User, UserViewModel>();
            CreateMap<UserViewModel, User>();
            CreateMap<ClassLevelStats, ClassLevelStatsViewModel>();
            CreateMap<ClassLevelStatsViewModel, ClassLevelStats>();
        }
    }
}
