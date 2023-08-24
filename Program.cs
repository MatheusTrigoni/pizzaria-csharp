void menu(List<Pizza> listaPz) {
    Console.WriteLine("Bem-Vindo ao Projeto de Pizarria");
    Console.WriteLine("ESCOLHA UMA OPÇÃO:");
    Console.WriteLine("1 - Adicionar Pizza");
    Console.WriteLine("2 - Listar Pizzas");

    var escolha = int.Parse(Console.ReadLine());

    if (escolha == 1) {
        var pizza = new Pizza();

        Console.WriteLine("Adicionar uma Pizza!");

        Console.WriteLine("Digite o nome da Pizza:");
        var nomePizza = Console.ReadLine();
        pizza.nome = nomePizza;

        Console.WriteLine("Digite os sabores da Pizza separados por vírgula:");
        string strSaboresPizza = Console.ReadLine();
        var saboresPizza = new List<string>();
        string strTemp = "";
        foreach (var i in saboresPizza) {
            if (i == ",") {
                saboresPizza.Add(strTemp);
                strTemp = "";
            } else {
                strTemp += i;
            }
        }
        pizza.sabores = saboresPizza;

        Console.WriteLine("Digite o preço da Pizza (formato 00,00):");
        var precoPizza = float.Parse(Console.ReadLine());
        pizza.preco = precoPizza;

        listaPz.Add(pizza);

        Console.WriteLine("PIZZA CRIADA COM SUCESSO");

        menu(listaPz);
    }
    else if (escolha == 2) {
        Console.WriteLine("Listar as Pizzas!");

        foreach (var pz in listaPz) {
            Console.WriteLine("NOME: " + pz.nome);
            Console.Write("SABORES: ");
            foreach (var sabor in pz.sabores) {
                Console.Write(sabor + ", ");
            }
            Console.WriteLine(string.Format("\nPREÇO: {0}", pz.preco));
        }

        menu(listaPz);
    }
    else {
        Console.WriteLine("OPÇÃO INVÁLIDA! SEM PIZZAS!!! Tente novamente.");
        menu(listaPz);
    }
}

var pizzas = new List<Pizza>();
menu(pizzas);