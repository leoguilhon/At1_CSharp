public static class Exercicio5
{
    private static readonly DateTime DataFormatura = new DateTime(2026, 12, 15);

    public static void Run()
    {
        Console.WriteLine("\n--- Exercício 5: Tempo até Formatura ---");
        DateTime dataAtual = LerDataAtual();

        if (dataAtual > DateTime.Today)
        {
            Console.WriteLine("Erro: A data informada não pode ser no futuro!");
            return;
        }

        if (dataAtual >= DataFormatura)
        {
            Console.WriteLine("Parabéns! Você já deveria estar formado!");
            return;
        }

        CalcularTempoRestante(dataAtual);
    }

    private static DateTime LerDataAtual()
    {
        DateTime data;
        Console.WriteLine("Digite a data atual (dd/MM/yyyy):");
        while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null,
              System.Globalization.DateTimeStyles.None, out data))
        {
            Console.WriteLine("Data inválida. Digite no formato dd/MM/yyyy:");
        }
        return data;
    }

    private static void CalcularTempoRestante(DateTime dataAtual)
    {
        int anos = DataFormatura.Year - dataAtual.Year;
        int meses = DataFormatura.Month - dataAtual.Month;
        int dias = DataFormatura.Day - dataAtual.Day;

        if (dias < 0)
        {
            meses--;
            dias += DateTime.DaysInMonth(dataAtual.Year, dataAtual.Month);
        }

        if (meses < 0)
        {
            anos--;
            meses += 12;
        }

        Console.Write($"Faltam {anos} anos, {meses} meses e {dias} dias para sua formatura!");

        if ((DataFormatura - dataAtual).TotalDays < 180)
        {
            Console.WriteLine("\nA reta final chegou! Prepare-se para a formatura!");
        }
    }
}