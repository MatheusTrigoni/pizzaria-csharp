public class Pizza {
    public string? nome { get; set; }
    public List<string>? sabores { get; set; }
    public float preco { get; set; }
}

public class Pedido {
    public string? nomeCliente { get; set; }
    public string? telefoneCliente { get; set; }
    public List<Pizza>? pizzas { get; set; } = new List<Pizza>();
    private double Preco = 0;

    public void AdicionaPizza(Pizza pizza) {
        pizzas.Add(pizza);
        Preco += pizza.Valor;
    }
}