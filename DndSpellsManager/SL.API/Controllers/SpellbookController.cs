using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL.BusinessLogic.LogicHandler;
using DAL.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using SL.API.Common;

namespace SL.API.Controllers
{
    
    public class SpellbookController : BaseController
    {
        private readonly SpellbookLogicHandler _spellbookLogicHandler;
        private readonly IRequestHandler _requestHandler;
        public SpellbookController(IResponseFormatter responseFormatter, DndRepository dndRepository, IRequestHandler requestHandler, SpellbookLogicHandler spellbookLogicHandler) : base(responseFormatter, dndRepository)
        {
            _requestHandler = requestHandler;
            _spellbookLogicHandler = spellbookLogicHandler;
        }
    }
}