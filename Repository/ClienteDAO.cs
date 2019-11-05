
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ClienteDAO
    {
        private readonly Context _ctx;
        private readonly ContaDAO _contaDAO;
        public ClienteDAO(Context _context, ContaDAO _ContaDAO)
        {
            _ctx = _context;
            _contaDAO = _ContaDAO;
        }
        
        public bool CadastrarCliente(Cliente c)
        {
            if (BuscarClientePorCpf(c) == null)
            {
                _ctx.Clientes.Add(c);
                _ctx.SaveChanges();

                return true;
            }
            return false;
        }
        public void RemoverCliente(Cliente c)
        {
            Conta conta = new Conta();
            Cliente cliente = new Cliente();
            cliente = c;
            conta.Cliente = cliente;
            conta = _contaDAO.BuscarContaPorCpfCliente(conta);
            if (conta == null) {
                _ctx.Clientes.Remove(cliente);
            }
            else
            {
                _contaDAO.RemoverConta(conta);
                _ctx.Clientes.Remove(cliente);
            }
            _ctx.SaveChanges();
        }

        public void AlterarCliente(Cliente c)
        {
            _ctx.Clientes.Update(c);
            _ctx.SaveChanges();
        }

        public Cliente BuscarClientePorCpf(Cliente c)
        {
            return _ctx.Clientes.SingleOrDefault(x => x.Cpf.Equals(c.Cpf));
        }

        public List<Cliente> ListarClientes()
        {
            return _ctx.Clientes.ToList();
        }
    }
}
