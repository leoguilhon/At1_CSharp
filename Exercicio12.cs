public static class Exercicio12
{
    private const string ARQUIVO_CONTATOS = "contatos.txt";

    public static void Run()
    {
        Console.WriteLine("\n--- Exercício 12: Contatos com Formatação ---");

        List<Contato> contatos = CarregarContatos();

        while (true)
        {
            Console.WriteLine("\n=== Menu Principal ===");
            Console.WriteLine("1 - Adicionar novo contato");
            Console.WriteLine("2 - Listar contatos");
            Console.WriteLine("3 - Sair");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    AdicionarContato(contatos);
                    break;

                case "2":
                    ListarContatos(contatos);
                    break;

                case "3":
                    return;

                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }
    }

    private static List<Contato> CarregarContatos()
    {
        List<Contato> contatos = new List<Contato>();

        if (File.Exists(ARQUIVO_CONTATOS))
        {
            using (StreamReader sr = File.OpenText(ARQUIVO_CONTATOS))
            {
                string linha;
                while ((linha = sr.ReadLine()) != null)
                {
                    string[] dados = linha.Split(',');
                    if (dados.Length == 3)
                    {
                        contatos.Add(new Contato(dados[0], dados[1], dados[2]));
                    }
                }
            }
        }

        return contatos;
    }

    private static void AdicionarContato(List<Contato> contatos)
    {
        Console.Write("Nome: ");
        string nome = Console.ReadLine();

        Console.Write("Telefone: ");
        string telefone = Console.ReadLine();

        Console.Write("Email: ");
        string email = Console.ReadLine();

        Contato novoContato = new Contato(nome, telefone, email);
        contatos.Add(novoContato);

        using (StreamWriter sw = File.AppendText(ARQUIVO_CONTATOS))
        {
            sw.WriteLine($"{nome},{telefone},{email}");
        }

        Console.WriteLine("Contato cadastrado com sucesso!");
    }

    private static void ListarContatos(List<Contato> contatos)
    {
        if (contatos.Count == 0)
        {
            Console.WriteLine("Nenhum contato cadastrado.");
            return;
        }

        Console.WriteLine("\n=== Formato de Exibição ===");
        Console.WriteLine("1 - Markdown");
        Console.WriteLine("2 - Tabela");
        Console.WriteLine("3 - Texto Puro");
        Console.Write("Escolha o formato: ");

        if (!int.TryParse(Console.ReadLine(), out int formato) || formato < 1 || formato > 3)
        {
            Console.WriteLine("Opção inválida!");
            return;
        }

        ContatoFormatter formatter;
        switch (formato)
        {
            case 1:
                formatter = new MarkdownFormatter();
                break;
            case 2:
                formatter = new TabelaFormatter();
                break;
            case 3:
                formatter = new RawTextFormatter();
                break;
            default:
                formatter = new RawTextFormatter();
                break;
        }

        formatter.ExibirContatos(contatos);
    }
}

public class Contato
{
    public string Nome { get; }
    public string Telefone { get; }
    public string Email { get; }

    public Contato(string nome, string telefone, string email)
    {
        Nome = nome;
        Telefone = telefone;
        Email = email;
    }
}

public abstract class ContatoFormatter
{
    public abstract void ExibirContatos(List<Contato> contatos);
}

public class MarkdownFormatter : ContatoFormatter
{
    public override void ExibirContatos(List<Contato> contatos)
    {
        Console.WriteLine("\n## Lista de Contatos\n");

        foreach (var contato in contatos)
        {
            Console.WriteLine($"- **Nome:** {contato.Nome}");
            Console.WriteLine($"- 📞 Telefone: {contato.Telefone}");
            Console.WriteLine($"- 📧 Email: {contato.Email}\n");
        }
    }
}

public class TabelaFormatter : ContatoFormatter
{
    public override void ExibirContatos(List<Contato> contatos)
    {
        int larguraNome = contatos.Max(c => c.Nome.Length) + 2;
        int larguraTelefone = contatos.Max(c => c.Telefone.Length) + 2;
        int larguraEmail = contatos.Max(c => c.Email.Length) + 2;

        larguraNome = Math.Max(larguraNome, "Nome".Length + 2);
        larguraTelefone = Math.Max(larguraTelefone, "Telefone".Length + 2);
        larguraEmail = Math.Max(larguraEmail, "Email".Length + 2);

        string linhaDivisoria = new string('-', larguraNome + larguraTelefone + larguraEmail + 4);

        Console.WriteLine(linhaDivisoria);
        Console.WriteLine($"| {"Nome".PadRight(larguraNome)}| {"Telefone".PadRight(larguraTelefone)}| {"Email".PadRight(larguraEmail)}|");
        Console.WriteLine(linhaDivisoria);

        foreach (var contato in contatos)
        {
            Console.WriteLine($"| {contato.Nome.PadRight(larguraNome)}| {contato.Telefone.PadRight(larguraTelefone)}| {contato.Email.PadRight(larguraEmail)}|");
        }

        Console.WriteLine(linhaDivisoria);
    }
}

public class RawTextFormatter : ContatoFormatter
{
    public override void ExibirContatos(List<Contato> contatos)
    {
        foreach (var contato in contatos)
        {
            Console.WriteLine($"Nome: {contato.Nome} | Telefone: {contato.Telefone} | Email: {contato.Email}");
        }
    }
}