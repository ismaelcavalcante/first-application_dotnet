using System;

namespace Revisao
{
  class Program
  {
    static void Main(string[] args)
    {
      Aluno[] alunos = new Aluno[5];
      int indiceAluno = 0;

      string opcaoUsuario = ObterOpcaoUsuario();

      while (opcaoUsuario.ToUpper() != "X")
      {
        switch (opcaoUsuario)
        {
          case "1":
            //TODO: Adicionar aluno
            Console.WriteLine("Informe o nome do aluno:");
            Aluno aluno = new Aluno();
            aluno.Nome = Console.ReadLine();
            Console.WriteLine("Informe a nota do aluno:");
            if (decimal.TryParse(Console.ReadLine(), out decimal nota))
            {
              aluno.Nota = nota;
            }
            else
            {
              throw new ArgumentException("O valor da nota deve ser decimal");
            }
            alunos[indiceAluno] = aluno;
            indiceAluno++;


            break;

          case "2":
            //TODO: listar alunos
            foreach (var a in alunos)
            {
              if (a.Nome != null)
              {
                Console.WriteLine($"Aluno: {a.Nome}  -  Nota: {a.Nota}");
              }
            }
            break;

          case "3":
            //TODO: calcular média geral
            decimal notaTotal = 0;
            decimal nrAlunos = 0;


            for (int i = 0; i < alunos.Length; i++)
            {
              if (alunos[i].Nome != null)
              {
                notaTotal += alunos[i].Nota;
                nrAlunos++;
              }
            }

            decimal mediaGeral = notaTotal / nrAlunos;
            ConceitoEnum conceitoGeral;
            if (mediaGeral < 2)
            {
              conceitoGeral = ConceitoEnum.E;
            }
            else if (mediaGeral < 4)
            {
              conceitoGeral = ConceitoEnum.D;
            }
            else if (mediaGeral < 6)
            {
              conceitoGeral = ConceitoEnum.C;
            }
            else if (mediaGeral < 8)
            {
              conceitoGeral = ConceitoEnum.B;
            }
            else
            {
              conceitoGeral = ConceitoEnum.A;
            }

            Console.WriteLine($"Média Geral: {mediaGeral} - Conceito Geral: {conceitoGeral}");
            break;

          default:
            throw new ArgumentException();
        }

        opcaoUsuario = ObterOpcaoUsuario();
      }

    }

    private static string ObterOpcaoUsuario()
    {
      Console.WriteLine();
      Console.WriteLine("Informe a opção desejada:");
      Console.WriteLine("1 - Inserir novo aluno");
      Console.WriteLine("2 - Listar alunos");
      Console.WriteLine("3 - Calcular Média Geral");
      Console.WriteLine("X - Sair");
      Console.WriteLine();

      string opcaoUsuario = Console.ReadLine();
      Console.WriteLine();
      return opcaoUsuario;
    }
  }
}
