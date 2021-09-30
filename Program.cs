using System;

namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            revisao.Aluno[] alunos = new revisao.Aluno[5];
            var indiceAluno = 0;
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "x")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Console.WriteLine("Informe o nome do aluno:");
                        var aluno = new revisao.Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Informe a note do aluno");

                        if (decimal.TryParse(Console.ReadLine(), out decimal nota)){
                            aluno.Nota = nota;
                        }
                        else {
                            throw new ArgumentException("Valor da nota deve ser decimal");
                        }

                        alunos[indiceAluno] = aluno;
                        indiceAluno++;
 
                        break;

                    case "2":
                        
                        foreach(var a in alunos)
                        {
                            if(!string.IsNullOrEmpty(a.Nome))
                            {

                            Console.WriteLine($"Aluno: {a.Nome} - Nota: {a.Nota}");
                            
                            }
                        }

                        break;

                    case "3":

                        decimal notaTotal = 0;
                        var nrAlunos = 0;

                        for (int i=0; i < alunos.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(alunos[i].Nome)){
                                notaTotal = notaTotal + alunos[i].Nota;
                                nrAlunos++;
                            }
                        }
                        var mediaGeral = notaTotal / nrAlunos;
                        revisao.Conceito conceitoGeral;

                        if (mediaGeral < 2){
                            conceitoGeral = revisao.Conceito.E;
                        }

                        if (mediaGeral < 4){
                            conceitoGeral = revisao.Conceito.D;
                        }
                        else if (mediaGeral < 6){
                            conceitoGeral = revisao.Conceito.C;
                        }
                        else if (mediaGeral < 8){
                            conceitoGeral = revisao.Conceito.B;
                        }
                        else {
                            conceitoGeral = revisao.Conceito.A;
                        }
                        

                        Console.WriteLine($"Média Geral: {mediaGeral} - Conceito: {conceitoGeral}");

                        break;

                    default:
                        throw new ArgumentOutOfRangeException();

                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Inserir Aluno");
            Console.WriteLine("2 - Listar Alunos");
            Console.WriteLine("3 - Calcular média geral");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
