using ContaBancariaWeb.Utils;
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
            if (TempData["ErroDeposito"] != null) { ModelState.AddModelError("", TempData["ErroDeposito"].ToString()); }
            if (TempData["ErroSaque"] != null) { ModelState.AddModelError("", TempData["ErroSaque"].ToString()); }
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
                try
                {
                    if (_contaDAO.Sacar(Convert.ToDouble(txtValor), "Saque", GetContaSession()))
                    {
                        TempData["Saldo"] = Convert.ToString(_contaDAO.VerSaldo(GetContaSession()));
                        return RedirectToAction(nameof(FormTransacao));
                    }
                    else
                    {
                        TempData["ErroSaque"] = "Erro ao Sacar!";
                    }
                }
                catch (Exception e)
                {
                    TempData["ErroSaque"] = "Erro ao Sacar!";
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
                try
                {
                    if (_contaDAO.Depositar(null, Convert.ToDouble(txtValor), "Deposito", GetContaSession()))
                    {
                        TempData["Saldo"] = Convert.ToString(_contaDAO.VerSaldo(GetContaSession()));
                        return RedirectToAction(nameof(FormTransacao));
                    }
                    else
                    {
                        TempData["ErroDeposito"] = "Erro ao Depositar!";
                    }
                }
                catch (Exception e)
                {
                    TempData["ErroDeposito"] = "Erro ao Depositar!";
                }
            }
            return RedirectToAction("FormTransacao", "Transacao");
        }
        public IActionResult Transferencia()
        {
            if (TempData["ErroTransferencia"] != null) { ModelState.AddModelError("", TempData["ErroTransferencia"].ToString()); }
            return View();
        }

        [HttpPost]
        public IActionResult Transferir(string nrConta, string txtValor)
        {
            try
            {
                Conta conta = new Conta();
                conta = _contaDAO.BuscarContaPorNumero(Convert.ToInt32(nrConta));
                if (ModelState.IsValid)
                {
                    if (!_contaDAO.Tranferencia(conta, Convert.ToDouble(txtValor), "Transferência", GetContaSession()))
                    {
                        TempData["ErroTransferencia"] = "Erro ao Transferir!";
                    }

                }
            }
            catch (Exception e)
            {
                TempData["ErroTransferencia"] = "Erro ao Transferir!";
            }
            return RedirectToAction("Transferencia", "Transacao");
        }
        public IActionResult Emprestimo()
        {
            if (TempData["ErroEmprestimo"] != null) { ModelState.AddModelError("", TempData["ErroEmprestimo"].ToString()); }
            if (TempData["ErroEmprestimoD"] != null) { ModelState.AddModelError("", TempData["ErroEmprestimoD"].ToString()); }
            if (TempData["ErroEmprestimoV"] != null) { ModelState.AddModelError("", TempData["ErroEmprestimoV"].ToString()); }
            return View();
        }

        [HttpPost]
        public IActionResult Emprestimo(string txtValor)
        {
            try
            {
                Conta c = new Conta();
                c = _contaDAO.BuscarContaPorNumero(GetContaSession());
                double value = Convert.ToDouble(txtValor);
                if (c.Divida == 0 && value >= 100)
                {
                    if (c.Saldo <= 1000 && value > 1000)
                    {
                        TempData["ErroEmprestimo"] = "Valor inválido! Insira o valor de acordo com a tabela!";
                    }
                    else if (c.Saldo > 1000 && c.Saldo <= 1500 && value > 2000)
                    {
                        TempData["ErroEmprestimo"] = "Valor inválido! Insira o valor de acordo com a tabela!";
                    }
                    else if (c.Saldo > 1500 && c.Saldo <= 2000 && value > 3000)
                    {
                        TempData["ErroEmprestimo"] = "Valor inválido! Insira o valor de acordo com a tabela!";
                    }
                    else if (c.Saldo > 2000 && value > 4000)
                    {
                        TempData["ErroEmprestimo"] = "Valor inválido! Insira o valor de acordo com a tabela!";
                    }
                    else
                    {
                        if (_contaDAO.Depositar(null, value, "Empréstimo", GetContaSession()))
                        {
                            c.Divida = value;
                            c.DataDivida = DateTime.Now;
                            _contaDAO.Update(c);

                        }
                        else { TempData["ErroEmprestimoD"] = "Erro no Empréstimo!"; }

                    }
                }
                else
                {
                    TempData["ErroEmprestimoV"] = "Divida pendente ou valor inferior a 100!";

                }
            }
            catch (Exception e)
            {
                TempData["ErroEmprestimoD"] = "Erro no Empréstimo!";
            }
            return RedirectToAction("Emprestimo", "Transacao");
        }

        public IActionResult PDivida()
        {
            Conta c = new Conta();
            c = _contaDAO.BuscarContaPorNumero(GetContaSession());
            if (c.Divida >= 100)
            {
                double divida = CalcularDivida();
                ViewBag.Divida = divida.ToString();
            }
            if (TempData["ErroDivida"] != null)
            {
                ModelState.AddModelError("", TempData["ErroDivida"].ToString());
            }
            return View();
        }

        public IActionResult PagarDivida(string txtDivida)
        {
            try
            {
                double divida = Convert.ToDouble(txtDivida);
                if (_contaDAO.Sacar(divida, "Dívida Paga", GetContaSession()))
                {
                    Conta c = new Conta();
                    c = _contaDAO.BuscarContaPorNumero(GetContaSession());
                    c.Divida = 0;
                    c.DataDivida = null;
                    _contaDAO.Update(c);
                }
                else
                {
                    TempData["ErroDivida"] = "Erro ao pagar a dívida!";
                }
            }
            catch (Exception e)
            {
                TempData["ErroDivida"] = "Erro ao pagar a dívida!";
            }
            return RedirectToAction("PDivida", "Transacao");
        }

        public IActionResult Extrato()
        {
            Conta c = new Conta();
            c = _contaDAO.BuscarContaPorNumero(GetContaSession());
            ViewBag.SaldoExtrato = c.Saldo.ToString();
            double Divida = CalcularDivida() * -1;
            ViewBag.DividaExtrato = Divida.ToString();  
            return View(_contaDAO.ListarTransacoes(c));
        }

        private double CalcularDivida()
        {
            Conta c = new Conta();
            c = _contaDAO.BuscarContaPorNumero(GetContaSession());
            double divida = c.Divida;
            DateTime data = (DateTime)c.DataDivida;
            string dataStr = data.ToShortDateString();
            string dataAtual = DateTime.Now.ToShortDateString();
            int r = DateTime.Parse(dataAtual).Subtract(DateTime.Parse(dataStr)).Days + 1;
            for (int i = 0; i < r; i++)
            {
                divida += divida * 0.05;
            }
            return divida;
        }
        private int GetContaSession()
        {
            return Convert.ToInt32(_userManager.GetUserName(User));
        }
    }
}