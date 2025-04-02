public static class Exercicio2
{
    public static void Run()
    {
        Console.WriteLine("\n--- Exercício 2: Cifrador de Nome ---");
        Console.WriteLine("Digite seu nome completo:");
        string nomeCompleto = Console.ReadLine();

        string nomeCifrado = CifrarNome(nomeCompleto);
        Console.WriteLine($"Nome cifrado: {nomeCifrado}");
    }

    private static string CifrarNome(string nome)
    {
        char[] caracteres = nome.ToCharArray();

        for (int i = 0; i < caracteres.Length; i++)
        {
            if (char.IsLetter(caracteres[i]))
            {
                char letra = caracteres[i];
                bool isUpper = char.IsUpper(letra);
                letra = char.ToLower(letra);

                letra = (char)(letra + 2);

                if (letra > 'z')
                {
                    letra = (char)(letra - 26);
                }

                caracteres[i] = isUpper ? char.ToUpper(letra) : letra;
            }
        }

        return new string(caracteres);
    }
}