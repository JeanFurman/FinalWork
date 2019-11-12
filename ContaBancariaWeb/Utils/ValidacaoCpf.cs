using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContaBancariaWeb.Utils
{
    public class ValidacaoCpf
    {
        private ValidacaoCpf()
        {

        }
        public static bool ValidarCpf(string cpf)
        {
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
            {
                return false;
            }

            switch (cpf)
            {
                case "11111111111":
                    return false;
                case "22222222222":
                    return false;
                case "33333333333":
                    return false;
                case "44444444444":
                    return false;
                case "55555555555":
                    return false;
                case "66666666666":
                    return false;
                case "77777777777":
                    return false;
                case "88888888888":
                    return false;
                case "99999999999":
                    return false;
                case "00000000000":
                    return false;
            }
            int peso = 10;
            int soma = 0;
            int aux1;
            int aux2;
            for (int i = 0; i < 9; i++)
            {
                soma = soma + (Convert.ToInt32(cpf[i].ToString()) * peso);
                peso--;
            }
            int resto = soma % 11;
            if (resto < 2)
            {
                aux1 = 0;
            }
            else
            {
                aux1 = 11 - resto;
            }
            peso = 11;
            soma = 0;
            for (int i = 0; i < 10; i++)
            {
                soma = soma + (Convert.ToInt32(cpf[i].ToString()) * peso);
                peso--;
            }
            resto = soma % 11;
            if (resto < 2)
            {
                aux2 = 0;
            }
            else
            {
                aux2 = 11 - resto;
            }
            if (aux1 == Convert.ToUInt32(cpf[9].ToString()) && aux2 == Convert.ToUInt32(cpf[10].ToString()))
            {
                return true;
            }
            return false;
        }
    }
}
