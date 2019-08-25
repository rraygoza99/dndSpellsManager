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
    [Route("api/[controller]")]
    public class SpellbookController : BaseController
    {
        private readonly SpellbookLogicHandler _spellbookLogicHandler;
        private readonly IRequestHandler _requestHandler;
        public SpellbookController(IResponseFormatter responseFormatter, DndRepository dndRepository, IRequestHandler requestHandler, SpellbookLogicHandler spellbookLogicHandler) : base(responseFormatter, dndRepository)
        {
            _requestHandler = requestHandler;
            _spellbookLogicHandler = spellbookLogicHandler;
        }

        [HttpGet("spellbook/{id}", Name = "GetSpellbookById")]
        public IActionResult GetSpellbookById(int id)
        {
            var viewModels = new SpellbookViewModel();
            try
            {
                viewModels = _spellbookLogicHandler.GetSpellbookById(id);
            }
            catch (Exception ex)
            {
                _responseFormatter.SetError(ex);
                return new BadRequestObjectResult(_responseFormatter.GetResponse());
            }
            _responseFormatter.Add("spellbook", viewModels);
            return new OkObjectResult(_responseFormatter.GetResponse());
        }

        [HttpPost("spellbook", Name ="CreateSpellbook")]
        public IActionResult CreateSpellbook([FromBody] JObject jsonData)
        {
            var validator = _requestHandler.ViewModelValidation<SpellbookViewModel>(jsonData, "spellbook", new SpellbookViewModelValidator());
            if (validator.Result != null)
                return validator.Result;
            var viewModel = validator.ViewModel;

            try
            {
                viewModel = _spellbookLogicHandler.CreateSpellbook(viewModel);
            }
            catch (Exception ex)
            {
                _responseFormatter.SetError(ex);
                return new BadRequestObjectResult(_responseFormatter.GetResponse());
            }
            _responseFormatter.Add("spellbook", viewModel);
            return new OkObjectResult(_responseFormatter.GetResponse());
        }
    }
}