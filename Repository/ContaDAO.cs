using Domain;
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
        public ContaDAO(Context _context, TransacaoDAO transacaoDAO)
        {
            _ctx = _context;
            _transacaoDAO = transacaoDAO;
        }
        public bool CriarConta(Conta c)
        {
            if (BuscarContaPorNumero(c) == null)
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


        public Conta BuscarContaPorNumero(Conta c)
        {
            return _ctx.Contas.SingleOrDefault
               (x => x.NumeroConta.Equals(c.NumeroConta));
        }

        //////public static bool Depositar(Conta conta, double valor, string descricao)
        //////{
        //////    if (conta == null)
        //////    {
        //////        if (valor > 0)
        //////        {
        //////            Conta c = new Conta();
        //////            c = Login.Conta;
        //////            Transacao t = new Transacao();
        //////            t.NumeroConta = c.NumeroConta;
        //////            t.Valor = valor;
        //////            t.Descricao = descricao;
        //////            TransacaoDAO.CadastrarTransacao(t);
        //////            c.Transacoes.Add(t);
        //////            c.Saldo += valor;
        //////            ctx.Entry(c).State = EntityState.Modified;
        //////            ctx.SaveChanges();

        //////            return true;
        //////        }
        //////        return false;
        //////    }
        //////    else
        //////    {
        //////        Transacao t = new Transacao();
        //////        t.NumeroConta = conta.NumeroConta;
        //////        t.Valor = valor;
        //////        t.Descricao = descricao;
        //////        TransacaoDAO.CadastrarTransacao(t);
        //////        conta.Transacoes.Add(t);
        //////        conta.Saldo += valor;
        //////        ctx.Entry(conta).State = EntityState.Modified;
        //////        ctx.SaveChanges();
        //////        return true;
        //////    }
        //////}

        //////public static bool Sacar(double valor, string descricao)
        //////{
        //////    if (Login.Conta.Saldo - valor >= 0 && valor > 0)
        //////    {
        //////        Transacao t = new Transacao();
        //////        t.NumeroConta = Login.Conta.NumeroConta;
        //////        t.Valor = valor*-1.0;
        //////        t.Descricao = descricao;
        //////        TransacaoDAO.CadastrarTransacao(t);
        //////        Login.Conta.Transacoes.Add(t);
        //////        Login.Conta.Saldo -= valor;
        //////        ctx.Entry(Login.Conta).State = EntityState.Modified;
        //////        ctx.SaveChanges();
        //////        return true;
        //////    }
        //////    return false;
        //////}

        //////public static double VerSaldo()
        //////{
        //////    return Login.Conta.Saldo;
        //////}

        //public static bool Tranferencia(Conta conta, double valor)
        //{
        //    if (conta != null)
        //    {
        //        if (Sacar(valor, "Tranferência") == true)
        //        {
        //            return Depositar(conta, valor, "Tranferência");
        //        }
        //        return false;
        //    }
        //    return false;
        //}

        public Conta BuscarContaPorCpfCliente(Conta c)
        {
            return _ctx.Contas.SingleOrDefault
               (x => x.Cliente.Cpf.Equals(c.Cliente.Cpf));
        }

        public List<Transacao> ListarTransacoes(Conta conta)
        {
            return _ctx.Transacoes.Where
                (x => x.NumeroConta.Equals(conta.NumeroConta)).ToList();
        }
    }
}
