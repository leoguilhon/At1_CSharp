class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\n=== MENU PRINCIPAL ===");
            Console.WriteLine("1. Exercício 1 - Primeiro Programa");
            Console.WriteLine("2. Exercício 2 - Cifrador de Nome");
            Console.WriteLine("3. Exercício 3 - Calculadora");
            Console.WriteLine("4. Exercício 4 - Dias até Aniversário");
            Console.WriteLine("5. Exercício 5 - Tempo até Formatura");
            Console.WriteLine("6. Exercício 6 - Cadastro de Alunos");
            Console.WriteLine("7. Exercício 7 - Banco Digital");
            Console.WriteLine("8. Exercício 8 - Cadastro de Funcionários");
            Console.WriteLine("9. Exercício 9A - Controle de Estoque (Arrays)");
            Console.WriteLine("10. Exercício 9B - Controle de Estoque (Arquivos)");
            Console.WriteLine("11. Exercício 10 - Jogo de Adivinhação");
            Console.WriteLine("12. Exercício 11 - Cadastro de Contatos");
            Console.WriteLine("13. Exercício 12 - Contatos com Formatação");
            Console.WriteLine("0. Sair");
            Console.Write("Escolha uma opção: ");

            if (!int.TryParse(Console.ReadLine(), out int opcao))
            {
                Console.WriteLine("Opção inválida!");
                continue;
            }

            switch (opcao)
            {
                case 1:
                    Exercicio1.Run();
                    break;
                case 2:
                    Exercicio2.Run();
                    break;
                case 3:
                    Exercicio3.Run();
                    break;
                case 4:
                    Exercicio4.Run();
                    break;
                case 5:
                    Exercicio5.Run();
                    break;
                case 6:
                    Exercicio6.Run();
                    break;
                case 7:
                    Exercicio7.Run();
                    break;
                case 8:
                    Exercicio8.Run();
                    break;
                case 9:
                    Exercicio9A.Run();
                    break;
                case 10:
                    Exercicio9B.Run();
                    break;
                case 11:
                    Exercicio10.Run();
                    break;
                case 12:
                    Exercicio11.Run();
                    break;
                case 13:
                    Exercicio12.Run();
                    break;
                case 0:
                    return;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }
    }
}