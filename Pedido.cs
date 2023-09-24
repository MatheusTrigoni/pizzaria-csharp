public class Pedido {
    public string NomeCliente { get; private set; }
    public string TelefoneCliente { get; private set; }
    // Escolha do dicionário para contabilizar pizzas escolhidas mais de uma vez
    public Dictionary<Pizza, int> Pizzas { get; private set; } = new Dictionary<Pizza, int>();
    public bool Pago { get; private set; } = false;
    public double Preco { get; private set; } = 0;
    public double? Restante { get; private set; }
    public Pedido(string NomeCliente, string TelefoneCliente) {
        this.NomeCliente = NomeCliente;
        this.TelefoneCliente = TelefoneCliente;
    }

    public void AdicionaPizza(Pizza pizza) { // Adiciona pizzas ao pedido
        if (Pizzas.ContainsKey(pizza))
            Pizzas[pizza] += 1;
        else
            Pizzas[pizza] = 1;

        Preco += pizza.Preco;
        Restante = Preco;
    }

    public void Pagar(double? valor) { // Efetua o pagamento do pedido
        if (valor >= Restante) {
            Restante = 0;
            Pago = true;
        } else Restante -= valor;
    }

    public double? CalcularTroco(double? valor) { // Verifica se haverá troco ou não e retorna o mesmo
        if (valor <= Restante)
            return 0;
        return valor - Restante;
    }
}