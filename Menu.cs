public static class Menu {
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
    }

    public static void AdicionarPizza(List<Pizza> pizzas) {
        Console.Clear();

        Pizza? pizza = Pizzas.Adicionar(pizzas);
        if (pizza == null) return;

        pizzas.Add(pizza);
        Console.Write("\nPIZZA CRIADA COM SUCESSO");
        Thread.Sleep(1000);
    }

    public static void ListarPizza(List<Pizza> pizzas) {
        Console.Clear();
        if (pizzas.Count() == 0) {
            Console.Write("A lista de pizzas está vazia, adicione pizzas antes de tentar novamente.");
            Thread.Sleep(2000);
            return;
        }
        
        Pizzas.Listar(pizzas);
    }

    public static void CriarPedido(List<Pedido> pedidos, List<Pizza> pizzas) {
        Console.Clear();
        if (pizzas.Count() == 0) {
            Console.Write("A lista de pizzas está vazia, portanto não é possível criar pedidos.");
            Thread.Sleep(2000);
            return;
        }

        Pedido? pedido = Pedidos.Criar(pizzas);
        if (pedido == null) return;
        
        pedidos.Add(pedido);
    }

    public static void ListarPedido(List<Pedido> pedidos) {
        Console.Clear();
        if (pedidos.Count() == 0) {
            Console.Write("A lista de pedidos está vazia, crie pedidos antes de tentar novamente.");
            Thread.Sleep(2000);
            return;
        }

        Pedidos.Listar(pedidos);
    }

    public static void PagarPedido(List<Pedido> pedidos) {
        Console.Clear();
        if (pedidos.Count() == 0) {
            Console.Write("A lista de pedidos está vazia, crie pedidos antes de tentar novamente.");
            Thread.Sleep(2000);
            return;
        }

        Pedidos.Pagar(pedidos);
    }
}