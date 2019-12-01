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
        public string Nome_da_Pf { get; set; }
        public string Numero_de_Cpf { get; set; }
        public DateTime? Data_Nascimento { get; set; }
        public string Contato { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}
