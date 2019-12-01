using Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ContaDAO
    {
        private readonly Context _ctx;
        private readonly TransacaoDAO _transacaoDAO;
        private readonly UserManager<ContaLogada> _userManager;
        public ContaDAO(Context _context, TransacaoDAO transacaoDAO, UserManager<ContaLogada> userManager)
        {
            _ctx = _context;
            _transacaoDAO = transacaoDAO;
            _userManager = userManager;
        }
        public bool CriarConta(Conta c)
        {
            if (BuscarContaPorNumero(c.NumeroConta) == null)
            {
                _ctx.Contas.Add(c);
                _ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public void RemoverConta(Conta c)
        {
            foreach (Transacao t in ListarTransacoes(c))
            {
                _ctx.Transacoes.Remove(t);
            }        
            _ctx.Contas.Remove(c);
            _ctx.SaveChanges();
        }


        public Conta BuscarContaPorNumero(int c)
        {
            return _ctx.Contas.SingleOrDefault
               (x => x.NumeroConta.Equals(c));
        }

        public bool Depositar(Conta conta, double valor, string descricao, int nrConta)
        {
            if (conta == null)
            {
                if (valor > 0)
                {
                    Conta c = new Conta();
                    c = BuscarContaPorNumero(nrConta);
                    Transacao t = new Transacao();
                    t.NumeroConta = c.NumeroConta;
                    t.Valor = valor;
                    t.Descricao = descricao;
                    _transacaoDAO.CadastrarTransacao(t);
                    c.Transacoes.Add(t);
                    c.Saldo += valor;
                    _ctx.Update(c);
                    _ctx.SaveChanges();

                    return true;
                }
                return false;
            }
            else
            {
                Transacao t = new Transacao();
                t.NumeroConta = conta.NumeroConta;
                t.Valor = valor;
                t.Descricao = descricao;
                _transacaoDAO.CadastrarTransacao(t);
                conta.Transacoes.Add(t);
                conta.Saldo += valor;
                _ctx.Update(conta);
                _ctx.SaveChanges();
                return true;
            }
        }

        public bool Sacar(double valor, string descricao, int nrConta)
        {
            Conta c = new Conta();
            c = BuscarContaPorNumero(nrConta);
            if (c.Saldo - valor >= 0 && valor > 0)
            {
                Transacao t = new Transacao();
                t.NumeroConta = nrConta;
                t.Valor = valor * -1.0;
                t.Descricao = descricao;
                _transacaoDAO.CadastrarTransacao(t);
                c.Transacoes.Add(t);
                c.Saldo -= valor;
                _ctx.Update(c);
                _ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public double VerSaldo(int nrConta)
        {
            Conta c = new Conta();
            c = BuscarContaPorNumero(nrConta);
            return c.Saldo;
        }

        public bool Tranferencia(Conta conta, double valor, string v, int nrConta)
        {
            if (conta != null)
            {
                if (Sacar(valor, "Tranferência", nrConta))
                {
                    return Depositar(conta, valor, "Tranferência", nrConta);
                }
                return false;
            }
            return false;
        }

        public Conta BuscarContaPorCpfCliente(Conta c)
        {
            return _ctx.Contas.SingleOrDefault
               (x => x.Cliente.Numero_de_Cpf.Equals(c.Cliente.Numero_de_Cpf));
        }

        public List<Transacao> ListarTransacoes(Conta conta)
        {
            return _ctx.Transacoes.Where
                (x => x.NumeroConta.Equals(conta.NumeroConta)).ToList();
        }
    }
}
