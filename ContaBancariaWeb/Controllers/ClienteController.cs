using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContaBancariaWeb.Utils;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace ContaBancariaWeb.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ClienteDAO _clienteDAO;

        public ClienteController(ClienteDAO clienteDAO)
        {
            _clienteDAO = clienteDAO;
        }
        public IActionResult Index()
        {
            ViewBag.DataHora = DateTime.Now;
            return View(_clienteDAO.ListarClientes());
        }

        public IActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(Cliente c)
        {
            if (ModelState.IsValid)
            {
                if (ValidacaoCpf.ValidarCpf(c.Cpf)) {

                    if (_clienteDAO.CadastrarCliente(c) == true)
                    {
                        return RedirectToAction("Index");
                    }
                    ModelState.AddModelError("", "Esse cliente já existe!");
                }
            }
            return View(c);
        }
        public IActionResult Remover(int id)
        {
            _clienteDAO.RemoverCliente(id);
            return RedirectToAction("Index");
        }
         
        public IActionResult Alterar(int id)
        {
            return View(_clienteDAO.ListarPorId(id));
        }
        [HttpPost]
        public IActionResult Alterar(Cliente c)
        {
            _clienteDAO.AlterarCliente(c);
            return RedirectToAction("Index");
        }
    }
}