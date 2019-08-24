using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL.BusinessLogic.LogicHandler;
using BL.BusinessLogic.Validations;
using BL.BusinessLogic.ViewModel;
using DAL.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SL.API.Common;

namespace SL.API.Controllers
{
    [Route("api/spell/[controller]")]
    [ApiController]
    public class SpellController : BaseController
    {
        private readonly SpellLogicHandler _spellLogicHandler;
        private readonly IRequestHandler _requestHandler;

        public SpellController(IResponseFormatter responseFormatter, DndRepository dndRepository, IRequestHandler requestHandler, SpellLogicHandler spellLogicHandler) :base(responseFormatter, dndRepository)
        {
            _requestHandler = requestHandler;
            _spellLogicHandler = spellLogicHandler;
        }

        [HttpGet("spell", Name = "GetSpells")]
        public IActionResult GetSpells(int idClass, int level = -1)
        {
            var viewModel = new List<SpellViewModel>();
            try
            {
                viewModel = _spellLogicHandler.GetSpells(idClass, level);
            }
            catch (Exception ex)
            {
                _responseFormatter.SetError(ex);
                return new BadRequestObjectResult(_responseFormatter.GetResponse());
            }
            _responseFormatter.Add("spells", viewModel);
            return new OkObjectResult(_responseFormatter.GetResponse());
        }

        [HttpGet("spell/{id}", Name ="GetSpellById")]
        public IActionResult GetSpellById(int id)
        {
            var viewModel = new SpellViewModel();
            try
            {
                viewModel = _spellLogicHandler.GetSpellById(id);
            }
            catch (Exception ex)
            {
                _responseFormatter.SetError(ex);
                return new BadRequestObjectResult(_responseFormatter.GetResponse());
            }
            _responseFormatter.Add("spell", viewModel);
            return new OkObjectResult(_responseFormatter.GetResponse());
        }

        [HttpPost("spell", Name = "CreateSpell")]
        public IActionResult CreateSpell([FromBody] JObject jsonData)
        {
            var validation = _requestHandler.ViewModelValidation<SpellViewModel>(jsonData, "spell", new SpellViewModelValidator());
            if (validation.Result != null)
                return validation.Result;
            var viewModel = validation.ViewModel;
            try
            {
                viewModel = _spellLogicHandler.CreateSpell(viewModel);
            }
            catch (Exception ex)
            {
                _responseFormatter.SetError(ex);
                return new BadRequestObjectResult(_responseFormatter.GetResponse());
            }
            _responseFormatter.Add("spell", viewModel);
            return new OkObjectResult(_responseFormatter.GetResponse());
        }

        [HttpPut("spell", Name = "UpdateSpell")]
        public IActionResult UpdateSpell([FromBody] JObject jsonData)
        {
            var result = _requestHandler.ViewModelValidation(jsonData, "spell", new SpellViewModelValidator());
            if (result.Result != null)
                return result.Result;
            var viewModel = result.ViewModel;
            try
            {
                viewModel = _spellLogicHandler.UpdateSpell(viewModel);
            }
            catch (Exception ex)
            {
                _responseFormatter.SetError(ex);
                return new BadRequestObjectResult(_responseFormatter.GetResponse());
            }
            _responseFormatter.Add("spell", viewModel);
            return new OkObjectResult(_responseFormatter.GetResponse());
        }

        [HttpDelete("spell/{id}", Name = "DeleteSpell")]
        public IActionResult DeleteSpell(int id)
        {
            try
            {
                _spellLogicHandler.DeleteSpell(id);
            }
            catch (Exception ex)
            {
                _responseFormatter.SetError(ex);
                return new BadRequestObjectResult(_responseFormatter.GetResponse());
            }
            _responseFormatter.Add("spell", "Spell deleted succefully");
            return new OkObjectResult(_responseFormatter.GetResponse());
        }
    }
}