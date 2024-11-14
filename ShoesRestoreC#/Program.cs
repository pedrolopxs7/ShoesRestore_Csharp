using System;
using System.Collections.Generic;

namespace ShoesRestoreC_
{
    class Program
    {
        // Listas para armazenar os objetos
        static List<Cliente> clientes = new List<Cliente>();
        static List<Sapato> sapatos = new List<Sapato>();
        static Sapateiro sapateiro = new Sapateiro("Pedro", "Especialista em Higienização e Reparo");

        static void Main(string[] args)
        {
            int opcao;
            do
            {
                Console.Clear();
                Console.WriteLine("== ShoesRestore ==\n");
                Console.WriteLine("1 - Cadastrar Cliente");
                Console.WriteLine("2 - Registrar Sapato com Defeito");
                Console.WriteLine("3 - Exibir Relatório de Clientes");
                Console.WriteLine("4 - Exibir Relatório de Sapatos e Defeitos");
                Console.WriteLine("5 - Resolver Sapato com Defeito");
                Console.WriteLine("0 - Sair");
                Console.Write("\nEscolha uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        CadastrarCliente();
                        break;
                    case 2:
                        RegistrarDefeitoSapato();
                        break;
                    case 3:
                        ExibirRelatorioClientes();
                        break;
                    case 4:
                        ExibirRelatorioSapatos();
                        break;
                    case 5:
                        ResolverSapatoComDefeito();
                        break;
                    case 0:
                        Console.WriteLine("Saindo do sistema...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }

                if (opcao != 0)
                {
                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcao != 0);
        }

        static void CadastrarCliente()
        {
            Console.WriteLine("\n== Cadastro de Cliente ==");
            Console.Write("Nome do Cliente: ");
            string nome = Console.ReadLine();
            Console.Write("Endereço do Cliente: ");
            string endereco = Console.ReadLine();
            Console.Write("CPF do Cliente: ");
            string cpf = Console.ReadLine();
            Console.Write("Email do Cliente: ");
            string email = Console.ReadLine();
            Console.Write("Contato do Cliente: ");
            string contato = Console.ReadLine();

            Cliente cliente = new Cliente(nome, endereco, cpf, email, contato);
            clientes.Add(cliente);

            Console.WriteLine("Cliente cadastrado com sucesso!");
        }

        // método para selecionar o cliente
        static Cliente EscolherCliente()
        {
            Console.WriteLine("Escolha um cliente para associar ao sapato:");

            // verificando se há clientes cadastrados
            if (clientes.Count == 0)
            {
                Console.WriteLine("Nenhum cliente cadastrado. Por favor, cadastre um cliente primeiro.");
                return null;  // retorna null caso não haja clientes cadastrados
            }

            // exibindo os clientes cadastrados
            for (int i = 0; i < clientes.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {clientes[i].Nome}");
            }

            // solicitar que o usuário escolha um cliente ao cadastrar um modelo de sapato
            Console.Write("Digite o número do cliente: ");
            int clienteEscolhido = int.Parse(Console.ReadLine()) - 1;

            // Validando a escolha do cliente
            if (clienteEscolhido < 0 || clienteEscolhido >= clientes.Count)
            {
                Console.WriteLine("Opção inválida. Cliente não encontrado.");
                return null;  // retorna null caso o cliente não seja encontrado
            }

            // retorna o cliente selecionado
            return clientes[clienteEscolhido];
        }

        static void RegistrarDefeitoSapato()
        {
            Console.WriteLine("\n== Registro de Sapato com Defeito ==");

            // Escolher um cliente
            Cliente clienteSelecionado = EscolherCliente();

            // Verificando se o cliente foi selecionado corretamente
            if (clienteSelecionado == null)
            {
                Console.WriteLine("Cadastro de sapato não realizado. Nenhum cliente selecionado.");
                return;
            }

            // Informações do sapato
            Console.Write("Modelo do Sapato: ");
            string modelo = Console.ReadLine();
            Console.Write("Preço do Sapato: ");
            decimal preco = decimal.Parse(Console.ReadLine());

            // Criando o objeto Sapato
            Sapato sapato = new Sapato(modelo, preco);

            // Associando o cliente ao sapato
            sapato.Cliente = clienteSelecionado;

            // Informações sobre o defeito
            Console.Write("Descrição do Defeito: ");
            string descricaoDefeito = Console.ReadLine();
            Defeito defeito = new Defeito(descricaoDefeito);

            // Registrando o defeito no sapato
            sapateiro.RegistrarDefeito(sapato, defeito);
            sapatos.Add(sapato);

            Console.WriteLine("Defeito registrado no sapato com sucesso!");
        }


        static void ExibirRelatorioClientes()
        {
            Console.WriteLine("\n== Relatório de Clientes ==");
            if (clientes.Count == 0)
            {
                Console.WriteLine("Nenhum cliente cadastrado.");
            }
            else
            {
                foreach (var cliente in clientes)
                {
                    cliente.ExibirInformacoes();
                }
            }
        }

        static void ResolverSapatoComDefeito()
        {
            Console.WriteLine("\n== Resolver Sapato com Defeito ==");

            // exibe a lista de sapatos com defeito
            List<Sapato> sapatosComDefeito = sapatos.FindAll(s => s.Defeitos.Count > 0);

            if (sapatosComDefeito.Count == 0)
            {
                Console.WriteLine("Não há sapatos com defeito registrados.");
                return;
            }

            // exibe os sapatos com defeito para o usuário escolher
            Console.WriteLine("Escolha um sapato para resolver:");
            for (int i = 0; i < sapatosComDefeito.Count; i++)
            {
                Console.WriteLine($"{i + 1} - Modelo: {sapatosComDefeito[i].Modelo}, Preço: R${sapatosComDefeito[i].Preco:F2}");
            }

            Console.Write("Digite o número do sapato que foi resolvido: ");
            int escolha = int.Parse(Console.ReadLine()) - 1;

            if (escolha < 0 || escolha >= sapatosComDefeito.Count)
            {
                Console.WriteLine("Opção inválida.");
                return;
            }

            // M
            Sapato sapatoResolvido = sapatosComDefeito[escolha];
            Console.WriteLine($"O sapato '{sapatoResolvido.Modelo}' foi resolvido!");

            // Remover o sapato resolvido da lista
            sapatos.Remove(sapatoResolvido);

            Console.WriteLine($"O sapato '{sapatoResolvido.Modelo}' foi removido da lista de sapatos com defeito.");
        }

        static void ExibirRelatorioSapatos()
{
    Console.WriteLine("\n== Relatório de Sapatos e Defeitos ==");
    if (sapatos.Count == 0)
    {
        Console.WriteLine("Nenhum sapato registrado.");
    }
    else
    {
        foreach (var sapato in sapatos)
        {
            // Exibindo as informações do sapato
            Console.WriteLine($"Modelo: {sapato.Modelo}");
            Console.WriteLine($"Preço: R${sapato.Preco:F2}");

            // Verificando se o sapato tem um cliente associado
            if (sapato.Cliente != null)
            {
                Console.WriteLine($"Cliente: {sapato.Cliente.Nome}");  // Exibindo o nome do cliente
            }
            else
            {
                Console.WriteLine("Cliente não associado.");
            }

            // Exibindo os defeitos do sapato
            if (sapato.Defeitos.Count > 0)
            {
                Console.WriteLine("Defeitos:");
                foreach (var defeito in sapato.Defeitos)
                {
                    Console.WriteLine($"- {defeito.Descricao}");
                }
            }
            else
            {
                Console.WriteLine("Nenhum defeito registrado.");
            }

            Console.WriteLine();  // Linha em branco para separar cada sapato
        }
    }
}

    }
}
