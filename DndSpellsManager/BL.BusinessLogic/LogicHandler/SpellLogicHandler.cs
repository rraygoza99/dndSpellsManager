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

        public List<SpellViewModel> GetSpells(int idClass = 0, int level = -1)
        {
            var entity = _repository.GetAllIncluding<Spell>(a=> a.SpellsClass).ToList();
            entity = level > -1 ? entity.Where(a => a.Level == level).ToList() : entity;
            entity = idClass != 0 ? entity.Where(a => a.SpellsClass.Where(b => b.IdClass == idClass).FirstOrDefault() != null).ToList() : entity;
            return Mapper.Map<List<Spell>, List<SpellViewModel>>(entity.ToList());
        }

        public List<SpellViewModel> GetSpellsPreview()
        {
            var entity = _repository.GetAll<Spell>(a => new Spell() { Id = a.Id, Name = a.Name, Level = a.Level }).ToList();
            return Mapper.Map<List<Spell>, List<SpellViewModel>>(entity);
        }

        public SpellViewModel GetSpellById(int id)
        {
            var entity = _repository.GetSingle<Spell>(a => a.Id == id, false, a=> a.SpellsClass, a=> a.SpellMaterials);
            return Mapper.Map<Spell, SpellViewModel>(entity);
        }

        

        public SpellViewModel CreateSpell(SpellViewModel viewModel)
        {
            var entity = Mapper.Map<SpellViewModel, Spell>(viewModel);
            _repository.Add(entity);
            _repository.Commit();
            return Mapper.Map<Spell, SpellViewModel>(_repository.GetSingle<Spell>(a => a.Id == entity.Id));
        }

        public SpellViewModel UpdateSpell(SpellViewModel viewModel)
        {
            var entity = _repository.GetSingle<Spell>(a => a.Id == viewModel.Id);
            if (entity == null)
                throw new Exception("Spell doesnt exist.");
            entity.Level = viewModel.Level;
            entity.Name = viewModel.Name;
            entity.SpellType = viewModel.SpellType;
            _repository.Update(entity);
            _repository.Commit();
            entity = _repository.GetSingle<Spell>(a => a.Id == viewModel.Id);
            return Mapper.Map<Spell, SpellViewModel>(entity);
        }

        public void DeleteSpell(int id)
        {
            var spell = _repository.GetSingle<Spell>(a => a.Id == id);
            if (spell == null)
                throw new Exception("This spell doesn't exists");
            _repository.Delete(spell);
            _repository.Commit();
        }

        public void AddSpellList(List<SpellViewModel> viewModels)
        {
        }
       
    }
}
