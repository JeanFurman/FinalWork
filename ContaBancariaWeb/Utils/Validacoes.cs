using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContaBancariaWeb.Utils
{
    public class Validacoes
    {
        private Validacoes()
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
        public static Boleto ValidarBoleto(string cod)
        {
            if (cod == null)
            {
                return null;
            }
            cod = cod.Replace(".", "").Replace(" ", "");
            if (cod.Length != 47 && cod.Length != 48)
            {
                return null;
            }

            switch (cod)
            {
                case "11111111111111111111111111111111111111111111111":
                    return null;
                case "22222222222222222222222222222222222222222222222":
                    return null;
                case "33333333333333333333333333333333333333333333333":
                    return null;
                case "44444444444444444444444444444444444444444444444":
                    return null;
                case "55555555555555555555555555555555555555555555555":
                    return null;
                case "66666666666666666666666666666666666666666666666":
                    return null;
                case "77777777777777777777777777777777777777777777777":
                    return null;
                case "88888888888888888888888888888888888888888888888":
                    return null;
                case "99999999999999999999999999999999999999999999999":
                    return null;
                case "00000000000000000000000000000000000000000000000":
                    return null;
            }
            int soma = 0;
            int peso = 2;
            string codAux = cod.Substring(0, 9);
            int resultado;
            resultado = calculoCod(codAux);
            if (Convert.ToInt32(cod[9].ToString()) == resultado)
            {
                codAux = cod.Substring(10, 10);
                resultado = calculoCod(codAux);
                if (Convert.ToInt32(cod[20].ToString()) == resultado)
                {

                    codAux = cod.Substring(21, 10);
                    resultado = calculoCod(codAux);
                    if (Convert.ToInt32(cod[31].ToString()) == resultado)
                    {

                        Boleto b = new Boleto();
                        b.Codigo = cod;
                        string codBank = cod[0].ToString();
                        codBank += cod[1].ToString();
                        codBank += cod[2].ToString();
                        switch (codBank)
                        {
                            case "001":
                                b.NomeBanco = "BANCO DO BRASIL";
                                break;
                            case "104":
                                b.NomeBanco = "CAIXA ECONÔMICA FEDERAL";
                                break;
                            case "033":
                                b.NomeBanco = "BCO SANTANDER (BRASIL) S.A.";
                                break;
                            case "389":
                                b.NomeBanco = "BCO MERCANTIL DO BRASIL S.A.";
                                break;
                            case "745":
                                b.NomeBanco = "CITIBANK S.A.";
                                break;
                            case "477":
                                b.NomeBanco = "CITIBANK N.A.";
                                break;
                            case "069":
                                b.NomeBanco = "BCO CREFISA S.A.";
                                break;
                            case "318":
                                b.NomeBanco = "BCO BMG S.A ";
                                break;
                            case "184":
                                b.NomeBanco = "BANCO ITAÚ BBA S.A.";
                                break;
                            case "479":
                                b.NomeBanco = "BANCO ITAÚ BANK S.A";
                                break;
                            case "652":
                                b.NomeBanco = "ITAÚ UNIBANCO HOLDING S.A.";
                                break;
                            case "341":
                                b.NomeBanco = "ITAÚ UNIBANCO BM S.A.";
                                break;
                            case "237":
                                b.NomeBanco = "BCO BRADESCO S.A.";
                                break;
                            case "036":
                                b.NomeBanco = "BANCO BRADESCO BBI S.A.";
                                break;
                            case "204":
                                b.NomeBanco = "BANCO BRADESCO CARTÕES S.A.";
                                break;
                            case "394":
                                b.NomeBanco = "BANCO BRADESCO FINANCIAMENTOS S.A";
                                break;
                            case "122":
                                b.NomeBanco = "BANCO BRADESCO BERJ S.A.";
                                break;
                            default:
                                b.NomeBanco = "BANCO DA UP";
                                break;
                        }
                        b.Moeda = "Reais";
                        string valor = "";
                        for (int i = 37; i < cod.Length; i++)
                        {
                            valor += cod[i];
                        }
                        double preco = Convert.ToDouble(valor) / 100;
                        b.Valor = preco;
                        string dataCod = "";
                        for (int i = 33; i < 37; i++)
                        {
                            dataCod += cod[i];
                        }
                        string dataBase = "07/10/1997";
                        b.DataVencimento = DateTime.Parse(dataBase).AddDays(Convert.ToInt32(dataCod));
                        return b;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        private static int calculoCod(string codAux)
        {
            int soma = 0;
            int control = 2;
            int j = codAux.Length -1;
            string aux;
            for (int i = 0; i < codAux.Length; i++)
            {
                aux = (Convert.ToInt32(codAux[j].ToString()) * control).ToString();
                if (aux.Length == 2)
                {
                    soma += Convert.ToInt32(aux.Substring(0, 1));
                    soma += Convert.ToInt32(aux.Substring(1, 1));
                }
                else
                {
                    soma += Convert.ToInt32(aux);
                }
                
                j--;
                if (control == 2)
                {
                    control = 1;
                }
                else
                {
                    control = 2;
                }
            }
            soma = soma % 10;
            int result = 10 - soma;
            return result;
        }
    }
}

