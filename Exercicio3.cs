public static class Exercicio3
{
    public static void Run()
    {
        Console.WriteLine("\n--- Exercício 3: Calculadora ---");

        double num1 = LerNumero("Digite o primeiro número:");
        double num2 = LerNumero("Digite o segundo número:");
        int operacao = LerOperacao();

        RealizarOperacao(num1, num2, operacao);
    }

    private static double LerNumero(string mensagem)
    {
        double numero;
        Console.WriteLine(mensagem);
        while (!double.TryParse(Console.ReadLine(), out numero))
        {
            Console.WriteLine("Número inválido. Digite novamente:");
        }
        return numero;
    }

    private static int LerOperacao()
    {
        Console.WriteLine("Escolha a operação:");
        Console.WriteLine("1 - Soma");
        Console.WriteLine("2 - Subtração");
        Console.WriteLine("3 - Multiplicação");
        Console.WriteLine("4 - Divisão");

        int operacao;
        while (!int.TryParse(Console.ReadLine(), out operacao) || operacao < 1 || operacao > 4)
        {
            Console.WriteLine("Opção inválida. Digite 1, 2, 3 ou 4:");
        }
        return operacao;
    }

    private static void RealizarOperacao(double num1, double num2, int operacao)
    {
        double resultado = 0;
        string simbolo = "";

        switch (operacao)
        {
            case 1:
                resultado = num1 + num2;
                simbolo = "+";
                break;
            case 2:
                resultado = num1 - num2;
                simbolo = "-";
                break;
            case 3:
                resultado = num1 * num2;
                simbolo = "*";
                break;
            case 4:
                if (num2 == 0)
                {
                    Console.WriteLine("Erro: Divisão por zero!");
                    return;
                }
                resultado = num1 / num2;
                simbolo = "/";
                break;
        }

        Console.WriteLine($"Resultado: {num1} {simbolo} {num2} = {resultado}");
    }
}