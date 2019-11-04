using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    [Table("Transacoes")]
    public class Transacao
    {
        public Transacao()
        {
            Data = DateTime.Now;
        }

        [Key]
        public int TransacaoId { get; set; }
        public int NumeroConta { get; set; }
        public double Valor { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }

    }
}
