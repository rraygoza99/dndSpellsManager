using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using SL.API.Common;

namespace SL.API.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IResponseFormatter _responseFormatter;
        protected readonly DndRepository _dndRepository;
        public BaseController(IResponseFormatter responseFormatter, DndRepository dndRepository)
        {
            _responseFormatter = responseFormatter;
            _dndRepository = dndRepository;
        }
    }
}