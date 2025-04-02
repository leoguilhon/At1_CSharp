public static class Exercicio6
{
    public static void Run()
    {
        Console.WriteLine("\n--- Exercício 6: Cadastro de Alunos ---");

        Aluno aluno = new Aluno
        {
            Nome = "Leonardo Guilhon",
            Matricula = "2025211212",
            Curso = "Análise e Desenvolvimento de Sistemas",
            MediaNotas = 9.5
        };

        aluno.ExibirDados();
    }
}

public class Aluno
{
    public string Nome { get; set; }
    public string Matricula { get; set; }
    public string Curso { get; set; }
    public double MediaNotas { get; set; }

    public void ExibirDados()
    {
        Console.WriteLine("--- Dados do Aluno ---");
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Matrícula: {Matricula}");
        Console.WriteLine($"Curso: {Curso}");
        Console.WriteLine($"Média: {MediaNotas:F2}");
        Console.WriteLine($"Situação: {(MediaNotas >= 7 ? "Aprovado" : "Reprovado")}");
    }
}