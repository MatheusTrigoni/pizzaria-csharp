using System.Runtime.InteropServices;

public static class Pedidos {
    public static Pedido? Criar(List<Pizza> pizzas) { // Cria e retorna um pedido ou retorna null caso o usuário desista
        Console.WriteLine("Criar um Pedido!\n");
        Thread.Sleep(500);

        Console.Write("Nome do Cliente (0 ou ENTER para retornar ao menu): ");
        string? nome = Console.ReadLine();
        if (string.Equals(nome, "0") || string.IsNullOrEmpty(nome)) return null; // Retorna ao menu

        Console.Write("Telefone do Cliente (0 ou ENTER para retornar ao menu): ");
        string? telefone = Console.ReadLine();
        if (string.Equals(telefone, "0") || string.IsNullOrEmpty(telefone)) return null; // Retorna ao menu

        Pedido pedido = new Pedido(nome, telefone);

        Console.WriteLine("Escolha uma pizza para adicionar (0 ou ENTER para retornar ao menu):");
        foreach (Pizza pizza in pizzas) {
            Thread.Sleep(350);
            Console.WriteLine(string.Format("{0} - R$ {1:0.00}", pizza.Nome, pizza.Preco));
        }

        bool naoEscolhidas = true; // Mantém o loop até que pelo menos uma pizza seja escolhida
        bool semPizza = true; // Enquanto true, mostra uma mensagem dizendo que não há pizza correspondente à inserida
        string? pizzaEscolhida;

        while (naoEscolhidas) {
            pizzaEscolhida = Console.ReadLine();
            if (string.Equals(pizzaEscolhida, "0") || string.IsNullOrEmpty(pizzaEscolhida)) return null; // Retorna ao menu

            foreach (Pizza pizza in pizzas) {
                if (string.Equals(pizzaEscolhida, pizza.Nome)) {
                    pedido.AdicionaPizza(pizza);
                    
                    while (true) {
                        Console.WriteLine("\nDeseja acrescentar mais uma pizza? (1 - SIM | 2 - NÃO)");
                        if (int.TryParse(Console.ReadLine(), out int escolhaInt)) {
                            if (escolhaInt == 1) {
                                semPizza = false;
                                Console.Write("Escolha uma pizza para adicionar: ");
                                break;
                            } else if (escolhaInt == 2) {
                                semPizza = false;
                                naoEscolhidas = false;
                                break;
                            } else {
                                Console.WriteLine("Opção inválida. Tente novamente.");
                            }
                        } else Console.WriteLine("Valor não númerico, tente novamente");
                    }
                    
                    break;
                } else semPizza = true;
            }   

            if (semPizza) {
                Console.WriteLine("O nome digitado não corresponde a nenhuma pizza correspondente, tente novamente.");
                Console.Write("Escolha uma pizza para adicionar (0 ou ENTER para retornar ao menu): ");
            }
        }

        return pedido;
    }

    public static void Listar(List<Pedido> pedidos) { // Lista os pedidos criados
        Console.WriteLine("Listar os Pedidos!");
        Thread.Sleep(150);
        foreach (Pedido pedido in pedidos) {
            Thread.Sleep(350);

            Console.WriteLine("\nPEDIDO " + pedidos.IndexOf(pedido));
            Console.WriteLine(string.Format("Cliente: {0} - {1}", pedido.NomeCliente, pedido.TelefoneCliente));

            Console.WriteLine("Pizzas do Pedido:");
            // Iterando o dicionário para fazer o display dos dados de cada pizza
            foreach (KeyValuePair<Pizza, int> pizza in pedido.Pizzas) {
                Console.WriteLine(string.Format(
                    "({0}x) {1} - R$ {2:0.00} (R$ {3:0.00})",
                    pizza.Value, pizza.Key.Nome, pizza.Key.Preco, pizza.Value * pizza.Key.Preco
                ));
            }

            Console.WriteLine(string.Format("Total: R$ {0:0.00}", pedido.Preco));
            Console.WriteLine(string.Format("Quanto Falta para Pagar: R$ {0:0.00}", pedido.Restante));
            Console.Write("Pago: ");
            Console.WriteLine(pedido.Pago ? "SIM" : "NÃO");
        }
        Console.Write("\nPressione ENTER para voltar:");
        Console.ReadLine();
    }

    public static void Pagar(List<Pedido> pedidos) { // Inicia o processo de pagamento de pedidos
        // Definindo os dados do pagamento
        Pedido? pedido = Pagamento.EscolherPedido(pedidos);
        if (pedido == null) return; // Retorna ao menu

        string[]? formasPagamento = Pagamento.DefinirFormaPagamento();
        if (formasPagamento == null) return; // Retorna ao menu

        double? valorPagamento = Pagamento.DefinirValor();
        if (valorPagamento == null) return; // Retorna ao menu

        double? troco = pedido.CalcularTroco(valorPagamento);
        pedido.Pagar(valorPagamento);

        // Concluindo o processo listando os dados
        Console.Clear();
        Console.WriteLine("VALOR  RECEBIDO COM SUCESSO\n");
        Thread.Sleep(150);
        Console.Write(string.Format("TOTAL PAGO: R$ {0:0.00} ", valorPagamento));

        if (string.IsNullOrEmpty(formasPagamento[1]))
            Console.WriteLine($" ({formasPagamento[0]})");
        else
            Console.WriteLine($" ({formasPagamento[0]}, {formasPagamento[1]})");

        Console.WriteLine(string.Format("FALTA: R$ {0:0.00}", pedido.Restante));

        if (string.Equals(formasPagamento[0], "DINHEIRO") || string.Equals(formasPagamento[1], "DINHEIRO"))
            Console.WriteLine(string.Format("TROCO: R$ {0:0.00}", troco));
        else
            Console.WriteLine("TROCO: R$ 0.00");

        Console.Write("\nPressione ENTER para voltar:");
        Console.ReadLine();
    }
}