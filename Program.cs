using System.Linq.Expressions;

var pizzas = new List<Pizza>();
var pedidos = new List<Pedido>();
var loopOn = true;

while (loopOn) {
    int? escolha = null;
    var notNum = true;

    while (notNum) {
        Console.Clear();
        Console.WriteLine("Bem-Vindo ao Projeto de Pizarria");
        Console.WriteLine("ESCOLHA UMA OPÇÃO:");
        Console.WriteLine("1 - Adicionar Pizza");
        Console.WriteLine("2 - Listar Pizzas");
        Console.WriteLine("3 - Criar Novo Pedido");
        Console.WriteLine("4 - Listar Pedidos");
        Console.WriteLine("0 - Sair");

        if (int.TryParse(Console.ReadLine(), out int escolhaInt)) {
            notNum = false;
            escolha = escolhaInt;
        } else {
            Console.Clear();
            Console.Write("O valor não é numérico, tente novamente.");
            Thread.Sleep(1500);
        }
    }

    switch (escolha) {
        case 1:
            Console.Clear();
            var pizza = new Pizza();

            Console.WriteLine("Adicionar uma Pizza!");
            Thread.Sleep(500);

            Console.Write("Digite o nome da Pizza: ");
            var nomePizza = Console.ReadLine();
            pizza.nome = nomePizza;

            Console.Write("Digite os sabores da Pizza separados por vírgula: ");
            string strSaboresPizza = Console.ReadLine();
            List<string> saboresPizza = strSaboresPizza.Split(',').Select(palavra => palavra.Trim()).ToList();
            pizza.sabores = saboresPizza;

            Console.Write("Digite o preço da Pizza (formato 00.00): ");
            var precoPizza = 0.0f; // Valor padrão para caso o valor inserido não seja um número
            if (float.TryParse(Console.ReadLine(), out float precoPizzaFLoat))
                precoPizza = precoPizzaFLoat;
            else { 
                Console.Write("O valor inserido não é numérico, portanto 00.00 foi atribuído ao valor da pizza.");
                Thread.Sleep(1500);
            }
            pizza.preco = precoPizza;

            pizzas.Add(pizza);

            Console.Write("\nPIZZA CRIADA COM SUCESSO");
            Thread.Sleep(1000);

            break;
            
        case 2:
            Console.Clear();
            
            Console.WriteLine("Listar as Pizzas!");
            Thread.Sleep(500);
            
            foreach (var pz in pizzas) {
                Console.WriteLine("\nNOME: " + pz.nome);
                Console.Write("SABORES: ");
                foreach (var sabor in pz.sabores) {
                    Console.Write(pz.sabores[pz.sabores.Count() - 1] != sabor ? sabor + ", " : sabor); // Caso seja o último sabor listado, não haverá vírgula depois
                }
                Console.WriteLine(string.Format("\nPREÇO: R$ {0:0.00}", pz.preco));

                if (pizzas[pizzas.Count() - 1] != pz) Thread.Sleep(500); else Thread.Sleep(0);
            }

            Console.Write("\nPressione ENTER para voltar:");
            Console.ReadLine();
            
            break;

        case 3:
            Console.Clear();
            var pedido = new Pedido();

            Console.Write("Nome do Cliente: ");
            var nome = Console.ReadLine();
            pedido.nomeCliente = nome;

            Console.Write("Telefone do Cliente: ");
            var telefone = Console.ReadLine();
            pedido.telefoneCliente = telefone;

            Console.WriteLine("Escolha uma pizza para adicionar:");
            var tempPizzas = new List<Pizza>();
            foreach (var pizza in pizzas) {
                Console.WriteLine(string.Format("{0} - R$ {0:0.00}", pizza.nome, pizza.preco));
            }
            var nao = true;
            while (nao) {
                var pizzaEscolhida = Console.ReadLine();
                if (pedido.Check(pizzaEscolhida)) {
                    
                }
            }

            break;

        case 4:
            Console.Clear();

            Console.WriteLine(string.Format("Cliente: {0} - {0}", pedido.nomeCliente, pedido.telefoneCliente));
            Console.WriteLine("Pizzas do Pedido:");
            foreach

            break;

        case 0:
            Console.Clear();
            Console.WriteLine("Volte sempre!");
            Thread.Sleep(2000);
            Console.Clear();
            loopOn = false;

            break;

        default:
            Console.Clear();
            Console.WriteLine("OPÇÃO INVÁLIDA! SEM PIZZAS!!! Tente novamente.");
            Thread.Sleep(1500);

            break;
    }
}