public class Pizza {
    public string nome { get; set; }
    public List<string> sabores { get; set; }
    public float preco { get; set; }
}

public class Pedido {
    public string nomeCliente { get; set; }
    public string telefoneCliente { get; set; }
    public Pizza pizzas { get; set; }

    public bool Check(string pizzaRef) {
        foreach (var pizza in this.pizzas) {
            if (pizzaRef == pizza.nome) return true;
        }

        return false;
    }
}