using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ContaBancariaWeb.Utils;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
            Cliente c = new Cliente();
            CpfWS cpf = new CpfWS();
            if (TempData["Cliente"] != null)
            {
                string resultado = TempData["Cliente"].ToString();
                cpf = JsonConvert.
                    DeserializeObject<CpfWS>(resultado);
                if (Convert.ToBoolean(cpf.Status)) {                  
                    c.Nome_da_Pf = cpf.Result.Nome_da_Pf;
                    c.Numero_de_Cpf = cpf.Result.Numero_de_Cpf;
                    c.Data_Nascimento = DateTime.Parse(cpf.Result.Data_Nascimento);
                }
                else
                {
                    ModelState.AddModelError("", "Dados Inválidos");
                }
            }
            return View(c);
        }
        [HttpPost]
        public IActionResult Cadastrar(Cliente c)
        {
            if (ModelState.IsValid)
            {
                if (ValidacaoCpf.ValidarCpf(c.Numero_de_Cpf)) {

                    if (_clienteDAO.CadastrarCliente(c) == true)
                    {
                        return RedirectToAction("Index");
                    }
                    ModelState.AddModelError("", "Esse cliente já existe!");
                }
            }
            return View(c);
        }
        [HttpPost]
        public IActionResult BuscarCpf(Cliente c)
        {
            string url = $"https://ws.hubdodesenvolvedor.com.br/v2/cpf/?cpf={c.Numero_de_Cpf}&data={c.Data_Nascimento.Value.ToShortDateString()}&token=72321795SpGUMOtyBn130574808";
            WebClient client = new WebClient();
            TempData["Cliente"] = client.DownloadString(url);
            return RedirectToAction(nameof(Cadastrar));
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