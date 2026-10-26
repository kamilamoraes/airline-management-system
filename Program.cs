string? opcao = "";
List<string> passageiros = new List<string>();
string? opcaoPassageiros = "";

while (opcao != "0")
{
    Console.WriteLine("===========================");
    Console.WriteLine(" AIRLINE MANAGEMENT SYSTEM ");
    Console.WriteLine("===========================");

    Console.WriteLine("1 - Passageiros ");
    Console.WriteLine("2 - Voos ");
    Console.WriteLine("3 - Aeronaves ");
    Console.WriteLine("4 - Reservas ");
    Console.WriteLine("0 - Sair ");

    Console.WriteLine("Escolha uma opção: ");

    opcao = Console.ReadLine(); 

    Console.WriteLine($"Você escolheu: {opcao}");

    if (opcao == "")
    {
       Console.WriteLine("Você não digitou nenhuma opção. Tente novamente.");
    }

    else if (opcao == "1")
    {

        opcaoPassageiros = "";

        while (opcaoPassageiros != "0")
        {

        Console.WriteLine("=============================");
        Console.WriteLine("         PASSAGEIROS         ");
        Console.WriteLine("=============================");
        Console.WriteLine("1 - Cadastrar passageiro");
        Console.WriteLine("2 - Listar passageiros");
        Console.WriteLine("3 - Remover passageiro");
        Console.WriteLine("0 - Voltar ao menu principal");
        Console.WriteLine("Escolha uma opção:");

        opcaoPassageiros = Console.ReadLine();

        Console. Clear();

        if (opcaoPassageiros == "0")
        {
            Console.WriteLine("Voltando ao menu principal...");
            Console.WriteLine("Menu principal carregado.");
        }
        else if (opcaoPassageiros == "1")
        {
           Console.WriteLine("Você selecionou Cadastrar passageiro.");
           Console.WriteLine("Digite o nome do passageiro:.");
           string? nome = Console.ReadLine();

        if (string. IsNullOrWhiteSpace(nome))
        {
            Console.WriteLine("O nome não pode ficar vazio.");
        }
        else
        {
            Console.WriteLine("Digite o sobrenome do passageiro:.");

            string? sobrenome = Console.ReadLine();

            if (String.IsNullOrWhiteSpace(sobrenome))
            {
                Console.WriteLine("O sobrenome não pode ficar vazio.");      
            }
            else
            {
                string nomeCompleto = $"{nome} {sobrenome}";

                passageiros.Add(nomeCompleto);

                Console.WriteLine($"Passageiro cadastrado: {nomeCompleto}");
            }
        }

    }
        else if (opcaoPassageiros == "2")
        {
            if (passageiros.Count == 0)
            {
                Console.WriteLine("Nenhum passageiro cadastrado.");      
            }
            else
            {
                Console.WriteLine("Passageiros cadastrados:");

                for (int i = 0; i < passageiros.Count; i++)
                {
                    Console.WriteLine($"{i + 1} - {passageiros[i]}");
                }     
            }
        }
        }
    }
    else if (opcao == "2")
    {
        Console.WriteLine("Você selecionou Voos.");
    }
    else if (opcao == "3")
    {
        Console.WriteLine("Você selecionou Aeronaves.");
    }
    else if (opcao == "4")
    {
        Console.WriteLine("Você selecionou Reservas.");
    }
    else if (opcao == "0")
    {
        Console.WriteLine("Você escolheu sair do sistema.");
        Console.WriteLine("Encerrando o Airline Management System. Até mais!");
    }
    else if (opcao != "")
    {
        Console.WriteLine("Opção inválida.");
    }
}

