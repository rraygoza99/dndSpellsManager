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
                a=> spells.Spells.ToList().Find(b=> b.IdSpell == a.IdSpell) != null
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

        public List<SpellbookViewModel> GetUsersSpellboks(int idUser)
        {
            var spellbook = _repository.GetAllWhere<Spellbook>(new List<System.Linq.Expressions.Expression<Func<Spellbook, bool>>>()
            {
                a=> a.IdUser == idUser
            }).ToList();
            return Mapper.Map<List<Spellbook>, List<SpellbookViewModel>>(spellbook);
        }

        public SpellbookViewModel GetSpellbookById(int idSpellbook)
        {
            var spellbook = _repository.GetSingle<Spellbook>(a => a.Id == idSpellbook, false, a => a.Spells);
            var viewModel = Mapper.Map<Spellbook, SpellbookViewModel>(spellbook);
            viewModel.Spells = GetSpellsBySpellbook(idSpellbook);
            return viewModel;
        }

        public SpellsKnownViewModel GetSpellsBySpellbook(int idSpellbook)
        {
            var spellbook = _repository.GetAllWhere(new List<System.Linq.Expressions.Expression<Func<Spell, bool>>>()
            {
               a=> a.SpellSpellbooks.Where(b=> b.IdSpellbook == idSpellbook).First() != null
            }).ToList();
            var spells = new SpellsKnownViewModel();
            var spellSort = Mapper.Map<List<Spell>, List<SpellViewModel>>(spellbook).ToLookup(a => a.Level);
            spells.Cantrips = spellSort[0].ToList();
            spells.Level1 = spellSort[1].ToList();
            spells.Level2 = spellSort[2].ToList();
            spells.Level3 = spellSort[3].ToList();
            spells.Level4 = spellSort[4].ToList();
            spells.Level5 = spellSort[5].ToList();
            spells.Level6 = spellSort[6].ToList();
            spells.Level7 = spellSort[7].ToList();
            spells.Level8 = spellSort[8].ToList();
            spells.Level9 = spellSort[9].ToList();
            return spells;
        }

    }
}
