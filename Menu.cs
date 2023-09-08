public static class Menu {
    public static List<Pizza> pizzas = new List<Pizza>();
    public static List<Pedido> pedidos = new List<Pedido>();
    public static void Iniciar() {
        Console.Clear();
        Console.WriteLine("Bem-Vindo ao Projeto de Pizarria");
        Console.WriteLine("ESCOLHA UMA OPÇÃO:");
        Console.WriteLine("1 - Adicionar Pizza");
        Console.WriteLine("2 - Listar Pizzas");
        Console.WriteLine("3 - Criar Novo Pedido");
        Console.WriteLine("4 - Listar Pedidos");
        Console.WriteLine("0 - Sair");

        if (int.TryParse(Console.ReadLine(), out int escolha)) {
            switch (escolha) {
                case 1:
                    AdicionarPizza();
                    break;
                case 2:
                    ListarPizza();
                    break;
                case 3:
                    CriarPedido();
                    break;
                case 4:
                    ListarPedido();
                    break;
                case 0:
                    Console.Clear();
                    Console.WriteLine("Volte sempre!");
                    Thread.Sleep(2000);
                    Console.Clear();
                    return;
                default:
                    Console.WriteLine("Opção inválida, tente novamente.");
                    Thread.Sleep(1500);
                    Iniciar();
                    break;
            }
        } else {
            Console.Clear();
            Console.Write("O valor não é numérico, tente novamente.");
            Thread.Sleep(1500);
            Iniciar();
        }
    }

    public static void AdicionarPizza() {
        Console.Clear();
        Console.WriteLine("Adicionar uma Pizza!\n");
        Thread.Sleep(500);

        Console.Write("Digite o nome da Pizza: ");
        var nomePizza = Console.ReadLine();

        Console.Write("Digite os sabores da Pizza separados por vírgula: ");
        string? strSaboresPizza = Console.ReadLine();
        List<string> saboresPizza = strSaboresPizza.Split(',').Select(palavra => palavra.Trim()).ToList();

        Console.Write("Digite o preço da Pizza (formato 00.00): ");
        if (double.TryParse(Console.ReadLine(), out double precoPizza)) {
            var pizza = new Pizza(nomePizza, saboresPizza, precoPizza);
            pizzas.Add(pizza);

            Console.Write("\nPIZZA CRIADA COM SUCESSO");
            Thread.Sleep(1000);
            Iniciar();
        } else { 
            Console.Write("O valor inserido não é numérico, tente novamente.");
            Thread.Sleep(1500);
            Iniciar();
        }
    }

    public static void ListarPizza() {
        Console.Clear();
        if (pizzas.Count() == 0) {
            Console.Write("A lista de pizzas está vazia, adicione pizzas antes de tentar novamente.");
            Thread.Sleep(2000);
            Iniciar();
            return;
        }
        
        Console.WriteLine("Listar as Pizzas!\n");
        Thread.Sleep(150);
        
        foreach (var pz in pizzas) {
            Thread.Sleep(350);
            Console.WriteLine("\nNOME: " + pz.Nome);
            Console.Write("SABORES: ");
            foreach (var sabor in pz.Sabores) {
                Console.Write(pz.Sabores[pz.Sabores.Count() - 1] != sabor ? sabor + ", " : sabor); // Caso seja o último sabor listado, não haverá vírgula depois
            }
            Console.WriteLine(string.Format("\nPREÇO: R$ {0:0.00}\n", pz.Preco));
        }

        Console.Write("Pressione ENTER para voltar:");
        Console.ReadLine();
        Iniciar();
    }

    public static void CriarPedido() {
        Console.Clear();
        if (pizzas.Count() == 0) {
            Console.Write("A lista de pizzas está vazia, portanto não é possível criar pedidos.");
            Thread.Sleep(2000);
            Iniciar();
            return;
        }

        Console.WriteLine("Criar um Pedido!\n");
        Thread.Sleep(500);

        Console.Write("Nome do Cliente: ");
        var nome = Console.ReadLine();

        Console.Write("Telefone do Cliente: ");
        var telefone = Console.ReadLine();

        var pedido = new Pedido(nome, telefone);

        Console.WriteLine("Escolha uma pizza para adicionar:");
        foreach (var pz in pizzas) {
            Thread.Sleep(350);
            Console.WriteLine(string.Format("{0} - R$ {1:0.00}", pz.Nome, pz.Preco));
        }

        var naoEscolhidas = true;
        var semPizza = true;
        string? pizzaEscolhida;

        while (naoEscolhidas) {
            pizzaEscolhida = Console.ReadLine();
            foreach (var pz in pizzas) {
                if (string.Equals(pizzaEscolhida, pz.Nome)) {
                    pedido.AdicionaPizza(pz);
                    while (true) {
                        Console.WriteLine("Deseja acrescentar mais uma pizza? (1 - SIM | 2 - NÃO)");
                        if (int.TryParse(Console.ReadLine(), out int escolhaInt)) {
                            if (escolhaInt == 1) {
                                semPizza = false;
                                break;
                            } else if (escolhaInt == 2) {
                                semPizza = false;
                                pedidos.Add(pedido);
                                naoEscolhidas = false;
                                break;
                            } else {
                                Console.WriteLine("Opção inválida. Tente novamente.");
                            }
                        }
                    }
                    
                    break;
                }
            }   

            if (semPizza) {
                Console.WriteLine("O nome digitado não corresponde a nenhuma pizza correspondente, tente novamente.");
            }
        }

        Iniciar();
    }

    public static void ListarPedido() {
        Console.Clear();
        if (pedidos.Count() == 0) {
            Console.Write("A lista de pedidos está vazia, crie pedidos antes de tentar novamente.");
            Thread.Sleep(2000);
            Iniciar();
            return;
        }

        Console.WriteLine("Listar os Pedidos!\n");
        Thread.Sleep(150);

        foreach (var pedido in pedidos) {
            Thread.Sleep(350);
            pedido.Mostrar();
        }

        Console.Write("Pressione ENTER para voltar:");
        Console.ReadLine();
        Iniciar();
    }
}