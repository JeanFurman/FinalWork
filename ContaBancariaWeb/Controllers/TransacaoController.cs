using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repository;
using System;

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
            if (TempData["Saldo"]!=null)
            {
                ViewBag.Valor = TempData["Saldo"].ToString();
            }
            return View();
        }
        public IActionResult Saque(string txtValor)
        {
            if (ModelState.IsValid)
            {
                if (_contaDAO.Sacar(Convert.ToDouble(txtValor), "Saque", GetContaSession()))
                {
                    TempData["Saldo"] = Convert.ToString(_contaDAO.VerSaldo(GetContaSession()));
                    return RedirectToAction(nameof(FormTransacao));
                }
                else
                {
                    ModelState.AddModelError("", "Erro ao Sacar!");
                }
            }
            return RedirectToAction("FormTransacao", "Transacao");

        }
        public IActionResult VerSaldo()
        {
            TempData["Saldo"] = Convert.ToString(_contaDAO.VerSaldo(GetContaSession()));
            return RedirectToAction(nameof(FormTransacao));
        }
        public IActionResult Deposito(string txtValor)
        {
            if (ModelState.IsValid)
            {
                if (_contaDAO.Depositar(null, Convert.ToDouble(txtValor), "Deposito", GetContaSession()))
                {
                    TempData["Saldo"] = Convert.ToString(_contaDAO.VerSaldo(GetContaSession()));
                    return RedirectToAction(nameof(FormTransacao));
                }
                else
                {
                    ModelState.AddModelError("", "Erro ao Sacar!");
                }
            }
            return RedirectToAction("FormTransacao", "Transacao");
        }
        public IActionResult Transferencia(Conta conta, string txtValor)
        {
            if (ModelState.IsValid)
            {
                if (_contaDAO.Tranferencia(conta, Convert.ToDouble(txtValor), "Transferência", GetContaSession()))
                {
                    return View();
                }
            }
            return View(conta);
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