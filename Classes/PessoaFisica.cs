using Cadastro_PF.Interfaces;

namespace Cadastro_PF.Classes
{
    public class PessoaFisica : Pessoa , IPessoaFisica
    {

        public string? cpf { get; set; }
        
        public string? dataNascimento { get; set; }

        public string caminho { get; private set;} = "DataBase/PessoaFisica.csv";
        
        
        public bool ValidarDataNascimento(string dataNasc)
        {
            DateTime dataConv;
            if (DateTime.TryParse(dataNasc, out dataConv) == true)
            {
                DateTime dataAtual = DateTime.Today;
                double idade = (dataAtual - dataConv).TotalDays / 365.25;
                // Console.WriteLine($"Data de Nascimento: {dataConv}");
                
                Console.WriteLine($"Idade: {idade} anos");
                if (idade >= 18 && idade < 120) 
                {
                    return true;
                }
                return false;
            }

            return false;


        }

        public override float PagarImposto(float rendimento) 
        {
            if (rendimento <= 1500)
            {
                return 0;
            } else if (rendimento <= 3500)
            {
                return rendimento * 0.02f;
            } else if (rendimento <= 6000)
            {
                return rendimento * 0.035f;
            } else
            {
                return rendimento * 0.05f;
            }
        }


        // public void Inserir(PessoaFisica pf){

        //     VerificarPastaArquivo(caminho);
            
        //     string[] pfString = {$"{pf.nome},{pf.cpf},{pf.rendimento}"};

        //     File.AppendAllLines(caminho, pfString);

        // }


        // public List<PessoaFisica> Ler(){

        //     List<PessoaFisica> listaPf = new List<PessoaFisica>();

        //     string[] linhas = File.ReadAllLines(caminho);

        //     foreach (string cadaLinha in linhas)
        //     {
        //         string[] atributos = cadaLinha.Split(",");

        //         PessoaFisica cadaPessoa = new PessoaFisica();

        //         cadaPessoa.nome = atributos[0];
        //         cadaPessoa.cpf = atributos[1];
        //         cadaPessoa.rendimento = atributos[2];

        //         listaPf.Add(cadaPessoa);
        //     }

        //     return listaPf;

        // }
    }
}


// Validar CPF
// using System;
// namespace Validacao
// {
// 	/// <summary>
// 	/// Realiza a validação do CPF
// 	/// </summary>
// 	public static class ValidaCPF
// 	{
// 	     public static bool IsCpf(string cpf)
// 	    {
// 		int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
// 		int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
// 		string tempCpf;
// 		string digito;
// 		int soma;
// 		int resto;
// 		cpf = cpf.Trim();
// 		cpf = cpf.Replace(".", "").Replace("-", "");
// 		if (cpf.Length != 11)
// 		   return false;
// 		tempCpf = cpf.Substring(0, 9);
// 		soma = 0;

// 		for(int i=0; i<9; i++)
// 		    soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
// 		resto = soma % 11;
// 		if ( resto < 2 )
// 		    resto = 0;
// 		else
// 		   resto = 11 - resto;
// 		digito = resto.ToString();
// 		tempCpf = tempCpf + digito;
// 		soma = 0;
// 		for(int i=0; i<10; i++)
// 		    soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
// 		resto = soma % 11;
// 		if (resto < 2)
// 		   resto = 0;
// 		else
// 		   resto = 11 - resto;
// 		digito = digito + resto.ToString();
// 		return cpf.EndsWith(digito);
// 	      }
// 	}
// }