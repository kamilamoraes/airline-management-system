Console.WriteLine("===========================");
Console.WriteLine(" AIRLINE MANAGEMENT SYSTEM ");
Console.WriteLine("===========================");

Console.WriteLine("1 - Passageiros ");
Console.WriteLine("2 - Voos ");
Console.WriteLine("3 - Aeronaves ");
Console.WriteLine("4 - Reservas ");
Console.WriteLine("0 - Sair ");

Console.WriteLine("Escolha uma opção: ");

string? opcao = Console.ReadLine(); 

Console.WriteLine($"Você escolheu: {opcao}");

if (opcao == "1")
{
    Console.WriteLine("Você selecionou Passageiros.");
}
if (opcao == "2")
{
    Console.WriteLine("Você selecionou Voos.");
}
if (opcao == "3")
{
    Console.WriteLine("Você selecionou Aeronaves.");
}
if (opcao == "4")
{
    Console.WriteLine("Você selecionou Reservas.");
}
if (opcao == "0")
{
    Console.WriteLine("Você escolheu sair do sistema.");
}