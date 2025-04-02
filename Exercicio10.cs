public static class Exercicio10
{
    public static void Run()
    {
        Console.WriteLine("\n--- Exercício 10: Jogo de Adivinhação ---");

        Random random = new Random();
        int numeroSecreto = random.Next(1, 51);
        int tentativasRestantes = 5;

        Console.WriteLine("Tente adivinhar o número entre 1 e 50.");
        Console.WriteLine($"Você tem {tentativasRestantes} tentativas.");

        while (tentativasRestantes > 0)
        {
            Console.Write($"\nTentativa {6 - tentativasRestantes}: ");

            if (!int.TryParse(Console.ReadLine(), out int palpite))
            {
                Console.WriteLine("Por favor, digite um número válido.");
                continue;
            }

            if (palpite < 1 || palpite > 50)
            {
                Console.WriteLine("O número deve estar entre 1 e 50.");
                continue;
            }

            if (palpite == numeroSecreto)
            {
                Console.WriteLine($"Parabéns! Você acertou o número {numeroSecreto}!");
                return;
            }

            tentativasRestantes--;

            if (tentativasRestantes > 0)
            {
                Console.WriteLine(palpite < numeroSecreto ? "Tente um número maior." : "Tente um número menor.");
                Console.WriteLine($"Tentativas restantes: {tentativasRestantes}");
            }
        }

        Console.WriteLine($"\nSuas tentativas acabaram! O número era {numeroSecreto}.");
    }
}