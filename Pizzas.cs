public static class Pizzas {
    public static Pizza Adicionar() {
        Console.Clear();
        Console.WriteLine("Adicionar uma Pizza!\n");
        Thread.Sleep(500);

        Console.Write("Digite o nome da Pizza: ");
        string nomePizza = Console.ReadLine()!;

        Console.Write("Digite os sabores da Pizza separados por vírgula: ");
        string strSaboresPizza = Console.ReadLine()!;
        List<string> saboresPizza = strSaboresPizza.Split(',').Select(palavra => palavra.Trim()).ToList();

        while (true) {
            Console.Write("Digite o preço da Pizza (formato 00.00): ");
            if (double.TryParse(Console.ReadLine(), out double precoPizza)) {
                Pizza pizza = new Pizza(nomePizza, saboresPizza, precoPizza);

                return pizza;
            } else { 
                Console.Write("O valor inserido não é numérico, tente novamente.");
            }
        }
    }

    public static void Listar(List<Pizza> pizzas) {
        Console.WriteLine("Listar as Pizzas!\n");
        Thread.Sleep(150);
        
        foreach (Pizza pz in pizzas) {
            Thread.Sleep(350);
            Console.WriteLine("\nNOME: " + pz.Nome);
            Console.Write("SABORES: ");
            foreach (string sabor in pz.Sabores) {
                Console.Write(pz.Sabores[pz.Sabores.Count() - 1] != sabor ? sabor + ", " : sabor); // Caso seja o último sabor listado, não haverá vírgula depois
            }
            Console.WriteLine(string.Format("\nPREÇO: R$ {0:0.00}\n", pz.Preco));
        }

        Console.Write("Pressione ENTER para voltar:");
        Console.ReadLine();
    }
}