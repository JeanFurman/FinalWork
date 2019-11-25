using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        [Route("ListarTodos")]
        public IActionResult ListarTodos()
        {
            return Ok(_clienteDAO.ListarClientes());
        }

    }
}