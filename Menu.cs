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
        Console.WriteLine("5 - Pagar Pedido");
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
                case 5:
                    PagarPedido();
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
        pizzas.Add(Pizzas.Adicionar());
        Console.Write("\nPIZZA CRIADA COM SUCESSO");
        Thread.Sleep(1000);
    }

    public static void ListarPizza() {
        Console.Clear();
        if (pizzas.Count() == 0) {
            Console.Write("A lista de pizzas está vazia, adicione pizzas antes de tentar novamente.");
            Thread.Sleep(2000);
            Iniciar();
            return;
        }
        
        Pizzas.Listar(pizzas);

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

        pedidos.Add(Pedidos.Criar(pizzas));

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
        Pedidos.Listar(pedidos);
        Console.Write("Pressione ENTER para voltar:");
        Console.ReadLine();

        Iniciar();
    }

    public static void PagarPedido() {
        Console.Clear();
        Pedidos.Listar(pedidos);

    }
}