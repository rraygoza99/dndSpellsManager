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
    public class SpellLogicHandler
    {
        private DndRepository _repository;
        public SpellLogicHandler(DndRepository repository)
        {
            _repository = repository;
        }

        public List<SpellViewModel> GetSpells()
        {
            var entity = _repository.GetAll<Spell>().ToList();
            return Mapper.Map<List<Spell>, List<SpellViewModel>>(entity);
        }

        public List<SpellViewModel> GetSpellsPreview()
        {
            var entity = _repository.GetAll<Spell>(a => new Spell() { Id = a.Id, Name = a.Name, Level = a.Level }).ToList();
            return Mapper.Map<List<Spell>, List<SpellViewModel>>(entity);
        }

        public ShoppingListViewModel GetShoppingList(int idSpellbook)
        {
            var spells = _repository.GetSingle<Spellbook>(a => a.Id == idSpellbook, false, a => a.Spells);
            var materials = _repository.GetAllWhere<SpellMaterial>(new List<System.Linq.Expressions.Expression<Func<SpellMaterial, bool>>>()
            {
                a=> spells.Spells.ToList().Find(b=> b.Id == a.IdSpell) != null
            }, null, false, a=> a.Material).ToList();

            var materialsSpellbook = new Dictionary<int, ShoppingMaterialViewModel>();
            foreach(var material in materials)
            {
                var id = material.IdMaterial;
                if(materialsSpellbook.ContainsKey(id))
                {
                    materialsSpellbook[id].Quantity += material.Quantity;
                    materialsSpellbook[id].GoldCost += material.Material.GoldCost;
                    materialsSpellbook[id].ElectrumCost += material.Material.ElectrumCost;
                    materialsSpellbook[id].SilverCost += material.Material.SilverCost;
                    materialsSpellbook[id].CupperCost += material.Material.CupperCost;
                }
                else
                {
                    materialsSpellbook.Add(id, new ShoppingMaterialViewModel()
                    {
                        Id = id,
                        Description = material.Material.Description,
                        Quantity = material.Quantity,
                        GoldCost = material.Material.GoldCost,
                        SilverCost = material.Material.SilverCost,
                        ElectrumCost = material.Material.ElectrumCost,
                        CupperCost = material.Material.CupperCost
                    });
                }
            }
            var shoppingList = new ShoppingListViewModel()
            {
                Materials = materialsSpellbook.Values.ToList(),
                TotalGold = materialsSpellbook.Sum(a => a.Value.GoldCost),
                TotalElectrum = materialsSpellbook.Sum(a => a.Value.ElectrumCost),
                TotalSilver = materialsSpellbook.Sum(a => a.Value.SilverCost),
                TotalCupper = materialsSpellbook.Sum(a => a.Value.CupperCost),
            };
            return shoppingList;
        }
    }
}
