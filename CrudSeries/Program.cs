using System;

namespace CrudSeries
{    
    class Program
    {
       static serieRepositorio repositorio = new serieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            System.Console.WriteLine("Agradecemos a preferência, votle sempre!");
            Console.ReadLine();
        }

        private static void VisualizarSerie()
        {
            System.Console.WriteLine("Entre com Id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornarPorId(indiceSerie);

            System.Console.WriteLine(serie);
        }

        private static void ExcluirSerie()
        {
            System.Console.WriteLine("Entre com Id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Excluir(indiceSerie);
        }

        private static void AtualizarSerie()
        {
            System.Console.WriteLine("Entre com Id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName
                (typeof(Genero), i));
            }
            System.Console.WriteLine("Entre com o genêro entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Entre com o título da série: ");
            string entradaTitulo = Console.ReadLine();

            System.Console.WriteLine("Entre com o ana de inicio da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Entre com a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(
                id: indiceSerie,
                genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                ano: entradaAno,
                descricao: entradaDescricao
            );
        
            repositorio.Atualizar(indiceSerie, atualizaSerie);
        }

        private static void ListarSeries() 
        {
            var lista = repositorio.Lista();
            if (lista.Count == 0) 
            {       
                System.Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach (var serie in lista) 
            {
                var excluido = serie.retornaExcluido();

                Console.WriteLine($"#ID {serie.retornaId()} - {serie.retornaTitulo()} - {(excluido? "Excluido" : " " )}");
            }
        }

        private static void InserirSerie()
        {
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName
                (typeof(Genero), i));
            }
            System.Console.WriteLine("Entre com o genêro entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Entre com o título da série: ");
            string entradaTitulo = Console.ReadLine();

            System.Console.WriteLine("Entre com o ana de inicio da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Entre com a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(
                id: repositorio.ProximoId(),
                genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                ano: entradaAno,
                descricao: entradaDescricao
            );
        
            repositorio.Inserir(novaSerie);
        }
            
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("  Streamming de Séries - DIO");
            Console.WriteLine("------------------------------");
            Console.WriteLine("");
            Console.WriteLine(" 1. Listar séries");
            Console.WriteLine(" 2. Inserir nova série");
            Console.WriteLine(" 3. Atualizar série");
            Console.WriteLine(" 4. Excluir série");
            Console.WriteLine(" 5. Visualizar série");
            Console.WriteLine(" C. Limpar Tela");
            Console.WriteLine(" X. Sair");
            Console.WriteLine("");
            Console.WriteLine("------------------------------");
            Console.Write(" Informe a opção desejada: ");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;  
        }
    }
}