// Nome do programa Screen Sound

string mensagemDeBoasVindas = "Boas vindas ao Screen Sound";

//Lista de bandas

// List<string> ListasDasBandas = new List<string> { "U2", "Limão com mel", "Aviões do Forró"};

Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>(); 
bandasRegistradas.Add("Linkin Park", new List<int> { 10, 8, 6});
bandasRegistradas.Add("The Beatles", new List<int>());

//criando uma função para poder ter aproveitamento de código

void ExibirLogo()
{
//Usando o site fsymbols
Console.WriteLine(@"

░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");
Console.WriteLine(mensagemDeBoasVindas);
}

void ExibirOpcoesDoMenu() {

    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar uma banda "); //usamos o \n para poder separar o código no console.
    Console.WriteLine("Digite 2 para mostrar todas as banda ");
    Console.WriteLine("Digite 3 para avaliar uma banda ");
    Console.WriteLine("Digite 4 para exibir a média de uma banda ");
    Console.WriteLine("Digite -1 para sair ");

    Console.Write("\nDigite a sua opção: ");
    //A ReadLine ele espera que o que a pessoa escolher, aperte enter.
    string opcaoEscolhida = Console.ReadLine()!;
    //Convertendo a string para valor numerico
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    switch (opcaoEscolhidaNumerica) 
    {
        case 1: RegistrarBanda();
            break;
        case 2: MostrarBandasRegistradas();
            break;
        case 3: AvaliarUmaBanda();
            break;
        case 4: ExibirMediaDaBanda();
            break;
        case -1: Console.WriteLine("Foi um prazer, espero que volte logo :) ");
            break;
        default: Console.WriteLine("Opção inválida");
            break;
    }
//case 1
    void RegistrarBanda() {
        Console.Clear();
        ExibirTituloDaOpcao("Registro das bandas");
        Console.Write("Digite o nome da banda que deseja registrar: "); //Usamos apenas o Write quando queremos que a resposta seja solicitada na mesma linha
        string nomeDaBanda = Console.ReadLine()!;
        bandasRegistradas.Add(nomeDaBanda, new List<int>());
        Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
        Thread.Sleep(2000); // Thread usamos quando queremos fazer que o sistema demore um pouco para poder exibir a mensagem.
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
//case 2
    void MostrarBandasRegistradas() {

        Console.Clear();
        ExibirTituloDaOpcao("Exibir todas as bandas registradas");
        /* Exemplo de for 
        o "for" faz com que percorra a lista das bandas.
        for (int i = 0; i < ListasDasBandas.Count; i++)
        {
            Console.WriteLine($"Banda: {ListasDasBandas[i]}");
        }*/
        foreach (string banda in bandasRegistradas.Keys)
        {
            Console.WriteLine($"Banda: {banda}");
        }
        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey(); // quando digitado, ele volta para o menu principal.
        Console.Clear();
        ExibirOpcoesDoMenu();
    }


}
void ExibirTituloDaOpcao(string titulo)
{
    int quantidadeDeLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}
// case 3
void AvaliarUmaBanda() {
    //Digite qual banda deseja valiar
    
    // se não, volta ao menu principal
    Console.Clear();
    ExibirTituloDaOpcao("Avaliar banda");
    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string nomeDaBanda = Console.ReadLine()!;
    //se a banda existir no dicionario >> atribuir uma nota
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        Console.Write($"Qual a nota que a banda {nomeDaBanda} merece: ");
        int nota = int.Parse(Console.ReadLine()!);
        bandasRegistradas[nomeDaBanda].Add(nota);
        Console.WriteLine($"\nA nota {nota} foi registrada com sucesso para a banda {nomeDaBanda}");
        Thread.Sleep(4000);
        Console.Clear();
        ExibirOpcoesDoMenu();
    } else // se não, volta ao menu principal
    {
        Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada! ");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    } 
}
//case 4
void ExibirMediaDaBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Avaliar banda");
    Console.Write("Digite o nome da banda que deseja exibir a média: ");
    string nomeDaBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        List<int> notasDaBanda = bandasRegistradas[nomeDaBanda];
        Console.WriteLine($"\nA media da banda {nomeDaBanda} é {notasDaBanda.Average()}"); //Average exibe a media
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    } else
    {
        Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
};

ExibirOpcoesDoMenu();


/*
* Crie uma variável chamada curso e guarde nela o nome do curso estudado, mostrar o conteúdo no console.
string curso = "csharp";
Console.WriteLine(curso);
* Crie uma variável chamada nome e outra sobrenome e guarde nelas as informações, mostrar o conteúdo no console.
string nome = "Jéssica";
string sobrenome = "Porfirio";
Console.WriteLine(nome + " " + sobrenome);
*/
