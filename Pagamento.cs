using System.Linq.Expressions;

public static class Pagamento {
    public static Pedido? EscolherPedido(List<Pedido> pedidos) {
        while (true) {
            Console.Clear();
            Console.WriteLine("Digite o número do pedido (Pressione ENTER para cancelar):");
            foreach (Pedido pd in pedidos) {
                Thread.Sleep(350);
                Console.WriteLine(string.Format("#{0} - Cliente: {1} - Falta: R$ {2:0.00}", pedidos.IndexOf(pd), pd.NomeCliente, pd.Restante));
            }

            if (int.TryParse(Console.ReadLine(), out int index)) {
                // Verificando se o index escolhido se enquadra nos limites da lista de pedidos
                if (index >= 0 && index < pedidos.Count()) {
                    if (pedidos[index].Pago) {
                        Console.Write("O pedido em questão já foi pago. Pressione ENTER para selecionar outro ou digite 0 para sair:");

                        if (string.Equals(Console.ReadLine(), "0")) return null;
                    } else
                        return pedidos[index]; // Pedido não pago (prosegue com o pagamento)
                } else { // Index inválido
                    Console.Write("O valor inserido ultrapassa os limites da lista. Pressione ENTER para tentar outro ou digite 0 para sair:");

                    if (string.Equals(Console.ReadLine(), "0")) return null; // Retorna ao menu
                }
            } else { // Valor não numérico
                Console.Write("O valor inserido não é um valor numérico. Pressione ENTER para tentar outro ou digite 0 para sair:");

                if (string.Equals(Console.ReadLine(), "0")) return null; // Retorna ao menu
            }
        }
    }

    public static string[]? DefinirFormaPagamento() {
        string[] formaPagamento = new string[2];
        int i = 0;

        while (i < 2) {
            Console.Clear();
            // Mudança na mensagem para caso o usuário já tenha escolhido uma forma de pagamento
            Console.Write(i == 0 ? "ESCOLHA A FORMA DE PAGAMENTO" : "ESCOLHA OUTRA FORMA DE PAGAMENTO OU PROSSIGA");
            Console.WriteLine(" (Pressione ENTER para cancelar):");
            Console.WriteLine("1 - Dinheiro\n2 - Cartão de Débito\n3 - Vale-Refeição\n0 - Prosseguir");

            if (int.TryParse(Console.ReadLine(), out int formaPag)) {
                switch (formaPag) {
                    case 1:
                        if (string.Equals(formaPagamento[0], "DINHEIRO")) { // Verifica se a forma de pagamento já foi escolhida
                            Console.WriteLine("Você já selecionou esta forma de pagamento, selecione outra\n");
                            Thread.Sleep(1000);
                        }
                        else {
                            formaPagamento[i] = "DINHEIRO";
                            i += 1;
                        }
                        
                        break;
                    case 2:
                        if (string.Equals(formaPagamento[0], "CARTÃO DE DÉBITO")) { // Verifica se a forma de pagamento já foi escolhida
                            Console.WriteLine("Você já selecionou esta forma de pagamento, selecione outra\n");
                            Thread.Sleep(1000);
                        }
                        else {
                            formaPagamento[i] = "CARTÃO DE DÉBITO";
                            i += 1;
                        }
                        
                        break;
                    case 3:
                        if (string.Equals(formaPagamento[0], "VALE-REFEIÇÃO")) { // Verifica se a forma de pagamento já foi escolhida
                            Console.WriteLine("Você já selecionou esta forma de pagamento, selecione outra\n");
                            Thread.Sleep(1000);
                        }
                        else {
                            formaPagamento[i] = "VALE-REFEIÇÃO";
                            i += 1;
                        }
                        
                        break;
                    case 0:
                        if (i == 0) {
                            Console.WriteLine("Você deve adicionar pelo menos uma forma de pagamento antes de prosseguir");
                            Thread.Sleep(1500);
                        }
                        else {
                            formaPagamento[i] = string.Empty;
                            i += 1;
                        }
                        
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.\n");
                        Thread.Sleep(1000);

                        break;
                }
            } else { // Valor não numérico
                Console.Write("O valor inserido não é um valor numérico. Digite 0 para sair (alterações não serão salvas) ou ENTER para tentar novamente:");
                if (Console.ReadLine() == "0") return null; // Retorna ao menu
            }
        }

        return formaPagamento;
    }

    public static double? DefinirValor() {
        while (true) {
            Console.Clear();
            Console.Write("Digite o valor: ");

            if (double.TryParse(Console.ReadLine(), out double valor)) return valor;
            else {
                Console.WriteLine("O valor inserido não é um valor numérico. Pressione ENTER para tentar outro ou digite 0 para sair.");
                
                if (string.Equals(Console.ReadLine(), "0")) return null; // Retorna ao menu
            }
        }
    }
}