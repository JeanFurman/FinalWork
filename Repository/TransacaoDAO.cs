using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class TransacaoDAO
    {
        private readonly Context _ctx;
        public TransacaoDAO(Context _context)
        {
            _ctx = _context;
        }
        public void CadastrarTransacao(Transacao t)
        {
            _ctx.Transacoes.Add(t);
            _ctx.SaveChanges();
        }

        public void RemoverTransacao(Conta c)
        {
            foreach (Transacao t in c.Transacoes)
            {
                _ctx.Transacoes.Remove(t);
                _ctx.SaveChanges();
            }
            
        }

        

    }
}
