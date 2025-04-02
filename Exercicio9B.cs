public static class Exercicio9B
{
    private const string ARQUIVO_ESTOQUE = "estoque.txt";

    public static void Run()
    {
        Console.WriteLine("\n--- Exercício 9B: Controle de Estoque (Arquivos) ---");

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
                    InserirProduto();
                    break;

                case "2":
                    ListarProdutos();
                    break;

                case "3":
                    return;

                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }
    }

    private static void InserirProduto()
    {
        Produto produto = LerProduto();

        using (StreamWriter sw = File.AppendText(ARQUIVO_ESTOQUE))
        {
            sw.WriteLine($"{produto.Nome},{produto.Quantidade},{produto.Preco}");
        }

        Console.WriteLine("Produto cadastrado com sucesso!");
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

    private static void ListarProdutos()
    {
        if (!File.Exists(ARQUIVO_ESTOQUE) || new FileInfo(ARQUIVO_ESTOQUE).Length == 0)
        {
            Console.WriteLine("Nenhum produto cadastrado.");
            return;
        }

        Console.WriteLine("\n=== Produtos Cadastrados ===");
        using (StreamReader sr = File.OpenText(ARQUIVO_ESTOQUE))
        {
            string linha;
            while ((linha = sr.ReadLine()) != null)
            {
                string[] dados = linha.Split(',');
                if (dados.Length == 3)
                {
                    Console.WriteLine($"Produto: {dados[0]} | " +
                                     $"Quantidade: {dados[1]} | " +
                                     $"Preço: R$ {decimal.Parse(dados[2]):F2}");
                }
            }
        }
    }
}