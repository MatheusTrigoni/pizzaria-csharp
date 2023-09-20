using System.Runtime.InteropServices;

public static class Pedidos {
    public static Pedido Criar(List<Pizza> pizzas) {
        Console.WriteLine("Criar um Pedido!\n");
        Thread.Sleep(500);

        Console.Write("Nome do Cliente: ");
        string nome = Console.ReadLine()!;

        Console.Write("Telefone do Cliente: ");
        string telefone = Console.ReadLine()!;

        Pedido pedido = new Pedido(nome, telefone);

        Console.WriteLine("Escolha uma pizza para adicionar:");
        foreach (Pizza pz in pizzas) {
            Thread.Sleep(350);
            Console.WriteLine(string.Format("{0} - R$ {1:0.00}", pz.Nome, pz.Preco));
        }

        bool naoEscolhidas = true;
        bool semPizza = true;
        string pizzaEscolhida;

        while (naoEscolhidas) {
            pizzaEscolhida = Console.ReadLine()!;
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

            if (semPizza)
                Console.WriteLine("O nome digitado não corresponde a nenhuma pizza correspondente, tente novamente.");
        }

        return pedido;
    }

    public static void Listar(List<Pedido> pedidos) {
        foreach (Pedido pedido in pedidos) {
            Thread.Sleep(350);

            Console.WriteLine(string.Format("Cliente: {0} - {1}", pedido.NomeCliente, pedido.TelefoneCliente));
            
            Console.WriteLine("Pizzas do Pedido:");
            foreach (Pizza pizza in pedido.Pizzas) {
                Console.WriteLine(string.Format("{0} - R$ {1:0.00}", pizza.Nome, pizza.Preco));
            }

            Console.WriteLine(string.Format("Total: R$ {0:0.00}\n", pedido.Preco));

            Console.WriteLine("Pago: " + pedido.Estado);
        }
    }
}