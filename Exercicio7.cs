public static class Exercicio7
{
    public static void Run()
    {
        Console.WriteLine("\n--- Exercício 7: Banco Digital ---");

        ContaBancaria conta = new ContaBancaria("Leonardo Guilhon");

        Console.WriteLine($"Titular: {conta.Titular}");

        conta.Depositar(500);
        conta.ExibirSaldo();

        conta.Sacar(700);
        conta.Sacar(200);
        conta.ExibirSaldo();
    }
}

public class ContaBancaria
{
    public string Titular { get; }
    private decimal _saldo;

    public ContaBancaria(string titular)
    {
        Titular = titular;
        _saldo = 0;
    }

    public void Depositar(decimal valor)
    {
        if (valor <= 0)
        {
            Console.WriteLine("O valor do depósito deve ser positivo!");
            return;
        }

        _saldo += valor;
        Console.WriteLine($"Depósito de R$ {valor:F2} realizado com sucesso!");
    }

    public void Sacar(decimal valor)
    {
        Console.WriteLine($"Tentativa de saque: R$ {valor:F2}");

        if (valor <= 0)
        {
            Console.WriteLine("O valor do saque deve ser positivo!");
            return;
        }

        if (valor > _saldo)
        {
            Console.WriteLine("Saldo insuficiente para realizar o saque!");
            return;
        }

        _saldo -= valor;
        Console.WriteLine($"Saque de R$ {valor:F2} realizado com sucesso!");
    }

    public void ExibirSaldo()
    {
        Console.WriteLine($"Saldo atual: R$ {_saldo:F2}");
    }
}