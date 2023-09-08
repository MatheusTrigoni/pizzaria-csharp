public class Pedido {
    public string NomeCliente { get; set; }
    public string TelefoneCliente { get; set; }
    public List<Pizza> Pizzas { get; set; } = new List<Pizza>();
    private double Preco = 0;

    public Pedido(string NomeCliente, string TelefoneCliente) {
        this.NomeCliente = NomeCliente;
        this.TelefoneCliente = TelefoneCliente;
    }

    public void AdicionaPizza(Pizza pizza) {
        Pizzas.Add(pizza);
        Preco += pizza.Preco;
    }

    public void Mostrar() {
        Console.WriteLine(string.Format("Cliente: {0} - {1}", NomeCliente, TelefoneCliente));
        Console.WriteLine("Pizzas do Pedido:");
        foreach (var pizza in Pizzas) {
            Console.WriteLine(string.Format("{0} - R$ {1:0.00}", pizza.Nome, pizza.Preco));
        }
        Console.WriteLine(string.Format("Total: R$ {0:0.00}\n", Preco));
    }
}