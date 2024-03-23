//List<string> listaBandas = new List<string> { "Black Sabbath", "Alice in Chains", "The Strokes", "Black Label Society" };		

Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();	
bandasRegistradas.Add("Black Sabbath", new List<int> {5, 8, 10});
bandasRegistradas.Add("Alice in Chains", new List<int>());


void ExibirLogo () 
{
	Console.WriteLine(@"
	
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");
	Console.WriteLine("Boas Vindas");
}

void ExibirMenu () 
{
	ExibirLogo();
	Console.WriteLine("\n1 Para registrar uma banda:");
	Console.WriteLine("2 Para mostrar todas as bandas:");
	Console.WriteLine("3 Para avaliar uma banda:");
	Console.WriteLine("4 Para exibir a media de uma banda:");
	Console.WriteLine("-1 Para sair:");

	Console.Write("\nDigite a sua opção: ");
	string opcaoEscolhida = Console.ReadLine()!;
	int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);	

	switch (opcaoEscolhidaNumerica) 
	{
		case 1: RegistrarBandas();
			break;
		case 2: MostrarBandasRegistradas();
			break;
		case 3: AvaliarBanda();
			break;
		case 4: ExibirMedia();
			break;
		case -1: Console.WriteLine("Tchau Tchau ^^");
			break;

		default: Console.WriteLine("Opçao invalida: ");
			break;

	}
}

void RegistrarBandas() 
{
	Console.Clear();
	Console.WriteLine("Registro de Bandas");
	Console.Write("Digite o nome da banda que deseja inserir: ");
	string nomeBanda = Console.ReadLine()!;
	bandasRegistradas.Add(nomeBanda, new List<int>());
	Console.WriteLine($"A banda {nomeBanda} foi registrada com sucesso");
	Thread.Sleep(2000);
	Console.Clear();
	ExibirMenu();
}

void MostrarBandasRegistradas () 
{
	Console.Clear();
	Console.WriteLine("Exibindo as Bandas que foram registradas: \n");

	//for (int i = 0; i < listaBandas.Count; i++) 
	//{
	//	Console.WriteLine($"Banda: {listaBandas[i]}");
	//}

	foreach (string banda in bandasRegistradas.Keys) {
		Console.WriteLine($"Banda: {banda}");
	}

	Console.WriteLine("\nDigite qualquer coisa para voltar ao menu");
	Console.ReadKey();
	Console.Clear ();
	ExibirMenu ();
}

void ExibirTituloDaOpcao(string titulo) {
	int quantidadeLetras = titulo.Length;
	string asteriscos = string.Empty.PadLeft(quantidadeLetras, '*');
	Console.WriteLine(asteriscos);
	Console.WriteLine(titulo);
	Console.WriteLine(asteriscos + "\n");
}

void AvaliarBanda() 
{
	//digite qual banda deseja avaliar
	//se a banda existir no dicionario ? atribuir uma nota : volta ao menu

	Console.Clear();
	ExibirTituloDaOpcao("Avaliar Banda");
	Console.Write("Digite o nome da Banda que deseja adicionar: ");
	string nomeBanda = Console.ReadLine()!;

	if (bandasRegistradas.ContainsKey(nomeBanda)){
		Console.Write ($"qual a nome que a {nomeBanda} merece?");
		int nota = int.Parse(Console.ReadLine()!);
		bandasRegistradas[nomeBanda].Add(nota);
		Console.WriteLine($"\nA nota {nota} foi registrada com sucesso para a banda {nomeBanda}");
		Thread.Sleep(4000);
		Console.Clear() ;
		ExibirMenu();
	} else {
		Console.WriteLine($"\nA banda {nomeBanda} não foi encontrada");
		Console.WriteLine("Digite uma tecla para voltar ao menu: ");
		Console.ReadKey();
		Console.Clear();	
		ExibirMenu();
	}
}

void ExibirMedia() {
	Console.Clear();
	ExibirTituloDaOpcao("Exibir a media da banda");
	Console.Write("Digite o nome da Banda que deseja exibir a media: ");
	string nomeBanda = Console.ReadLine()!;
	if (bandasRegistradas.ContainsKey(nomeBanda)) {
		List<int> notasDaBanda = bandasRegistradas[nomeBanda];
		Console.WriteLine($"\n a media da banda {nomeBanda}, é: {notasDaBanda.Average()}");
		Console.WriteLine("digite qualquer tecla para voltar ao menu");
		Console.ReadLine();
		Console.Clear();
		ExibirMenu();
	} else {
		Console.WriteLine($"\n a banda {nomeBanda} nao foi encontrada");
		Console.WriteLine("Digite qualquer tecla para voltar ao menu");
		Console.ReadKey();
		Console.Clear();
		ExibirMenu();
	}
}

ExibirMenu ();