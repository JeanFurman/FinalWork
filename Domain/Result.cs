using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Result
    {
        public Result()
        {
        }
        public string Nome_da_Pf { get; set; }
        public string Numero_de_Cpf { get; set; }
        public string Data_Nascimento { get; set; }
        public string Situacao_Cadastral { get; set; }
        public string Data_Inscricao { get; set; }
        public string Digito_Verificador { get; set; }
        public string Comprovante_Emitido { get; set; }
        public string Comprovante_Emitido_Data { get; set; }
    }
}
