using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace ContaBancariaWeb.Controllers
{
    public class ContaController : Controller
    {
        private readonly ContaDAO _contaDAO;
        private readonly ClienteDAO _clienteDAO;

        public ContaController(ContaDAO contaDAO, ClienteDAO clienteDAO)
        {
            _contaDAO = contaDAO;
            _clienteDAO = clienteDAO;
        }
        public IActionResult Index()
        {

            return View();
        }
        public IActionResult Criar()
        {
            Conta conta = new Conta();

            return View(conta);
        }
        [HttpPost]
        public IActionResult Criar(Conta conta, string txtCpf)
        {
            if (ModelState.IsValid)
            {
                Cliente cliente = new Cliente();
                cliente = _clienteDAO.BuscarClientePorCpf(txtCpf);
                if (cliente != null)
                {
                    conta.Cliente = cliente;
                    if (_contaDAO.CriarConta(conta))
                    {
                        return RedirectToAction("/Cliente/Index");
                    }
                    ModelState.AddModelError("", "Esta conta já existe!");
                }
                ModelState.AddModelError("", "Cliente não existe !");

            }
            return View(conta);

        }
           
        
    }
}