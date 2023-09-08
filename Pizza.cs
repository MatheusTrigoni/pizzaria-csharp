using System.Reflection.Emit;

public class Pizza {
    public string Nome { get; set; }
    public List<string> Sabores { get; set; }
    public double Preco { get; set; }

    public Pizza(string Nome, List<string> Sabores, double Preco) {
        this.Nome = Nome;
        this.Sabores = Sabores;
        this.Preco = Preco;
    }
}