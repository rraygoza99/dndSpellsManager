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
    public class SpellbookLogicHandler
    {
        private readonly DndRepository _repository;
        public SpellbookLogicHandler(DndRepository repository)
        {
            _repository = repository;
        }
        public ShoppingListViewModel GetShoppingList(int idSpellbook)
        {
            var spells = _repository.GetSingle<Spellbook>(a => a.Id == idSpellbook, false, a => a.SpellbookSpells);
            var materials = _repository.GetAllWhere<SpellMaterial>(new List<System.Linq.Expressions.Expression<Func<SpellMaterial, bool>>>()
            {
                a=> spells.SpellbookSpells.ToList().Find(b=> b.IdSpell == a.IdSpell) != null
            }, null, false, a => a.Material).ToList();

            var materialsSpellbook = new Dictionary<int, ShoppingMaterialViewModel>();
            foreach (var material in materials)
            {
                var id = material.IdMaterial;
                if (materialsSpellbook.ContainsKey(id))
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
            var spellbook = _repository.GetSingle<Spellbook>(a => a.Id == idSpellbook, false, a => a.SpellbookSpells);
            var viewModel = Mapper.Map<Spellbook, SpellbookViewModel>(spellbook);
            viewModel.Spells = GetSpellsBySpellbook(idSpellbook);
            if (spellbook.SpellbookSpells.Count() > 0)
                viewModel.SpellbookFocusType = GetFocusType(spellbook.SpellbookSpells.ToList());
            else
                viewModel.SpellbookFocusType = new SpellbookFocusType();
            return viewModel;
        }

        public SpellsKnownViewModel GetSpellsBySpellbook(int idSpellbook)
        {
            var spellSpellbook = _repository.GetAllWhere<Spell>(new List<System.Linq.Expressions.Expression<Func<Spell, bool>>>()
            {
                a=> a.SpellbookSpells.Where(b=>b.IdSpellbook == idSpellbook).Count() != 0
            }).ToList();
            
            
            var spellsKnown = ClassifySpellByLevel(Mapper.Map<List<Spell>, List<SpellViewModel>>(spellSpellbook));
            
            return spellsKnown;
        }

        public SpellbookViewModel CreateSpellbook(SpellbookViewModel viewModel)
        {
            var entity = Mapper.Map<SpellbookViewModel, Spellbook>(viewModel);
            _repository.Add(entity);
            _repository.Commit();
            entity = _repository.GetSingle<Spellbook>(a => a.Id == entity.Id);
            return Mapper.Map<Spellbook, SpellbookViewModel>(entity);
        }
        
        public SpellbookViewModel SetSpellsToSpellbook(List<SpellViewModel> spells, int idSpellbook)
        {
            _repository.DeleteWhere<SpellSpellbook>(a => a.IdSpell == idSpellbook);
            foreach(var spell in spells)
            {
                var entity = new SpellSpellbookViewModel
                {
                    IdSpell = spell.Id,
                    IdSpellbook = idSpellbook
                };
                _repository.Add(entity);
            }
            _repository.Commit();
            var spellBook = _repository.GetSingle<Spellbook>(a => a.Id == idSpellbook, false, a => a.SpellbookSpells);
                
            return Mapper.Map<Spellbook, SpellbookViewModel>(spellBook);
        }

        public SpellbookFocusType GetFocusType(int idSpellbook)
        {
            var spellBook = _repository.GetSingle<Spellbook>(a => a.Id == idSpellbook, false, a => a.SpellbookSpells);
            var spells = _repository.GetAllWhere<Spell>(new List<System.Linq.Expressions.Expression<Func<Spell, bool>>>()
            {
                a=> spellBook.SpellbookSpells.Where(b=> b.IdSpell == a.Id).First() != null
            });

            var focusType = new SpellbookFocusType
            {
                TotalSpells = spellBook.SpellbookSpells.Count(),
                DamageSpells = spells.Where(a => a.SpellType == SpellType.Damage).Count(),
                HealingSpells = spells.Where(a => a.SpellType == SpellType.Healing).Count(),
                MobilitySpell = spells.Where(a => a.SpellType == SpellType.Mobility).Count(),
                UtilitySpells = spells.Where(a => a.SpellType == SpellType.Utility).Count()
            };

            return focusType;
        }

        public SpellbookFocusType GetFocusType(List<SpellSpellbook> spellsBook)
        {
            var spells = _repository.GetAllWhere<Spell>(new List<System.Linq.Expressions.Expression<Func<Spell, bool>>>()
            {
                a=> spellsBook.Where(b=> b.IdSpell == a.Id).First() != null
            }).ToList();

            var focusType = new SpellbookFocusType
            {
                TotalSpells = spellsBook.Count(),
                DamageSpells = spells.Where(a => a.SpellType == SpellType.Damage).Count(),
                HealingSpells = spells.Where(a => a.SpellType == SpellType.Healing).Count(),
                MobilitySpell = spells.Where(a => a.SpellType == SpellType.Mobility).Count(),
                UtilitySpells = spells.Where(a => a.SpellType == SpellType.Utility).Count()
            };

            return focusType;
        }

        public SpellsKnownViewModel ClassifySpellByLevel(List<SpellViewModel> spells)
        {
            SpellsKnownViewModel spellsKnown = new SpellsKnownViewModel();
            var spellSort = spells.ToLookup(a => a.Level);
            spellsKnown.Cantrips = spellSort[0].ToList();
            spellsKnown.Level1 = spellSort[1].ToList();
            spellsKnown.Level2 = spellSort[2].ToList();
            spellsKnown.Level3 = spellSort[3].ToList();
            spellsKnown.Level4 = spellSort[4].ToList();
            spellsKnown.Level5 = spellSort[5].ToList();
            spellsKnown.Level6 = spellSort[6].ToList();
            spellsKnown.Level7 = spellSort[7].ToList();
            spellsKnown.Level8 = spellSort[8].ToList();
            spellsKnown.Level9 = spellSort[9].ToList();
            return spellsKnown;
        }
    }
}
