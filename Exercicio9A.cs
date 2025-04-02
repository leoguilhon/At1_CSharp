public static class Exercicio9A
{
    public static void Run()
    {
        Console.WriteLine("\n--- Exercício 9A: Controle de Estoque (Arrays) ---");

        Produto[] estoque = new Produto[5];
        int quantidadeProdutos = 0;

        while (true)
        {
            Console.WriteLine("\n=== Menu ===");
            Console.WriteLine("1 - Inserir Produto");
            Console.WriteLine("2 - Listar Produtos");
            Console.WriteLine("3 - Sair");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    if (quantidadeProdutos >= estoque.Length)
                    {
                        Console.WriteLine("Limite de produtos atingido!");
                        break;
                    }

                    estoque[quantidadeProdutos] = LerProduto();
                    quantidadeProdutos++;
                    break;

                case "2":
                    ListarProdutos(estoque, quantidadeProdutos);
                    break;

                case "3":
                    return;

                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }
    }

    private static Produto LerProduto()
    {
        Console.Write("Nome do produto: ");
        string nome = Console.ReadLine();

        int quantidade;
        do
        {
            Console.Write("Quantidade: ");
        } while (!int.TryParse(Console.ReadLine(), out quantidade) || quantidade < 0);

        decimal preco;
        do
        {
            Console.Write("Preço unitário: ");
        } while (!decimal.TryParse(Console.ReadLine(), out preco) || preco < 0);

        return new Produto(nome, quantidade, preco);
    }

    private static void ListarProdutos(Produto[] estoque, int quantidade)
    {
        if (quantidade == 0)
        {
            Console.WriteLine("Nenhum produto cadastrado.");
            return;
        }

        Console.WriteLine("\n=== Produtos Cadastrados ===");
        for (int i = 0; i < quantidade; i++)
        {
            Console.WriteLine($"Produto: {estoque[i].Nome} | " +
                             $"Quantidade: {estoque[i].Quantidade} | " +
                             $"Preço: R$ {estoque[i].Preco:F2}");
        }
    }
}

public class Produto
{
    public string Nome { get; }
    public int Quantidade { get; }
    public decimal Preco { get; }

    public Produto(string nome, int quantidade, decimal preco)
    {
        Nome = nome;
        Quantidade = quantidade;
        Preco = preco;
    }
}