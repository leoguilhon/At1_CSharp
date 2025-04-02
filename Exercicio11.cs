public static class Exercicio11
{
    private const string ARQUIVO_CONTATOS = "contatos.txt";

    public static void Run()
    {
        Console.WriteLine("\n--- Exercício 11: Cadastro de Contatos ---");

        while (true)
        {
            Console.WriteLine("\n=== Gerenciador de Contatos ===");
            Console.WriteLine("1 - Adicionar novo contato");
            Console.WriteLine("2 - Listar contatos cadastrados");
            Console.WriteLine("3 - Sair");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    AdicionarContato();
                    break;

                case "2":
                    ListarContatos();
                    break;

                case "3":
                    Console.WriteLine("Encerrando programa...");
                    return;

                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }
    }

    private static void AdicionarContato()
    {
        Console.Write("Nome: ");
        string nome = Console.ReadLine();

        Console.Write("Telefone: ");
        string telefone = Console.ReadLine();

        Console.Write("Email: ");
        string email = Console.ReadLine();

        using (StreamWriter sw = File.AppendText(ARQUIVO_CONTATOS))
        {
            sw.WriteLine($"{nome},{telefone},{email}");
        }

        Console.WriteLine("Contato cadastrado com sucesso!");
    }

    private static void ListarContatos()
    {
        if (!File.Exists(ARQUIVO_CONTATOS) || new FileInfo(ARQUIVO_CONTATOS).Length == 0)
        {
            Console.WriteLine("Nenhum contato cadastrado.");
            return;
        }

        Console.WriteLine("\n=== Contatos Cadastrados ===");
        using (StreamReader sr = File.OpenText(ARQUIVO_CONTATOS))
        {
            string linha;
            while ((linha = sr.ReadLine()) != null)
            {
                string[] dados = linha.Split(',');
                if (dados.Length == 3)
                {
                    Console.WriteLine($"Nome: {dados[0]} | Telefone: {dados[1]} | Email: {dados[2]}");
                }
            }
        }
    }
}