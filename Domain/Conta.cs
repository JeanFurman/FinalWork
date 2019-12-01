using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    [Table("Contas")]
    public class Conta
    {
        public Conta()
        {
            Random ran = new Random();
            CriadoEm = DateTime.Now;
            NumeroConta = ran.Next(100000, 999999);
            Transacoes = new List<Transacao>();
            Divida = 0;
        }
        [Key]
        public int ContaId { get; set; }
        public int NumeroConta { get; set; }
        public Cliente Cliente { get; set; }
        public string Senha { get; set; }
        public List<Transacao> Transacoes { get; set; }
        public double Saldo { get; set; }
        public double Divida { get; set; }
        public DateTime? DataDivida { get; set; }

        public DateTime CriadoEm { get; set; }
    }
}
