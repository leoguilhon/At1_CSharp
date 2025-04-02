public static class Exercicio8
{
    public static void Run()
    {
        Console.WriteLine("\n--- Exercício 8: Cadastro de Funcionários ---");

        Funcionario funcionario = new Funcionario("Carlos Santos", "Analista", 5000);
        Gerente gerente = new Gerente("Juliana Cunha", "Gerente de Projetos", 8000);

        Console.WriteLine("Funcionário:");
        funcionario.ExibirSalario();

        Console.WriteLine("\nGerente:");
        gerente.ExibirSalario();
    }
}

public class Funcionario
{
    public string Nome { get; }
    public string Cargo { get; }
    protected decimal SalarioBase { get; }

    public Funcionario(string nome, string cargo, decimal salarioBase)
    {
        Nome = nome;
        Cargo = cargo;
        SalarioBase = salarioBase;
    }

    public virtual void ExibirSalario()
    {
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Cargo: {Cargo}");
        Console.WriteLine($"Salário: R$ {SalarioBase:F2}");
    }
}

public class Gerente : Funcionario
{
    private const decimal BONUS = 0.2m;

    public Gerente(string nome, string cargo, decimal salarioBase)
        : base(nome, cargo, salarioBase)
    {
    }

    public override void ExibirSalario()
    {
        base.ExibirSalario();
        decimal salarioComBonus = SalarioBase * (1 + BONUS);
        Console.WriteLine($"Bônus (20%): R$ {SalarioBase * BONUS:F2}");
        Console.WriteLine($"Salário Total: R$ {salarioComBonus:F2}");
    }
}