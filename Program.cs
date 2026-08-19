//Screen Sound
using System.Xml;

string MensagemDeBoasVindas = "Boas Vindas ao Screen Sound";
//List<string> listaDasBandas = new List<string> { "Linkin Park", "System of Down", "Slipknot" };

Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();
bandasRegistradas.Add("Linkin park", new List<int> { 10, 8, 6});
bandasRegistradas.Add("System of Down", new List<int>());


void ExibirLogo()
{
    Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
        ");
    Console.WriteLine(MensagemDeBoasVindas);
}

void ExibirOpcoesMenu() 
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar uma Banda");
    Console.WriteLine("Digite 2 para mostrar todas as Bandas");
    Console.WriteLine("Digite 3 para avaliar uma Banda");
    Console.WriteLine("Digite 4 para exibir a média de uma Banda");
    Console.WriteLine("Digite 0 para sair");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida =  Console.ReadLine()!;
    int opcaoEscolhidaNumerica= int.Parse(opcaoEscolhida);
    
    switch (opcaoEscolhidaNumerica) 
    {
        case 1: RegistrarBanda(); 
            break;
        case 2: MostrarBandasRegistradas();
            break;
        case 3: AvaliarUmaBanda();
            break;
        case 4: mediaDaBanda();
            break;
        case 0: Console.WriteLine("Até a proxima! ");
            break;
        default : Console.WriteLine("Opção invalida");
            break;
    }
}

void RegistrarBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Registro das bandas");
    Console.Write("Digite o nome da banda que deseja registrar: ");
    string nomeDaBanda = Console.ReadLine()!;
    bandasRegistradas.Add(nomeDaBanda, new List<int>());
    Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
    Thread.Sleep(2000);
    Console.Clear();
    ExibirOpcoesMenu();

}

void MostrarBandasRegistradas()
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibindo todas as bandas registradas");
    //for (int i=0; i < listaDasBandas.Count; i++)
    //{
    //    Console.WriteLine($"Banda: {listaDasBandas[i]} ");
    //}

    foreach (string banda in bandasRegistradas.Keys)
    {
        Console.WriteLine($"Banda: {banda} ");
    }
    Console.WriteLine("\nDigite uma tecla para voltar ao menu");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesMenu();
}

void ExibirTituloDaOpcao(string titulo)
{
    int quantidadeDeLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeDeLetras,'*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos+ "\n");
}

void AvaliarUmaBanda()
{
    //digite qual banda deseja avaliar
    // se a banda existir no dicionario >> atribuir uma nota
    //senão, volta ao menu principal
    Console.Clear();
    ExibirTituloDaOpcao("Avaliar banda");

    Console.Write("Digite o nome da banda que deseja avaliar : ");
    string nomeDaBanda = Console.ReadLine()!;
    if(bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        Console.Write($"Qual a nota que a banda {nomeDaBanda} merece : ");
        int nota = int.Parse(Console.ReadLine()!);
        bandasRegistradas[nomeDaBanda].Add(nota);
        Console.WriteLine($"\nA nota {nota} foi registrada com sucesso para a banda {nomeDaBanda}");
        Thread.Sleep(4000);
        Console.Clear();
        ExibirOpcoesMenu();
    } else
    {
        Console.WriteLine($"A banda {nomeDaBanda} não foi encontrada!");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesMenu();
    }
}

void mediaDaBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Nota média da banda");

    Console.Write($" Digite o nome da banda que deseja exibir a média de avaliações : ");
    string nomeDaBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        List<int> notas = bandasRegistradas[nomeDaBanda];
        Console.WriteLine($"A média da banda {nomeDaBanda} é : {notas.Average()}");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesMenu();

    }
    else
    {
        Console.WriteLine($"A banda {nomeDaBanda} não foi encontrada!");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesMenu();
    }

}

ExibirOpcoesMenu();