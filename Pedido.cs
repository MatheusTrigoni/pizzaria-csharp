public class Pedido {
    public string NomeCliente { get; set; }
    public string TelefoneCliente { get; set; }
    public List<Pizza> Pizzas { get; set; } = new List<Pizza>();
    public string Estado { get; private set; }
    public double Preco { get; private set; }

    public Pedido(string NomeCliente, string TelefoneCliente) {
        this.NomeCliente = NomeCliente;
        this.TelefoneCliente = TelefoneCliente;
        Estado = "NÃO";
        Preco = 0;
    }

    public void AdicionaPizza(Pizza pizza) {
        Pizzas.Add(pizza);
        Preco += pizza.Preco;
    }

    public void AlterarEstado() {
        if (string.Equals(Estado, "NÃO")) Estado = "SIM";
        else Estado = "NÃO";
    }
}