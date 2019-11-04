using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    [Table("Clientes")]
    public class Cliente
    {
        public Cliente()
        {
            CriadoEm = DateTime.Now;
        }
        [Key]
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime? DataNasc { get; set; }
        public string Contato { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}
