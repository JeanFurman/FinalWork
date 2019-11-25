using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace ContaBancariaWeb.Controllers
{
    [Authorize]
    public class TransacaoController : Controller
    {
        private readonly ContaDAO _contaDAO;
        private readonly ClienteDAO _clienteDAO;
        private readonly UserManager<ContaLogada> _userManager;
        private readonly SignInManager<ContaLogada> _signInManager;
        public TransacaoController(ContaDAO contaDAO, ClienteDAO clienteDAO, UserManager<ContaLogada> userManager,
            SignInManager<ContaLogada> signInManager)
        {
            _contaDAO = contaDAO;
            _clienteDAO = clienteDAO;
            _signInManager = signInManager;
            _userManager = userManager;

        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult FormTransacao()
        {
            return View();
        }
        public IActionResult Saque()
        {
            return View();
        }
        public IActionResult VerSaldo()
        {
            return View();
        }
        public IActionResult Depositar()
        {
            return View();
        }
        public IActionResult Transferencia()
        {
            return View();
        }
        public IActionResult Emprestimo()
        {
            return View();
        }

        private int GetContaSession()
        {
            return Convert.ToInt32(_userManager.GetUserName(User));
        }
    }
}