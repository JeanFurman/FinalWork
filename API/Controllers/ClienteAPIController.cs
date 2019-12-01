using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace API.Controllers
{
    [Route("api/Cliente")]
    [ApiController]
    public class ClienteAPIController : ControllerBase
    {
        private readonly ClienteDAO _clienteDAO;
        public ClienteAPIController(ClienteDAO clienteDAO)
        {
            _clienteDAO = clienteDAO;
        }
        //GET: api/Cliente/ListarTodos
        [HttpGet]
        [Route("ListarClientes")]
        public IActionResult ListarClientes()
        {
            return Ok(_clienteDAO.ListarClientes());
        }

        [HttpGet]
        [Route("BuscarClientePorCpf/{cpf}")]
        public IActionResult BuscarClientePorCpf([FromRoute]string cpf)
        {
            Cliente c = _clienteDAO.BuscarClientePorCpf(cpf);
            if (c != null)
            {
                return Ok(c);
            }
            return NotFound(new { msg = "Cliente não encontrado!" });
        }

        [HttpPost]
        [Route("CadastrarCliente")]
        public IActionResult CadastrarCliente([FromBody] Cliente c)
        {
            if (ModelState.IsValid)
            {
                if (_clienteDAO.CadastrarCliente(c))
                {
                    return Created("", c);
                }
                return Conflict(new { msg = "Esse cliente já existe!" });
            }
            return BadRequest(ModelState);  
        }
    }
}