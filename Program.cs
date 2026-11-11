using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using AirlineManagementSystem.Data;
using AirlineManagementSystem.Models;

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

                Passageiro novoPassageiro = new Passageiro
                {
                    Nome = nomeCompleto
                };

                dbContext.Passageiros.Add(novoPassageiro);

                dbContext.SaveChanges();

                Console.WriteLine($"Passageiro cadastrado: {nomeCompleto}");
            }
        }

    }
        else if (opcaoPassageiros == "2")
        {
            var passageirosCadastrados = dbContext.Passageiros.ToList();

            if (passageirosCadastrados.Count == 0)
            {
                Console.WriteLine("Nenhum passageiro cadastrado.");    
            }
            else
            {
                Console.WriteLine("Passageiros cadastrados:");

                foreach (var passageiro in passageirosCadastrados)
                {
                     Console.WriteLine($"{passageiro.Id} - {passageiro.Nome}");   
                }    
            }
        }

         else if (opcaoPassageiros == "3")
            {
                var passageirosCadastrados = dbContext.Passageiros.ToList();

                if (passageirosCadastrados.Count == 0)
                {
                    Console.WriteLine("Nenhum passageiro cadastrado para remover.");
                }
                else
                {
                    Console.WriteLine("Passageiros cadastrados:");

                    foreach (var passageiro in passageirosCadastrados)
                    {
                        Console.WriteLine($"{passageiro.Id} - {passageiro.Nome}");
                    }

                    Console.WriteLine("Digite o ID do passageiro que deseja remover:");

                    string? entrada = Console.ReadLine();

                    if (int.TryParse(entrada, out int id))
                    {
                        var passageiroEncontrado = dbContext.Passageiros
                            .FirstOrDefault(p => p.Id == id);

                        if (passageiroEncontrado != null)
                        {
                            dbContext.Passageiros.Remove(passageiroEncontrado);
                            dbContext.SaveChanges();

                            Console.WriteLine($"Passageiro removido: {passageiroEncontrado.Nome}");
                        }
                        else
                        {
                            Console.WriteLine("Passageiro não encontrado");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Digite um ID válido.");
                    }
                }
            }
        
            

        
else if (opcaoPassageiros == "4")
{
    var passageirosCadastrados = dbContext.Passageiros.ToList();

    if (passageirosCadastrados.Count == 0)
    {
        Console.WriteLine("Nenhum passageiro cadastrado para editar.");
    }
    else
    {
        Console.WriteLine("Passageiros cadastrados:");

        foreach (var passageiro in passageirosCadastrados)
        {
            Console.WriteLine($"{passageiro.Id} - {passageiro.Nome}");
        }

        Console.WriteLine("Digite o ID do passageiro que deseja editar:");

        string? entrada = Console.ReadLine();

        if (int.TryParse(entrada, out int id))
        {
            var passageiroEncontrado = dbContext.Passageiros
                .FirstOrDefault(p => p.Id == id);

            if (passageiroEncontrado != null)
            {
                Console.WriteLine($"Passageiro selecionado: {passageiroEncontrado.Nome}");

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

                        passageiroEncontrado.Nome = novoNomeCompleto;

                        dbContext.SaveChanges();

                        Console.WriteLine($"Passageiro atualizado: {novoNomeCompleto}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Passageiro não encontrado.");
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
                var novoVoo = new Voo
                {
                    NumeroVoo = numeroVoo,
                    Origem = origem,
                    Destino = destino,
                    Horario = horario
                };

                dbContext.Voos.Add(novoVoo);
                dbContext.SaveChanges();

                Console.WriteLine($"Voo cadastrado com sucesso! ID: {novoVoo.Id}");
            }
        }
    }
}

    }
        else if (opcaoVoos == "2")
        {

            var voosCadastrados = dbContext.Voos.ToList();

            if (voosCadastrados.Count == 0)
            {
                Console.WriteLine("Nenhum voo cadastrado.");      
            }
            else
            {
                Console.WriteLine("Voos cadastrados:");

                foreach (var voo in voosCadastrados)
                {
                    Console.WriteLine($"ID: {voo.Id} | Número: {voo.NumeroVoo} | Origem: {voo.Origem} | Destino: {voo.Destino} | Horário: {voo.Horario}");    
                }  
            }
        }

        else if (opcaoVoos == "3")
{
    var voosCadastrados = dbContext.Voos.ToList();

    if (voosCadastrados.Count == 0)
    {
        Console.WriteLine("Nenhum voo cadastrado para remover.");
    }
    else
    {
        Console.WriteLine("Voos cadastrados:");

        foreach (var voo in voosCadastrados)
        {
            Console.WriteLine($"ID: {voo.Id} | Número: {voo.NumeroVoo} | Origem: {voo.Origem} | Destino: {voo.Destino}");
        }

        Console.WriteLine("Digite o ID do voo que deseja remover:");

        string? entrada = Console.ReadLine();

        if (int.TryParse(entrada, out int id))
        {
            var vooRemovido = dbContext.Voos.FirstOrDefault(v => v.Id == id);

            if (vooRemovido != null)
            {
                dbContext.Voos.Remove(vooRemovido);
                dbContext.SaveChanges();

                Console.WriteLine($"Voo removido: {vooRemovido.NumeroVoo}");
            }
            else
            {
                Console.WriteLine("ID do voo não encontrado.");
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
    var voosCadastrados = dbContext.Voos.ToList();

    if (voosCadastrados.Count == 0)
    {
        Console.WriteLine("Nenhum voo cadastrado para editar.");
    }
    else
    {
        Console.WriteLine("Voos cadastrados:");

        foreach (var voo in voosCadastrados)
        {
            Console.WriteLine($"ID: {voo.Id} | Número: {voo.NumeroVoo} | Origem: {voo.Origem} | Destino: {voo.Destino} | Horário: {voo.Horario}");
        }

        Console.WriteLine("Digite o ID do voo que deseja editar:");

        string? entrada = Console.ReadLine();

        if (int.TryParse(entrada, out int id))
        {
            var vooAtual = dbContext.Voos.FirstOrDefault(v => v.Id == id);

            if (vooAtual != null)
            {
                Console.WriteLine($"Voo selecionado: {vooAtual.NumeroVoo}");

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
                        Console.WriteLine("A nova origem não pode ficar vazia.");
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
                                vooAtual.NumeroVoo = novoNumeroVoo;
                                vooAtual.Origem = novaOrigem;
                                vooAtual.Destino = novoDestino;
                                vooAtual.Horario = novoHorario;

                                dbContext.SaveChanges();

                                Console.WriteLine("Voo atualizado com sucesso!");
                            }
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("ID do voo não encontrado.");
            }
        }
        else
        {
            Console.WriteLine("Digite um ID válido.");
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

            string? entradaCapacidade = Console.ReadLine();

            if (!int.TryParse(entradaCapacidade, out int capacidade) || capacidade <= 0)
            {
                Console.WriteLine("Digite uma capacidade válida.");      
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
                var novaAeronave = new Aeronave
                {
                    Modelo = modeloAeronave,
                    Fabricante = fabricante,
                    Capacidade = capacidade,
                    CodigoIdentificacao = codigoIdentificacao
                };

                dbContext.Aeronaves.Add(novaAeronave);

                dbContext.SaveChanges();

                Console.WriteLine($"Aeronave cadastrada com sucesso! ID: {novaAeronave.Id}");
            }
        }
    }
}

    }
        else if (opcaoAeronaves == "2")
        {

            var aeronavesCadastradas = dbContext.Aeronaves.ToList();

            if (aeronavesCadastradas.Count == 0)
            {
                Console.WriteLine("Nenhuma aeronave cadastrada.");      
            }
            else
            {
                Console.WriteLine("Aeronaves cadastradas:");

                foreach (var aeronave in aeronavesCadastradas)
                {
                    Console.WriteLine($"ID: {aeronave.Id} | Modelo: {aeronave.Modelo} | Fabricante: {aeronave.Fabricante} | Capacidade: {aeronave.Capacidade} | Código: {aeronave.CodigoIdentificacao}");
                }     
            }
        }

    else if (opcaoAeronaves == "3")
{
    var aeronavesCadastradas = dbContext.Aeronaves.ToList();

    if (aeronavesCadastradas.Count == 0)
    {
        Console.WriteLine("Nenhuma aeronave cadastrada para remover.");
    }
    else
    {
        Console.WriteLine("Aeronaves cadastradas:");

        foreach (var aeronave in aeronavesCadastradas)
        {
            Console.WriteLine($"ID: {aeronave.Id} | Modelo: {aeronave.Modelo} | Fabricante: {aeronave.Fabricante}");
        }

        Console.WriteLine("Digite o ID da aeronave que deseja remover:");

        string? entrada = Console.ReadLine();

        if (int.TryParse(entrada, out int id))
        {
            var aeronaveSelecionada = dbContext.Aeronaves.FirstOrDefault(a => a.Id == id);

            if (aeronaveSelecionada != null)
            {
                dbContext.Aeronaves.Remove(aeronaveSelecionada);

                dbContext.SaveChanges();

                Console.WriteLine($"Aeronave removida com sucesso! ID: {id}");
            }
            else
            {
                Console.WriteLine("ID da aeronave não encontrado.");
            }
        }
        else
        {
            Console.WriteLine("Digite um ID válido.");
        }
    }
}


else if (opcaoAeronaves == "4")
{
    var aeronavesCadastradas = dbContext.Aeronaves.ToList();

    if (aeronavesCadastradas.Count == 0)
    {
        Console.WriteLine("Nenhuma aeronave cadastrada para editar.");
    }
    else
    {
        Console.WriteLine("Aeronaves cadastradas:");

        foreach (var aeronave in aeronavesCadastradas)
        {
            Console.WriteLine($"ID: {aeronave.Id} | Modelo: {aeronave.Modelo} | Fabricante: {aeronave.Fabricante}");
        }

        Console.WriteLine("Digite o ID da aeronave que deseja editar:");

        string? entrada = Console.ReadLine();

        if (int.TryParse(entrada, out int id))
        {
            var aeronaveSelecionada = dbContext.Aeronaves.FirstOrDefault(a => a.Id == id);

            if (aeronaveSelecionada != null)
            {
                Console.WriteLine($"Aeronave selecionada: {aeronaveSelecionada.Modelo}");

                Console.WriteLine("Digite o novo modelo da aeronave:");
                string? novoModelo = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(novoModelo))
                {
                    Console.WriteLine("O novo modelo não pode ficar vazio.");
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
                        string? entradaCapacidade = Console.ReadLine();

                        if (!int.TryParse(entradaCapacidade, out int novaCapacidade) || novaCapacidade <= 0)
                        {
                            Console.WriteLine("Digite uma capacidade válida.");
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
                                aeronaveSelecionada.Modelo = novoModelo;
                                aeronaveSelecionada.Fabricante = novoFabricante;
                                aeronaveSelecionada.Capacidade = novaCapacidade;
                                aeronaveSelecionada.CodigoIdentificacao = novoCodigoIdentificacao;

                                dbContext.SaveChanges();

                                Console.WriteLine($"Aeronave atualizada com sucesso! ID: {aeronaveSelecionada.Id}");
                            }
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("ID da aeronave não encontrado.");
            }
        }
        else
        {
            Console.WriteLine("Digite um ID válido.");
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
                var novaReserva = new Reserva
                {
                    NomePassageiro = nomePassageiro,
                    NumeroVoo = numeroVoo,
                    Assento = assento,
                    CodigoReserva = codigoReserva
                };

                dbContext.Reservas.Add(novaReserva);

                dbContext.SaveChanges();

                Console.WriteLine($"Reserva cadastrada com sucesso! ID: {novaReserva.Id}");
            }
        }
    }
}

    }
    else if (opcaoReservas == "2")
{
    var reservasCadastradas = dbContext.Reservas.ToList();

    if (reservasCadastradas.Count == 0)
    {
        Console.WriteLine("Nenhuma reserva cadastrada.");
    }
    else
    {
        Console.WriteLine("Reservas cadastradas:");

        foreach (var reserva in reservasCadastradas)
        {
            Console.WriteLine($"ID: {reserva.Id} | Passageiro: {reserva.NomePassageiro} | Voo: {reserva.NumeroVoo} | Assento: {reserva.Assento} | Código: {reserva.CodigoReserva}");
        }
    }
}

        else if (opcaoReservas == "3")
{
    var reservasCadastradas = dbContext.Reservas.ToList();

    if (reservasCadastradas.Count == 0)
    {
        Console.WriteLine("Nenhuma reserva cadastrada para remover.");
    }
    else
    {
        Console.WriteLine("Reservas cadastradas:");

        foreach (var reserva in reservasCadastradas)
        {
            Console.WriteLine($"ID: {reserva.Id} | Passageiro: {reserva.NomePassageiro} | Voo: {reserva.NumeroVoo}");
        }

        Console.WriteLine("Digite o ID da reserva que deseja remover:");

        string? entrada = Console.ReadLine();

        if (int.TryParse(entrada, out int id))
        {
            var reservaSelecionada = dbContext.Reservas.FirstOrDefault(r => r.Id == id);

            if (reservaSelecionada != null)
            {
                dbContext.Reservas.Remove(reservaSelecionada);

                dbContext.SaveChanges();

                Console.WriteLine($"Reserva removida com sucesso! ID: {id}");
            }
            else
            {
                Console.WriteLine("ID da reserva não encontrado.");
            }
        }
        else
        {
            Console.WriteLine("Digite um ID válido.");
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
                        Console.WriteLine("Número da reserva inválido.");
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
