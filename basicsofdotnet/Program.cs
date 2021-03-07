using System;

namespace basicsofdotnet
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno [] alunos = new Aluno[5];
            int indiceAluno = 0;
            string opcaoEscolhida = ObterOpcaoUsuario();

            while (opcaoEscolhida.ToUpper() != "X")
            {
                switch (opcaoEscolhida)
                {
                    case "1":
                        Console.Write("Informe o nome do Aluno: ");
                        Aluno aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();
                        Console.Write("Informe a nota do Aluno: ");

                        if (decimal.TryParse(Console.ReadLine(), out decimal Nota)) 
                        {
                            aluno.Nota = Nota;
                        }
                        else 
                        {
                            throw new ArgumentException("Valor da nota deve ser um valor decimal");
                        }
                        alunos[indiceAluno] = aluno;
                        indiceAluno++;
                        break;
                    case "2":
                        foreach(var a in alunos) 
                        {
                            if (!string.IsNullOrEmpty(a.Nome))
                                System.Console.WriteLine($"Aluno: {a.Nome} - Nota: {a.Nota}");
                        }
                        break;
                    case "3":
                        decimal notaTotal = 0;
                        var nrAlunos = 0;

                        for (int i=0; i < alunos.Length; i++) 
                        {
                            if (!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal = notaTotal + alunos[i].Nota;
                                nrAlunos++;
                            }                            
                        }

                        var mediaGeral = notaTotal / nrAlunos;
                        conceito conceitoGeral;

                        if (0 <= mediaGeral && mediaGeral <= 2) 
                        {
                            conceitoGeral = conceito.E;
                        }
                        else if (2 < mediaGeral && mediaGeral <= 4) 
                        {
                            conceitoGeral = conceito.D;
                        }
                        else if (4 < mediaGeral && mediaGeral <= 6) 
                        {
                            conceitoGeral = conceito.C;
                        }
                        else if (6 < mediaGeral && mediaGeral <= 8) 
                        {
                            conceitoGeral = conceito.B;
                        }
                        else  
                        {
                            conceitoGeral = conceito.A;
                        }
                        Console.WriteLine($"Média da turma: {mediaGeral} - Conceito geral da turma: {conceitoGeral}");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                Console.WriteLine();
                Console.WriteLine(">> Atenção! Pressione uma tecla para continuar <<");
                System.Console.ReadKey();
                opcaoEscolhida = ObterOpcaoUsuario();
                System.Console.Clear();
            }
        }

        private static string ObterOpcaoUsuario()
        {
            System.Console.Clear();
            Console.WriteLine("     Saudações Visitante!");
            Console.WriteLine("------------------------------");
            Console.WriteLine();
            Console.WriteLine("  1. Inserir aluno");
            Console.WriteLine("  2. Listar alunos");
            Console.WriteLine("  3. Calcular média da turma");
            Console.WriteLine("  X. Sair ");
            Console.WriteLine();
            Console.WriteLine("------------------------------");
            Console.Write("Escolha uma das opções acima: ");

            string opcaoEscolhida = Console.ReadLine();
            System.Console.Clear();
            Console.WriteLine();
            return opcaoEscolhida;
        }
    }
}
