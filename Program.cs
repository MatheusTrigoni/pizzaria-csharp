using System.Linq.Expressions;
Console.OutputEncoding = System.Text.Encoding.UTF8;

List<Pizza> pizzas = new List<Pizza>();
List<Pedido> pedidos = new List<Pedido>();
bool rodando = true;

while (rodando) {
    Menu.Iniciar();
    if (int.TryParse(Console.ReadLine(), out int escolha)) {
            switch (escolha) {
                case 1:
                    Menu.AdicionarPizza(pizzas);
                    break;
                case 2:
                    Menu.ListarPizza(pizzas);
                    break;
                case 3:
                    Menu.CriarPedido(pedidos, pizzas);
                    break;
                case 4:
                    Menu.ListarPedido(pedidos);
                    break;
                case 5:
                    Menu.PagarPedido(pedidos);
                    break;
                case 0:
                    Console.Clear();
                    Console.WriteLine("Volte sempre!");
                    Thread.Sleep(2000);
                    Console.Clear();
                    rodando = false;
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Opção inválida, tente novamente.");
                    Thread.Sleep(1500);
                    break;
            }
    } else {
        Console.Clear();
        Console.Write("O valor não é numérico, tente novamente.");
        Thread.Sleep(1500);
    }
}