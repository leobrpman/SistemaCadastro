using System.Text.RegularExpressions;
using Cadastro_PF.Interfaces;

namespace Cadastro_PF.Classes
{
    public class PessoaJuridica : Pessoa, IPessoaJuridica
    {

        public string ?razaoSocial { get; set; }
        
        public string ?cnpj { get; set; }

        public string caminho { get; private set;} = "DataBase/PessoaJuridica.csv";
        
        
        public override float PagarImposto(float rendimento)
        {
            if (rendimento <= 3000)
            {
                return rendimento * 0.03f;
            } else if (rendimento <= 6000)
            {
                return rendimento * 0.05f;
            } else if (rendimento <= 10000)
            {
                return rendimento * 0.07f;
            } else
            {
                return rendimento * 0.09f;
            }
        }

        public bool ValidarCnpj(string cnpj)
        {
            if (Regex.IsMatch(cnpj, @"(^(\d{2}.\d{3}.\d{3}/\d{4}-\d{2})|(\d{14})$)"))
            {
                if (cnpj.Length == 18)
                {
                    if (cnpj.Substring(11, 4) == "0001")
                    {    
                    return true;
                    }
                }
                else if (cnpj.Length == 14)
                {
                    if (cnpj.Substring(8, 4) == "0001")
                    {
                    return true;
                    }
                }
            }
            return false;

            // int[] multiplicador1 = new int[12] {5,4,3,2,9,8,7,6,5,4,3,2};
			// int[] multiplicador2 = new int[13] {6,5,4,3,2,9,8,7,6,5,4,3,2};
			// int soma;
			// int resto;
			// string digito;
			// string tempCnpj;
			// cnpj = cnpj.Trim();
			// cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
			// if (cnpj.Length != 14)
			//    return false;
			// tempCnpj = cnpj.Substring(0, 12);
			// soma = 0;
			// for(int i=0; i<12; i++)
			//    soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
			// resto = (soma % 11);
			// if ( resto < 2)
			//    resto = 0;
			// else
			//    resto = 11 - resto;
			// digito = resto.ToString();
			// tempCnpj = tempCnpj + digito;
			// soma = 0;
			// for (int i = 0; i < 13; i++)
			//    soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
			// resto = (soma % 11);
			// if (resto < 2)
			//     resto = 0;
			// else
			//    resto = 11 - resto;
			// digito = digito + resto.ToString();
			// return cnpj.EndsWith(digito);
        }


        public void Inserir(PessoaJuridica pj){

            VerificarPastaArquivo(caminho);
            
            string[] pjString = {$"{pj.nome},{pj.cnpj},{pj.razaoSocial}"};

            File.AppendAllLines(caminho, pjString);

        }


        public List<PessoaJuridica> Ler(){

            List<PessoaJuridica> listaPj = new List<PessoaJuridica>();

            string[] linhas = File.ReadAllLines(caminho);

            foreach (string cadaLinha in linhas)
            {
                string[] atributos = cadaLinha.Split(",");

                PessoaJuridica cadaPj = new PessoaJuridica();

                cadaPj.nome = atributos[0];
                cadaPj.cnpj = atributos[1];
                cadaPj.razaoSocial = atributos[2];

                listaPj.Add(cadaPj);
            }

            return listaPj;

        }

    }
}