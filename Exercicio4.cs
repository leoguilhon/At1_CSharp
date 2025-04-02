public static class Exercicio4
{
    public static void Run()
    {
        Console.WriteLine("\n--- Exercício 4: Dias até Aniversário ---");
        DateTime dataNascimento = LerData("Digite sua data de nascimento (dd/MM/yyyy):");

        DateTime hoje = DateTime.Today;
        DateTime proximoAniversario = new DateTime(hoje.Year, dataNascimento.Month, dataNascimento.Day);

        if (proximoAniversario < hoje)
        {
            proximoAniversario = proximoAniversario.AddYears(1);
        }

        int diasRestantes = (proximoAniversario - hoje).Days;

        if (diasRestantes < 7)
        {
            Console.WriteLine($"Seu próximo aniversário é em {diasRestantes} dias! Está quase chegando! 🎉");
        }
        else
        {
            Console.WriteLine($"Faltam {diasRestantes} dias para seu próximo aniversário!");
        }
    }

    private static DateTime LerData(string mensagem)
    {
        DateTime data;
        Console.WriteLine(mensagem);
        while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null,
              System.Globalization.DateTimeStyles.None, out data))
        {
            Console.WriteLine("Data inválida. Digite no formato dd/MM/yyyy:");
        }
        return data;
    }
}