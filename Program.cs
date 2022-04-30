// // See https://aka.ms/new-console-template for more information
// Console.WriteLine("Vai, Corinthians!");

using System.Globalization;
using Cadastro_PF.Classes;

Console.WriteLine(@$"
=====================================================
|       Bem-vindo ao sistema de cadastros de        |
|           Pessoas Físicas e Jurídicas             |
=====================================================
");

barraCarregamento("Carregando", 200);

string? opcao;

List<PessoaFisica> listaPf = new List<PessoaFisica>();
List<PessoaJuridica> listaPj = new List<PessoaJuridica>();

do
{
    Console.Clear();
    Console.WriteLine(@$"
=====================================================
|           Escolha uma das opções abaixo:          |
|---------------------------------------------------|
|                 1 - Pessoa Física                 |
|                 2 - Pessoa Jurídica               |
|                                                   |
|                 0 - Sair                          |
=====================================================
    ");

    opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            Console.Clear();
            PessoaFisica metodoPf = new PessoaFisica();

            string? opcaoPf;
            do
            {
                Console.Clear();
                Console.WriteLine(@$"
=====================================================
|           Escolha uma das opções abaixo:          |
|---------------------------------------------------|
|             1 - Cadastrar                         |
|             2 - Mostrar Pessoas Físicas           |
|                                                   |
|             0 - Voltar                            |
=====================================================
    ");
                opcaoPf = Console.ReadLine();

                switch (opcaoPf)
                {
                    case "1":
                        PessoaFisica novaPf = new PessoaFisica();
                        Endereco novoEnd = new Endereco();

                        Console.WriteLine($"Digite o nome da pessoa física que deseja cadastrar");
                        novaPf.nome = Console.ReadLine();

                        bool dataValida;
                        do
                        {
                            Console.WriteLine($"Digite a data de nascimento. Ex: DD/MM/AAAA");
                            string dataNasc = Console.ReadLine();

                            dataValida = metodoPf.ValidarDataNascimento(dataNasc);
                            if (metodoPf.ValidarDataNascimento(dataNasc))
                            {
                                novaPf.dataNascimento = dataNasc;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine($"Data inválida. Por favor, digite uma data válida!");
                                Console.ResetColor();
                            }

                        } while (dataValida != true);

                        Console.WriteLine($"Digite o número do CPF. Ex: XXX.XXX.XXX-XX");
                        novaPf.cpf = Console.ReadLine();

                        Console.WriteLine($"Digite o rendimento mensal (digite somente números)");
                        novaPf.rendimento = float.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite o nome da rua do endereço (logradouro)");
                        novoEnd.logradouro = Console.ReadLine();

                        Console.WriteLine($"Digite o número");
                        novoEnd.numero = int.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite o complemento (Aperte ENTER para vazio)");
                        novoEnd.complemento = Console.ReadLine();

                        Console.WriteLine($"Este endereço é comercial? S/N");
                        string endCom = Console.ReadLine().ToUpper();
                        if (endCom == "S")
                        {
                            novoEnd.endComerical = true;
                        }
                        else
                        {
                            novoEnd.endComerical = false;
                        }
                        // FAZER COM SWITCH

                        novaPf.endereco = novoEnd;

                        listaPf.Add(novaPf);


                        // StreamWriter sw = new StreamWriter($"{novaPf.nome}.txt");
                        // sw.Write($"{novaPf.nome}");
                        // sw.Close();

                        using (StreamWriter sw = new StreamWriter($"{novaPf.nome}.txt"))
                        {
                            sw.WriteLine($"{novaPf.nome}");
                        }

//                         metodoPj.Inserir(novaPj);

//                         metodoPj.Ler();

//                         foreach (PessoaJuridica cadaItem in listaPj)
//                         {
//                             Console.Clear();
//                             Console.WriteLine(@$"
// Empresa: {novaPj.nome}
// Endereço: {novaPj.endereco.logradouro}, {novaPj.endereco.numero} - {novaPj.endereco.complemento}
// Razão Social: {novaPj.razaoSocial}
// CNPJ: {novaPj.cnpj}
// Receita mensal: R$ {novaPj.rendimento.ToString("n2")}
// Imposto a ser pago: {metodoPj.PagarImposto(novaPj.rendimento).ToString("C", CultureInfo.CreateSpecificCulture("en-US"))}
// CNPJ válido? {(metodoPj.ValidarCnpj(novaPj.cnpj) ? "Sim" : "Não")}");
//                             Console.WriteLine(@$"Aperte qualquer tecla para continuar!");
//                             Console.ReadKey();
        
//                         }

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Cadastro realizado com sucesso!");
                        Console.ResetColor();
                        Thread.Sleep(3000);

                        break;


                    case "2":
                        Console.Clear();

                        if (listaPf.Count > 0)
                        {

                            foreach (PessoaFisica cadaPessoa in listaPf)
                            {
                                Console.WriteLine(@$"
Nome: {cadaPessoa.nome}
Endereço: {cadaPessoa.endereco.logradouro}, {cadaPessoa.endereco.numero} - {cadaPessoa.endereco.complemento}
Data de Nascimento: {cadaPessoa.dataNascimento}
CPF: {cadaPessoa.cpf}
Renda mensal: R$ {cadaPessoa.rendimento.ToString("n2")}
Imposto a ser pago: {metodoPf.PagarImposto(cadaPessoa.rendimento).ToString("C")}
Maior de idade? {(metodoPf.ValidarDataNascimento(cadaPessoa.dataNascimento) ? "Sim" : "Não")}
");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Não há Pessoas Físicas cadastradas na lista!");
                            Thread.Sleep(3000);
                        }

                        Console.WriteLine(@$"
            Tecle 'Enter' para continuar!");
                        Console.ReadLine();


                        using (StreamReader sr = new StreamReader("Leonardo Briza.txt"))
                        {
                            string linha;
                            while ((linha = sr.ReadLine()) != null)
                            {
                                Console.WriteLine($"Arquivos .txt relacionados para leitura:");
                                Console.WriteLine($"{linha}");
                            }
                            Thread.Sleep(3000);
                        }

                        Console.WriteLine($"Aperte 'Enter' para continuar");
                        Console.ReadLine();


                        break;
                    case "0":
                        Console.Clear();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine($"Opção inválida! Por favor, digite outra opção!");
                        Thread.Sleep(2000);
                        break;
                }

            } while (opcaoPf != "0");





            // PessoaFisica novaPf = new PessoaFisica();
            // Endereco novoEnd = new Endereco();

            // novaPf.nome = "Leonardo";
            // novaPf.dataNascimento = "23/09/1989";
            // novaPf.cpf = "333.444.555-66";
            // novaPf.rendimento = 50000.0f;

            // novoEnd.logradouro = "Av. Paulista";
            // novoEnd.numero = 2000;
            // novoEnd.complemento = "ap. 32";
            // novoEnd.endComerical = true;

            // novaPf.endereco = novoEnd;

            // bool dataValida = metodoPf.ValidarDataNascimento(novaPf.dataNascimento);

            //Console.WriteLine("Nome: " + novaPf.nome); //concatenação
            //Console.WriteLine($"Nome: {novaPf.nome}"); //interpolação
            // Console.WriteLine($"Endereço: {novaPf.endereco.logradouro}, {novaPf.endereco.numero} - {novaPf.endereco.complemento}");
            // Console.WriteLine($"Data de Nascimento: {novaPf.dataNascimento}");
            // Console.WriteLine($"CPF: {novaPf.cpf}");
            // Console.WriteLine($"Renda mensal: R$ {novaPf.rendimento}");

//             Console.WriteLine(@$"
// Nome: {novaPf.nome}
// Endereço: {novaPf.endereco.logradouro}, {novaPf.endereco.numero} - {novaPf.endereco.complemento}
// Data de Nascimento: {novaPf.dataNascimento}
// CPF: {novaPf.cpf}
// Renda mensal: R$ {novaPf.rendimento.ToString("n2")}
// Imposto a ser pago: {metodoPf.PagarImposto(novaPf.rendimento).ToString("C")}
// Maior de idade? {(metodoPf.ValidarDataNascimento(novaPf.dataNascimento) ? "Sim" : "Não")}
// ");
            // Maior de idade? {dataValida}"


            // novaPf.ValidarDataNascimento(novaPf.dataNascimento);
            Console.WriteLine(@$"
            Tecle 'Enter' para continuar!");
            Console.ReadLine();
            break;



        case "2":
            Console.Clear();
            PessoaJuridica metodoPj = new PessoaJuridica();

            string? opcaoPj;
            do
            {
                Console.Clear();
                Console.WriteLine(@$"
=====================================================
|           Escolha uma das opções abaixo:          |
|---------------------------------------------------|
|             1 - Cadastrar                         |
|             2 - Mostrar Pessoas Jurídicas         |
|                                                   |
|             0 - Voltar                            |
=====================================================
    ");
                opcaoPj = Console.ReadLine();

                switch (opcaoPj)
                {
                    case "1":
                        PessoaJuridica novaPj = new PessoaJuridica();
                        Endereco novoEndPj = new Endereco();

                        Console.WriteLine($"Digite o nome da pessoa jurídica que deseja cadastrar");
                        novaPj.nome = Console.ReadLine();

                        bool cnpjValido;
                        do
                        {
                            Console.WriteLine($"Digite o CNPJ. Ex: XX.XXX.XXX/XXXX-XX");
                            string cnpj = Console.ReadLine();

                            cnpjValido = metodoPj.ValidarCnpj(cnpj);
                            if (metodoPj.ValidarCnpj(cnpj))
                            {
                                novaPj.cnpj = cnpj;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine($"CNPJ inválido. Por favor, digite um CNPJ válido!");
                                Console.ResetColor();
                            }

                        } while (cnpjValido != true);

                        Console.WriteLine($"Digite a razão social:");
                        novaPj.razaoSocial = Console.ReadLine();

                        Console.WriteLine($"Digite o rendimento mensal (digite somente números)");
                        novaPj.rendimento = float.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite o nome da rua do endereço (logradouro)");
                        novoEndPj.logradouro = Console.ReadLine();

                        Console.WriteLine($"Digite o número");
                        novoEndPj.numero = int.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite o complemento (Aperte ENTER para vazio)");
                        novoEndPj.complemento = Console.ReadLine();

                        Console.WriteLine($"Este endereço é comercial? S/N");
                        string endCom = Console.ReadLine().ToUpper();
                        if (endCom == "S")
                        {
                            novoEndPj.endComerical = true;
                        }
                        else
                        {
                            novoEndPj.endComerical = false;
                        }
                        // FAZER COM SWITCH?

                        novaPj.endereco = novoEndPj;

                        listaPj.Add(novaPj);


                        // StreamWriter sw = new StreamWriter($"{novaPf.nome}.txt");
                        // sw.Write($"{novaPf.nome}");
                        // sw.Close();

                        using (StreamWriter sw = new StreamWriter($"{novaPj.nome}.txt"))
                        {
                            sw.WriteLine($"{novaPj.nome}");
                        }
                        
                        metodoPj.Inserir(novaPj);

                        metodoPj.Ler();

                        foreach (PessoaJuridica cadaItem in listaPj)
                        {
                            Console.Clear();
                            Console.WriteLine(@$"
Empresa: {novaPj.nome}
Endereço: {novaPj.endereco.logradouro}, {novaPj.endereco.numero} - {novaPj.endereco.complemento}
Razão Social: {novaPj.razaoSocial}
CNPJ: {novaPj.cnpj}
Receita mensal: R$ {novaPj.rendimento.ToString("n2")}
Imposto a ser pago: {metodoPj.PagarImposto(novaPj.rendimento).ToString("C", CultureInfo.CreateSpecificCulture("en-US"))}
CNPJ válido? {(metodoPj.ValidarCnpj(novaPj.cnpj) ? "Sim" : "Não")}");
                            Console.WriteLine(@$"Aperte qualquer tecla para continuar!");
                            Console.ReadKey();
        
                        }

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Cadastro realizado com sucesso!");
                        Console.ResetColor();
                        Thread.Sleep(3000);

                        break;


                    case "2":
                        Console.Clear();

                        if (listaPj.Count > 0)
                        {

                            foreach (PessoaJuridica cadaPj in listaPj)
                            {
                                Console.WriteLine(@$"
Nome: {cadaPj.nome}
Endereço: {cadaPj.endereco.logradouro}, {cadaPj.endereco.numero} - {cadaPj.endereco.complemento}
Razão Social: {cadaPj.razaoSocial}
CNPJ: {cadaPj.cnpj}
Renda mensal: R$ {cadaPj.rendimento.ToString("n2")}
Imposto a ser pago: {metodoPj.PagarImposto(cadaPj.rendimento).ToString("C")}
CNPJ válido? {(metodoPj.ValidarCnpj(cadaPj.cnpj) ? "Sim" : "Não")}
");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Não há Pessoas Jurídicas cadastradas na lista!");
                            Thread.Sleep(3000);
                        }

                        Console.WriteLine(@$"
            Tecle 'Enter' para continuar!");
                        Console.ReadLine();
                        break;

                        // using (StreamReader sr = new StreamReader("Nome Fantasia.txt"))
                        // {
                        //     string linha;
                        //     while ((linha = sr.ReadLine()) != null)
                        //     {
                        //         // Console.WriteLine($"{linha}");
                        //     }
                        //     Thread.Sleep(3000);
                        // }


                        
                    case "0":
                        Console.Clear();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine($"Opção inválida! Por favor, digite outra opção!");
                        Thread.Sleep(2000);
                        break;
                }

            } while (opcaoPj != "0");


            Console.WriteLine(@$"
            Tecle 'Enter' para continuar!");
            Console.ReadLine();
            break;

        case "0":
            Console.Clear();
            barraCarregamento(@"Obrigado por utilizar o sistema!
Finalizando", 300);
            Console.Clear();

            break;

        default:
            Console.Clear();
            Console.WriteLine($"Opção inválida! Por favor, digite outra opção!");
            Thread.Sleep(2000);
            break;
    }
} while (opcao != "0");

static void barraCarregamento(string texto, int tempo)
{
    Console.BackgroundColor = ConsoleColor.DarkYellow;
    Console.ForegroundColor = ConsoleColor.Black;
    Console.Write($"{texto} ");

    for (var contador = 0; contador < 10; contador++)
    {
        Console.Write(". ");
        Thread.Sleep(tempo);
    }

    Console.ResetColor();
}