using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Boleto
    {
        public Boleto() { }
        public string Codigo { get; set; }
        public string NomeBanco { get; set; }
        public string Moeda { get; set; }
        public double Valor { get; set; }
        public DateTime? DataVencimento { get; set; }
    }
}
