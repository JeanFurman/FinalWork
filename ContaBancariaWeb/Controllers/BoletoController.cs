using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContaBancariaWeb.Utils;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace ContaBancariaWeb.Controllers
{
    public class BoletoController : Controller
    {
        private readonly ContaDAO _contaDAO;
        private readonly UserManager<ContaLogada> _userManager;
        public BoletoController(ContaDAO contaDAO, UserManager<ContaLogada> userManager)
        {
            _contaDAO = contaDAO;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            Boleto b = new Boleto();
            if (TempData["ErroBoleto"] != null) { ModelState.AddModelError("", TempData["ErroBoleto"].ToString()); }
            if (TempData["ErroSaque"] != null) { ModelState.AddModelError("", TempData["ErroSaque"].ToString()); }

            if (TempData["BCod"] != null)
            {

                b.Codigo = TempData["BCod"].ToString();
                b.NomeBanco = TempData["BNomeBanco"].ToString();
                b.Moeda = TempData["BMoeda"].ToString();
                b.Valor = Convert.ToDouble(TempData["BValor"].ToString());
                b.DataVencimento = DateTime.Parse(TempData["BData"].ToString());

            }

            return View(b);
        }

        [HttpPost]
        public IActionResult BuscarBoleto(Boleto b)
        {
            Boleto boleto = new Boleto();
            b = Validacoes.ValidarBoleto(b.Codigo);
            if (b == null)
            {
                TempData["ErroBoleto"] = "Boleto Inválido";
            }
            else
            {
                TempData["BCod"] = b.Codigo;
                TempData["BNomeBanco"] = b.NomeBanco;
                TempData["BMoeda"] = b.Moeda;
                TempData["BValor"] = b.Valor;
                TempData["BData"] = b.DataVencimento;

            }

            return RedirectToAction("Index", "Boleto"); 
        }

        [HttpPost]
        public IActionResult PagarBoleto(Boleto b)
        {
            Conta c = new Conta();
            c = _contaDAO.BuscarContaPorNumero(GetContaSession());
            if (!_contaDAO.Sacar(b.Valor, "Boleto", GetContaSession()))
            {
                TempData["ErroSaque"] = "Saldo Insuficiente";
            }
            return RedirectToAction("Index", "Boleto"); 
        }

        private int GetContaSession()
        {
            return Convert.ToInt32(_userManager.GetUserName(User));
        }
    }
}