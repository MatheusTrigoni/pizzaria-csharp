public static class Pizzas {
    public static Pizza? Adicionar(List<Pizza> pizzas) { // Cria e retorna uma pizza ou retorna null caso o usuário desista
        Console.WriteLine("Adicionar uma Pizza!\n");
        Thread.Sleep(500);

        Console.Write("Digite o nome da Pizza (0 ou ENTER para retornar ao menu): ");
        string? nomePizza = Console.ReadLine();
        if (string.Equals(nomePizza, "0") || string.IsNullOrEmpty(nomePizza)) return null; // Retorna ao menu

        // Verificando se existe uma pizza com mesmo nome na lista de pizzas
        foreach (Pizza pizza in pizzas) {
            if (nomePizza == pizza.Nome) {
                Console.Clear();
                Console.WriteLine("A pizza que você deseja adicionar já existe. Tente novamente.");
                Thread.Sleep(1500);
                return null; // Retorna ao menu
            }
        }

        Console.Write("Digite os sabores da Pizza separados por vírgula (0 ou ENTER para retornar ao menu): ");
        string? strSaboresPizza = Console.ReadLine();
        if (string.Equals(strSaboresPizza, "0") || string.IsNullOrEmpty(strSaboresPizza)) return null; // Retorna ao menu
        List<string> saboresPizza = strSaboresPizza.Split(',').Select(palavra => palavra.Trim()).ToList();

        while (true) {
            Console.Write("Digite o preço da Pizza (formato 00.00) [Pressione ENTER para cancelar]: ");
            if (double.TryParse(Console.ReadLine(), out double precoPizza))
                return new Pizza(nomePizza, saboresPizza, precoPizza);
            else { 
                Console.Write("O valor inserido não é numérico. Digite 0 para retornar ao menu ou ENTER para tentar novamente:");
                if (string.Equals(Console.ReadLine(), "0")) return null; // Retorna ao menu
            }
        }
    }

    public static void Listar(List<Pizza> pizzas) { // Lista as pizzas
        Console.WriteLine("Listar as Pizzas!");
        Thread.Sleep(150);
        
        foreach (Pizza pizza in pizzas) {
            Thread.Sleep(350);
            Console.WriteLine("\nNOME: " + pizza.Nome);
            Console.Write("SABORES: ");
            foreach (string sabor in pizza.Sabores) {
                // Caso seja o último sabor listado, não haverá vírgula depois
                Console.Write(pizza.Sabores[pizza.Sabores.Count() - 1] != sabor ? sabor + ", " : sabor);
            }
            Console.WriteLine(string.Format("\nPREÇO: R$ {0:0.00}", pizza.Preco));
        }

        Console.Write("\nPressione ENTER para voltar:");
        Console.ReadLine();
    }
}