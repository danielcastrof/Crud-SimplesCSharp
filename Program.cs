using System;

namespace CadastroSeries
{
    class Program
    {
        static RepositorioSeries repositorio = new RepositorioSeries();
        static void Main(string[] args)
        {
            catalogo();
            string opcao = Console.ReadLine().ToUpper();
            //string argumento = Console.ReadLine();



            while (opcao != "X")
            {

                switch (opcao)
                {
                    case "1":
                        novaSerie();
                        break;
                    case "2":
                        listarSeries();
                        break;
                    case "3":
                        viewSerie();
                        break;
                    case "4":
                        excluirSerie();
                        break;
                    case "5":
                        atualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Opção Inválida");
                        break;

                }
                catalogo();
                opcao = Console.ReadLine().ToUpper();
            }


        }

        private static void catalogo()
        {
            Console.WriteLine("\nBRzFlix Séries!!!");
            Console.WriteLine("Informe a opção desejada: \n");

            Console.WriteLine("1 - Iserir novas séries");
            Console.WriteLine("2 - Listar suas séries");
            Console.WriteLine("3 - Visualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Atualizar série");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair\n");
        }
        private static void novaSerie()
        {
            Console.WriteLine("Inserir nova Série: \n");

            Console.WriteLine("Escolha o gênero desejado: ");
            foreach (int i in Enum.GetValues(typeof(Series.Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Series.Genero), i));
            }

            int gen = int.Parse(Console.ReadLine());

            Console.WriteLine("Escolha o título da série: ");

            string tit = Console.ReadLine();

            Console.WriteLine("Escreva um breve resumo sobre a série: ");

            string res = Console.ReadLine();

            Console.WriteLine("Escolha o ano de produção da série: ");

            double ano = double.Parse(Console.ReadLine());

            Console.WriteLine("Esta série ainda está em atividade: ");

            foreach (int i in Enum.GetValues(typeof(Series.Atividade)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Series.Atividade), i));
            }

            int atv = int.Parse(Console.ReadLine());

            Series nova = new Series(repositorio.NextId(), tit, (Series.Genero)gen, res, ano, (Series.Atividade)atv);

            repositorio.Inserir(nova);

            Console.WriteLine("Série adicionada: \n");
            Console.WriteLine(nova.ToString());

        }

        private static void viewSerie()
        {

            Console.Write("Digite o ID da série: ");

            var lista = repositorio.Listar();

            int idSerie = int.Parse(Console.ReadLine());



            if (lista.Count <= idSerie)
            {
                Console.WriteLine("\nID de série inexistente");
            }
            else
            {
                var serie = repositorio.RetornoID(idSerie);
                Console.WriteLine("\n" + serie);
            }


        }

        private static void listarSeries()
        {
            Console.WriteLine("Lista de Séries: \n");

            var lista = repositorio.Listar();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.getExcluido();

                Console.WriteLine("{0}: {1} {2}", serie.getId(), serie.getNome(), (excluido ? "*Excluído*" : ""));
            }

            Console.WriteLine("\nInforme a opção desejada: \n");

            Console.WriteLine("1 - Visualizar Série: ");
            Console.WriteLine("2 - Excluir Série: ");
            Console.WriteLine("3 - Atualizar Série: ");
            Console.WriteLine("4 - Menu Principal: \n");

            int opc = int.Parse(Console.ReadLine());

            if (opc == 1)
            {
                viewSerie();
            }
            else if (opc == 2)
            {
                excluirSerie();
            }
            else if (opc == 3)
            {
                atualizarSerie();
            }
            else if (opc == 4)
            {
                Console.WriteLine("Menu Principal: ");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Opção Inválida.\n");
                listarSeries();
            }
        }

        private static void excluirSerie()
        {
            var lista = repositorio.Listar();
            Console.Write("Digite o id da série: ");
            int idSerie = int.Parse(Console.ReadLine());

            if (lista.Count <= idSerie)
            {
                Console.WriteLine("\nID de série inexistente");
            }
            else
            {
                repositorio.Excluir(idSerie);
                Console.WriteLine("\nSérie excluida com sucesso\n");
            }

        }

        private static void atualizarSerie()
        {
            var lista = repositorio.Listar();
            Console.Write("Digite o id da série: ");
            int idSerie = int.Parse(Console.ReadLine());

            if (lista.Count <= idSerie)
            {
                Console.WriteLine("\nID de série inexistente");
            }
            else
            {

                Console.WriteLine("Escolha o gênero desejado: ");
                foreach (int i in Enum.GetValues(typeof(Series.Genero)))
                {
                    Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Series.Genero), i));
                }

                int gen = int.Parse(Console.ReadLine());

                Console.WriteLine("Escolha o título da série: ");

                string tit = Console.ReadLine();

                Console.WriteLine("Escreva um breve resumo sobre a série: ");

                string res = Console.ReadLine();

                Console.WriteLine("Escolha o ano de produção da série: ");

                double ano = double.Parse(Console.ReadLine());

                Console.WriteLine("Esta série ainda está em atividade: ");

                foreach (int i in Enum.GetValues(typeof(Series.Atividade)))
                {
                    Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Series.Atividade), i));
                }

                int atv = int.Parse(Console.ReadLine());

                Series att = new Series(repositorio.NextId(), tit, (Series.Genero)gen, res, ano, (Series.Atividade)atv);

                repositorio.Atualizar(idSerie, att);
            }
        }
    }

}
