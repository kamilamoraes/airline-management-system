using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using AirlineManagementSystem.Data;

var configuration = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

string connectionString = configuration.GetConnectionString("DefaultConnection")!;

var optionsBuilder = new DbContextOptionsBuilder<AirlineDbContext>();

optionsBuilder.UseSqlServer(connectionString);

using var dbContext = new AirlineDbContext(optionsBuilder.Options);

string? opcao = "";
List<string> passageiros = new List<string>();
string? opcaoPassageiros = "";
List<string> voos = new List<string>();
string? opcaoVoos = "";
List<string> aeronaves = new List<string>();
string? opcaoAeronaves = "";
List<string> reservas = new List<string>();
string? opcaoReservas = "";

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
        Console.WriteLine("4 - Editar passageiro");
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

         else if (opcaoPassageiros == "3")
        {
            if (passageiros.Count == 0)
            {
                Console.WriteLine("Nenhum passageiro cadastrado para remover.");
            }
            else
            {
                Console.WriteLine("Passageiros cadastrados:");

            for (int i = 0; i < passageiros.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {passageiros[i]}");
            }

                Console.WriteLine("Digite o número do passageiro que deseja remover:");

                string? entrada = Console.ReadLine();

            if (int.TryParse(entrada, out int numero))
            {
            if (numero >= 1 && numero <= passageiros.Count)
            {
                string passageiroRemovido = passageiros[numero - 1];

                passageiros.RemoveAt(numero - 1);

                Console.WriteLine($"Passageiro removido: {passageiroRemovido}");
            }
            else
            {
            Console.WriteLine("Número de passageiro inválido.");
            }
        }
        else
        {
            Console.WriteLine("Digite um número válido.");
        }

            }
        }

        else if (opcaoPassageiros == "4")
        {
            if (passageiros.Count == 0)
        {
            Console.WriteLine("Nenhum passageiro cadastrado para editar.");
        }
        else
        {
            Console.WriteLine("Passageiros cadastrados:");

            for (int i = 0; i < passageiros.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {passageiros[i]}");
            }

            Console.WriteLine("Digite o número do passageiro que deseja editar:");

            string? entrada = Console.ReadLine();

        if (int.TryParse(entrada, out int numero))
{
            if (numero >= 1 && numero <= passageiros.Count)
            {
                string passageiroAtual = passageiros[numero - 1];

                Console.WriteLine($"Passageiro selecionado: {passageiroAtual}");

                Console.WriteLine("Digite o novo nome do passageiro:");

                string? novoNome = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(novoNome))
                {
                    Console.WriteLine("O novo nome não pode ficar vazio.");
                }
                else
                {
                    Console.WriteLine("Digite o novo sobrenome do passageiro:");

                    string? novoSobrenome = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(novoSobrenome))
                    {
                        Console.WriteLine("O novo sobrenome não pode ficar vazio.");
                    }
                    else
                    {
                        string novoNomeCompleto = $"{novoNome} {novoSobrenome}";

                        passageiros[numero - 1] = novoNomeCompleto;

                        Console.WriteLine($"Passageiro atualizado: {novoNomeCompleto}");
                    }
                    }
            }
            else
            {
                Console.WriteLine("Número de passageiro inválido.");
            }
        }
        else
        {
            Console.WriteLine("Digite um número válido.");
        }

            }

            }

        }
    }
    else if (opcao == "2")
    {

        opcaoVoos = "";

        while (opcaoVoos != "0")
        {

        Console.WriteLine("=============================");
        Console.WriteLine("         MENU DE VOOS         ");
        Console.WriteLine("=============================");
        Console.WriteLine("1 - Cadastrar voo");
        Console.WriteLine("2 - Listar voos");
        Console.WriteLine("3 - Remover voo");
        Console.WriteLine("4 - Editar voo");
        Console.WriteLine("0 - Voltar ao menu principal");
        Console.WriteLine("Escolha uma opção:");

        opcaoVoos = Console.ReadLine();

        Console. Clear();

        if (opcaoVoos == "0")
        {
            Console.WriteLine("Voltando ao menu principal...");
            Console.WriteLine("Menu principal carregado.");
        }
        else if (opcaoVoos == "1")
        {
           Console.WriteLine("Você selecionou Cadastrar voo.");
           Console.WriteLine("Digite o número do voo:");
           string? numeroVoo = Console.ReadLine();

        if (string. IsNullOrWhiteSpace(numeroVoo))
        {
            Console.WriteLine("O número não pode ficar vazio.");
        }
        else
        {
            Console.WriteLine("Digite a origem do voo:");

            string? origem = Console.ReadLine();

            if (String.IsNullOrWhiteSpace(origem))
            {
                Console.WriteLine("A origem não pode ficar vazio.");      
            }
            else
        {
            Console.WriteLine("Digite o destino do voo:");

            string? destino = Console.ReadLine();

            if (String.IsNullOrWhiteSpace(destino))
            {
                Console.WriteLine("O destino não pode ficar vazio.");      
            }
            else
        {
            Console.WriteLine("Digite o horário do voo:");

            string? horario = Console.ReadLine();

            if (String.IsNullOrWhiteSpace(horario))
            {
                Console.WriteLine("O horário não pode ficar vazio.");      
            }
            else
            {
                string vooCompleto = $"{numeroVoo} | {origem} | {destino} | {horario}";

                voos.Add(vooCompleto);

                Console.WriteLine($"Voo cadastrado: {vooCompleto}");
            }
        }
    }
}

    }
        else if (opcaoVoos == "2")
        {
            if (voos.Count == 0)
            {
                Console.WriteLine("Nenhum voo cadastrado.");      
            }
            else
            {
                Console.WriteLine("Voos cadastrados:");

                for (int i = 0; i < voos.Count; i++)
                {
                    Console.WriteLine($"{i + 1} - {voos[i]}");
                }     
            }
        }

         else if (opcaoVoos == "3")
        {
            if (voos.Count == 0)
            {
                Console.WriteLine("Nenhum voo cadastrado para remover.");
            }
            else
            {
                Console.WriteLine("Voos cadastrados:");

            for (int i = 0; i < voos.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {voos[i]}");
            }

                Console.WriteLine("Digite o número do voo que deseja remover:");

                string? entrada = Console.ReadLine();

            if (int.TryParse(entrada, out int numero))
            {
            if (numero >= 1 && numero <= voos.Count)
            {
                string vooRemovido = voos[numero - 1];

                voos.RemoveAt(numero - 1);

                Console.WriteLine($"Voo removido: {vooRemovido}");
            }
            else
            {
            Console.WriteLine("Número de voo inválido.");
            }
        }
        else
        {
            Console.WriteLine("Digite um número válido.");
        }

            }
        }

        else if (opcaoVoos == "4")
        {
            if (voos.Count == 0)
        {
            Console.WriteLine("Nenhum voo cadastrado para editar.");
        }
        else
        {
            Console.WriteLine("Voos cadastrados:");

            for (int i = 0; i < voos.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {voos[i]}");
            }

            Console.WriteLine("Digite o número do voo que deseja editar:");

            string? entrada = Console.ReadLine();

        if (int.TryParse(entrada, out int numero))
        {
        if (numero >= 1 && numero <= voos.Count)
        {
            string vooAtual = voos[numero - 1];

            Console.WriteLine($"Voo selecionado: {vooAtual}");

            Console.WriteLine("Digite o novo número do voo:");
            string? novoNumeroVoo = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(novoNumeroVoo))
            {
                Console.WriteLine("O novo número do voo não pode ficar vazio.");
            }
            else
            {
                Console.WriteLine("Digite a nova origem:");
                string? novaOrigem = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(novaOrigem))
            {
                Console.WriteLine("A nova origem não pode ficar vazio.");
            }
            else
            {
                Console.WriteLine("Digite o novo destino:");
                string? novoDestino = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(novoDestino))
            {
                Console.WriteLine("O novo destino não pode ficar vazio.");
            }
            else
            {
                Console.WriteLine("Digite o novo horário:");
                string? novoHorario = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(novoHorario))
            {
               Console.WriteLine("O novo horário não pode ficar vazio.");
            }
            else
            {
                string novoVooCompleto = $"{novoNumeroVoo} | {novaOrigem} | {novoDestino} | {novoHorario}";

                voos[numero - 1] = novoVooCompleto;

                Console.WriteLine($"Voo atualizado: {novoVooCompleto}");
            }
            }
        }
    }
}
        else
        {
            Console.WriteLine("Número do voo inválido.");
        }
        }
        else
        {
            Console.WriteLine("Digite um número válido.");
        }

            }

            }

        }
    }
    else if (opcao == "3")
    {
        opcaoAeronaves = "";

        while (opcaoAeronaves != "0")
        {

        Console.WriteLine("=============================");
        Console.WriteLine("       MENU DE AERONAVES      ");
        Console.WriteLine("=============================");
        Console.WriteLine("1 - Cadastrar aeronave");
        Console.WriteLine("2 - Listar aeronaves");
        Console.WriteLine("3 - Remover aeronave");
        Console.WriteLine("4 - Editar aeronave");
        Console.WriteLine("0 - Voltar ao menu principal");
        Console.WriteLine("Escolha uma opção:");

        opcaoAeronaves = Console.ReadLine();

        Console. Clear();

        if (opcaoAeronaves == "0")
        {
            Console.WriteLine("Voltando ao menu principal...");
            Console.WriteLine("Menu principal carregado.");
        }
        else if (opcaoAeronaves == "1")
        {
           Console.WriteLine("Você selecionou Cadastrar aeronave.");
           Console.WriteLine("Digite o modelo da aeronave:");
           string? modeloAeronave = Console.ReadLine();

        if (string. IsNullOrWhiteSpace(modeloAeronave))
        {
            Console.WriteLine("O modelo não pode ficar vazio.");
        }
        else
        {
            Console.WriteLine("Digite o fabricante da aeronave:");

            string? fabricante = Console.ReadLine();

            if (String.IsNullOrWhiteSpace(fabricante))
            {
                Console.WriteLine("O fabricante não pode ficar vazio.");      
            }
            else
        {
            Console.WriteLine("Digite a capacidade da aeronave:");

            string? capacidade = Console.ReadLine();

            if (String.IsNullOrWhiteSpace(capacidade))
            {
                Console.WriteLine("A capacidade não pode ficar vazio.");      
            }
            else
        {
            Console.WriteLine("Digite o código de identificação da aeronave:");

            string? codigoIdentificacao = Console.ReadLine();

            if (String.IsNullOrWhiteSpace(codigoIdentificacao))
            {
                Console.WriteLine("O código de identificação não pode ficar vazio.");      
            }
            else
            {
                string aeronaveCompleta = $"{modeloAeronave} | {fabricante} | {capacidade} | {codigoIdentificacao}";

                aeronaves.Add(aeronaveCompleta);

                Console.WriteLine($"Aeronave cadastrada: {aeronaveCompleta}");
            }
        }
    }
}

    }
        else if (opcaoAeronaves == "2")
        {
            if (aeronaves.Count == 0)
            {
                Console.WriteLine("Nenhuma aeronave cadastrada.");      
            }
            else
            {
                Console.WriteLine("Aeronaves cadastradas:");

                for (int i = 0; i < aeronaves.Count; i++)
                {
                    Console.WriteLine($"{i + 1} - {aeronaves[i]}");
                }     
            }
        }

         else if (opcaoAeronaves == "3")
        {
            if (aeronaves.Count == 0)
            {
                Console.WriteLine("Nenhuma aeronave cadastrada para remover.");
            }
            else
            {
                Console.WriteLine("Aeronaves cadastradas:");

            for (int i = 0; i < aeronaves.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {aeronaves[i]}");
            }

                Console.WriteLine("Digite o número da aeronave que deseja remover:");

                string? entrada = Console.ReadLine();

            if (int.TryParse(entrada, out int numero))
            {
            if (numero >= 1 && numero <= aeronaves.Count)
            {
                string aeronaveRemovida = aeronaves[numero - 1];

                aeronaves.RemoveAt(numero - 1);

                Console.WriteLine($"Aeronave removida: {aeronaveRemovida}");
            }
            else
            {
            Console.WriteLine("Modelo de aeronave inválido.");
            }
        }
        else
        {
            Console.WriteLine("Digite um modelo válido.");
        }

            }
        }

        else if (opcaoAeronaves == "4")
        {
            if (aeronaves.Count == 0)
        {
            Console.WriteLine("Nenhuma aeronave cadastrada para editar.");
        }
        else
        {
            Console.WriteLine("Aeronaves cadastradas:");

            for (int i = 0; i < aeronaves.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {aeronaves[i]}");
            }

            Console.WriteLine("Digite o modelo da aeronave que deseja editar:");

            string? entrada = Console.ReadLine();

        if (int.TryParse(entrada, out int numero))
        {
        if (numero >= 1 && numero <= aeronaves.Count)
        {
            string aeronaveAtual = aeronaves[numero - 1];

            Console.WriteLine($"Aeronave selecionada: {aeronaveAtual}");

            Console.WriteLine("Digite o novo modelo da aeronave:");
            string? novoModeloAeronave = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(novoModeloAeronave))
            {
                Console.WriteLine("O novo modelo da aeronave não pode ficar vazio.");
            }
            else
            {
                Console.WriteLine("Digite o novo fabricante:");
                string? novoFabricante = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(novoFabricante))
            {
                Console.WriteLine("O novo fabricante não pode ficar vazio.");
            }
            else
            {
                Console.WriteLine("Digite a nova capacidade:");
                string? novaCapacidade = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(novaCapacidade))
            {
                Console.WriteLine("A nova cacacidade não pode ficar vazia.");
            }
            else
            {
                Console.WriteLine("Digite o novo código de identificação:");
                string? novoCodigoIdentificacao = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(novoCodigoIdentificacao))
            {
               Console.WriteLine("O novo código de identificação não pode ficar vazio.");
            }
            else
            {
                string novaAeronaveCompleta = $"{novoModeloAeronave} | {novoFabricante} | {novaCapacidade} | {novoCodigoIdentificacao}";

                aeronaves[numero - 1] = novaAeronaveCompleta;

                Console.WriteLine($"Aeronave atualizada: {novaAeronaveCompleta}");
            }
            }
        }
    }
}
        else
        {
            Console.WriteLine("Modelo da aeronave inválida.");
        }
        }
        else
        {
            Console.WriteLine("Digite um modelo válido.");
        }

            }

            }

        }
    }
    else if (opcao == "4")
    {
        opcaoReservas = "";

        while (opcaoReservas != "0")
        {

        Console.WriteLine("=============================");
        Console.WriteLine("         MENU RESERVAS       ");
        Console.WriteLine("=============================");
        Console.WriteLine("1 - Cadastrar reserva");
        Console.WriteLine("2 - Listar reserva");
        Console.WriteLine("3 - Remover reserva");
        Console.WriteLine("4 - Editar reserva");
        Console.WriteLine("0 - Voltar ao menu principal");
        Console.WriteLine("Escolha uma opção:");

        opcaoReservas = Console.ReadLine();

        Console. Clear();

        if (opcaoReservas == "0")
        {
            Console.WriteLine("Voltando ao menu principal...");
            Console.WriteLine("Menu principal carregado.");
        }
        else if (opcaoReservas == "1")
        {
           Console.WriteLine("Você selecionou Cadastrar reserva.");
           Console.WriteLine("Digite o nome do passageiro:");
           string? nomePassageiro = Console.ReadLine();

        if (string. IsNullOrWhiteSpace(nomePassageiro))
        {
            Console.WriteLine("O nome do passageiro não pode ficar vazio.");
        }
        else
        {
            Console.WriteLine("Digite o número do voo:");

            string? numeroVoo = Console.ReadLine();

            if (String.IsNullOrWhiteSpace(numeroVoo))
            {
                Console.WriteLine("O número do voo não pode ficar vazio.");      
            }
            else
        {
            Console.WriteLine("Digite o assento da aeronave:");

            string? assento = Console.ReadLine();

            if (String.IsNullOrWhiteSpace(assento))
            {
                Console.WriteLine("O assento não pode ficar vazio.");      
            }
            else
        {
            Console.WriteLine("Digite o código da reserva:");

            string? codigoReserva = Console.ReadLine();

            if (String.IsNullOrWhiteSpace(codigoReserva))
            {
                Console.WriteLine("O código da reserva não pode ficar vazio.");      
            }
            else
            {
                string reservaCompleta = $"{nomePassageiro} | {numeroVoo} | {assento} | {codigoReserva}";

                reservas.Add(reservaCompleta);

                Console.WriteLine($"Reserva cadastrada: {reservaCompleta}");
            }
        }
    }
}

    }
        else if (opcaoReservas == "2")
        {
            if (reservas.Count == 0)
            {
                Console.WriteLine("Nenhuma reserva cadastrada.");      
            }
            else
            {
                Console.WriteLine("Reservas cadastradas:");

                for (int i = 0; i < reservas.Count; i++)
                {
                    Console.WriteLine($"{i + 1} - {reservas[i]}");
                }     
            }
        }

         else if (opcaoReservas == "3")
        {
            if (reservas.Count == 0)
            {
                Console.WriteLine("Nenhuma reserva cadastrada para remover.");
            }
            else
            {
                Console.WriteLine("Reservas cadastradas:");

            for (int i = 0; i < reservas.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {reservas[i]}");
            }

                Console.WriteLine("Digite o número da reserva que deseja remover:");

                string? entrada = Console.ReadLine();

            if (int.TryParse(entrada, out int numero))
            {
            if (numero >= 1 && numero <= reservas.Count)
            {
                string reservaRemovida = reservas[numero - 1];

                reservas.RemoveAt(numero - 1);

                Console.WriteLine($"Reserva removida: {reservaRemovida}");
            }
            else
            {
            Console.WriteLine("Número da reserva inválido.");
            }
        }
        else
        {
            Console.WriteLine("Digite um número válido.");
        }

            }
        }

        else if (opcaoReservas == "4")
        {
            if (reservas.Count == 0)
        {
            Console.WriteLine("Nenhuma reserva cadastrada para editar.");
        }
        else
        {
            Console.WriteLine("Reservas cadastradas:");

            for (int i = 0; i < reservas.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {reservas[i]}");
            }

            Console.WriteLine("Digite o número que deseja editar:");

            string? entrada = Console.ReadLine();

        if (int.TryParse(entrada, out int numero))
        {
        if (numero >= 1 && numero <= reservas.Count)
        {
            string reservaAtual = reservas[numero - 1];

            Console.WriteLine($"Reserva selecionada: {reservaAtual}");

            Console.WriteLine("Digite o novo nome do passageiro:");
            string? novoNomePassageiro = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(novoNomePassageiro))
            {
                Console.WriteLine("O novo nome do passageiro não pode ficar vazio.");
            }
            else
            {
                Console.WriteLine("Digite o novo número do voo:");
                string? novoNumeroVoo = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(novoNumeroVoo))
            {
                Console.WriteLine("O novo número do voo não pode ficar vazio.");
            }
            else
            {
                Console.WriteLine("Digite o novo assento:");
                string? novoAssento = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(novoAssento))
            {
                Console.WriteLine("O novo assento não pode ficar vazio.");
            }
            else
            {
                Console.WriteLine("Digite o novo código da reserva:");
                string? novoCodigoReserva = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(novoCodigoReserva))
            {
               Console.WriteLine("O novo código da reserva não pode ficar vazio.");
            }
            else
            {
                string novaReservaCompleta = $"{novoNomePassageiro} | {novoNumeroVoo} | {novoAssento} | {novoCodigoReserva}";

                reservas[numero - 1] = novaReservaCompleta;

                Console.WriteLine($"Reserva atualizada: {novaReservaCompleta}");
            }
            }
        }
    }
}
        else
        {
            Console.WriteLine("Número da reserva inválida.");
        }
        }
        else
        {
            Console.WriteLine("Digite um número válido.");
        }

            }

            }

        }

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