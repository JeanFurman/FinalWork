using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContaBancariaWeb.Controllers
{
    [Authorize]
    public class TransacaoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}