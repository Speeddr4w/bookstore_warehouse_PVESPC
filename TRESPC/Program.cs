using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRESPC
{
    class Program
    {

        static void Main(string[] args)
        {
            bool continua = true;
            List<Livros> listaLivros = new List<Livros>();
            do
            {
             
                Console.Clear();
                Console.WriteLine("Livrarias Unibrasil - Área Administrativa");
                Console.WriteLine($"Atualmente temos {listaLivros.Count} livros cadastrados");
                Console.WriteLine("1 - Incluir");
                Console.WriteLine("2 - Alterar");
                Console.WriteLine("3 - Excluir");
                Console.WriteLine("4 - Listar");
                Console.WriteLine("5 - Pesquisar");
                Console.WriteLine("6 - Exportar Arquivo.json");
                Console.WriteLine("7 - Importar Arquivo.json");
                Console.WriteLine("9 - Sair");
                Console.WriteLine("Digite a sua opção: ");
                String opc = Console.ReadLine();
                switch (opc)
                {


                    // INCLUIR LIVROS
                    case "1":
                        listaLivros.Add(NovoLivro());
                        Console.Write("Inserção feita com sucesso, voltando ao menu");
                        CounterToMenu();
                        break;

                    // ALTERAR LIVROS
                    case "2":
                        Console.Write("Indique o ID do livro a ser alterado: ");
                        int idAlterar = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine($"Nome: {listaLivros[idAlterar].Nome}");
                        Console.WriteLine($"Preço: R${listaLivros[idAlterar].Preco.ToString("F")}");
                        Console.WriteLine($"Número de Páginas: {listaLivros[idAlterar].NumeroDePaginas}");
                        Console.WriteLine($"Data de Lançamento: {listaLivros[idAlterar].LaunchDate}");
                        Console.WriteLine($"Pontuação: {listaLivros[idAlterar].ScoreRating}");
                        listaLivros[idAlterar] = NovoLivro();
                        Console.Write("Alteração feita com sucesso, voltando ao menu");
                        CounterToMenu();
                        break;

                    // EXCLUIR LIVROS
                    case "3":
                        Console.Write("Indique o ID do livro a ser excluido: ");
                        int idExcluir = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine($"Nome: {listaLivros[idExcluir].Nome}");
                        Console.WriteLine($"Preço: R${listaLivros[idExcluir].Preco.ToString("F")}");
                        Console.WriteLine($"Número de Páginas: {listaLivros[idExcluir].NumeroDePaginas}");
                        Console.WriteLine($"Data de Lançamento: {listaLivros[idExcluir].LaunchDate}");
                        Console.WriteLine($"Pontuação: {listaLivros[idExcluir].ScoreRating}");
                        bool continua2 = true;
                        do
                        {
                            Console.WriteLine("Prosseguir com a exclusão desse registro? S/N");
                            string x = Console.ReadLine();
                            if (x == "s" || x == "S")
                            {
                                listaLivros.RemoveAt(idExcluir);
                                continua2 = false;
                                Console.Write("Exclusão feita com sucesso, voltando ao menu");
                                CounterToMenu();
                            }
                            else if (x == "n" || x == "N")
                            {
                                Console.Write("Voltando ao menu");
                                CounterToMenu();
                                break;
                            }
                            else
                                Console.WriteLine("Comando Inválido");

                        } while (continua2);
                        break;
                    // LISTAR TODOS LIVROS
                    case "4":
                        int cont = 0;
                        foreach (Livros livros in listaLivros)
                        {

                            Console.WriteLine($"ID: {cont}, {livros.Nome}, " +
                                              $"R${livros.Preco.ToString("F")}, " +
                                              $"{livros.NumeroDePaginas} páginas, " +
                                              $"Lançado dia: {livros.LaunchDate}, " +
                                              $"Score: {livros.ScoreRating}");
                            cont++;
                        }
                        Console.WriteLine("Tecle algo para continuar");
                        Console.ReadKey();
                        break;

                    // PESQUISAR LIVROS
                    case "5":
                        Console.WriteLine("Pesquisar Livro - por qual campo deseja procurar seu livro?");
                        Console.WriteLine("1 - ID");
                        Console.WriteLine("2 - Nome");
                        Console.WriteLine("3 - Preço");
                        Console.WriteLine("4 - Número de Páginas");
                        Console.WriteLine("Digite a sua opção: ");
                        String opc2 = Console.ReadLine();
                        switch (opc2)
                        {
                            // PESQUISAR LIVROS POR ID
                            case "1":
                                Console.WriteLine("Digite o ID:");
                                int idProcurarLivros = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine($"Nome: {listaLivros[idProcurarLivros].Nome}");
                                Console.WriteLine($"Preço: R${listaLivros[idProcurarLivros].Preco.ToString("F")}");
                                Console.WriteLine($"Número de Páginas: {listaLivros[idProcurarLivros].NumeroDePaginas}");
                                Console.WriteLine($"Data de Lañçamento: R${listaLivros[idProcurarLivros].LaunchDate}");
                                Console.WriteLine($"Número de Páginas: {listaLivros[idProcurarLivros].ScoreRating.ToString()}");
                                Console.WriteLine("Tecle algo para continuar");
                                Console.ReadKey();
                                break;

                            // PESQUISAR LIVROS POR NOME
                            case "2":
                                Console.WriteLine("Digite o Nome:");
                                String nomeProcurarLivros = Console.ReadLine();

                                Livros aux1 = new Livros();

                                aux1 = listaLivros.Find(x => x.Nome == nomeProcurarLivros);
                                Console.WriteLine($"Nome: {aux1.Nome}");
                                Console.WriteLine($"Preço: R${aux1.Preco.ToString("F")}");
                                Console.WriteLine($"Número de Páginas: {aux1.NumeroDePaginas}");
                                Console.WriteLine($"Data de Lançamento: R${aux1.LaunchDate}");
                                Console.WriteLine($"Pontuação: {aux1.ScoreRating.ToString()}");
                                Console.WriteLine("Tecle algo para continuar");
                                Console.ReadKey();

                                break;

                            // PESQUISAR LIVROS POR PRECO
                            case "3":
                                Console.WriteLine("Digite o Preço:");
                                double precoProcurarLivros = Convert.ToDouble(Console.ReadLine());

                                Livros aux2 = new Livros();

                                aux2 = listaLivros.Find(x => x.Preco == precoProcurarLivros);
                                Console.WriteLine($"Nome: {aux2.Nome}");
                                Console.WriteLine($"Preço: R${aux2.Preco.ToString("F")}");
                                Console.WriteLine($"Número de Páginas: {aux2.NumeroDePaginas}");
                                Console.WriteLine($"Data de Lançamento: R${aux2.LaunchDate}");
                                Console.WriteLine($"Pontuação: {aux2.ScoreRating.ToString()}");
                                Console.WriteLine("Tecle algo para continuar");
                                Console.ReadKey();
                                break;

                            // PESQUISAR LIVROS POR NUMERO DE PAGINAS
                            case "4":
                                Console.WriteLine("Digite o Número de Páginas:");
                                int paginasProcurarLivros = Convert.ToInt32(Console.ReadLine());

                                Livros aux3 = new Livros();

                                aux3 = listaLivros.Find(x => x.NumeroDePaginas == paginasProcurarLivros);
                                Console.WriteLine($"Nome: {aux3.Nome}");
                                Console.WriteLine($"Preço: R${aux3.Preco.ToString("F")}");
                                Console.WriteLine($"Número de Páginas: {aux3.NumeroDePaginas}");
                                Console.WriteLine($"Data de Lançamento: R${aux3.LaunchDate}");
                                Console.WriteLine($"Pontuação: {aux3.ScoreRating.ToString()}");
                                Console.WriteLine("Tecle algo para continuar");
                                Console.ReadKey();
                                break;

                            default:
                                Console.WriteLine("Comando Invalido");
                                break;
                        }
                        break;

                    //EXPORTANDO PARA ARQUIVO JSON
                    case "6":

                        var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(listaLivros);
                        System.IO.File.WriteAllText(@"H:\lista.json", jsonString); //TENTAR FAZER CAMINHO N FIXADO MAIS TARDE
                        Console.WriteLine("Arquivo exportado com sucesso");
                        CounterToMenu();

                        break;

                    //IMPORTANDO PARA ARQUIVO JSON
                    case "7":

                        using (StreamReader r = new StreamReader(@"H:\lista.json")) //TENTAR FAZER CAMINHO N FIXADO MAIS TARDE
                        {
                            string json = r.ReadToEnd();
                            listaLivros = JsonConvert.DeserializeObject<List<Livros>>(json);
                        }
                        break;

                    case "9":

                        Console.WriteLine("Saindo");
                        CounterToMenu();
                        continua = false;
                        break;

                    default:
                        Console.WriteLine("Comando Invalido");
                        System.Threading.Thread.Sleep(500);
                        break;
                }

            } while (continua);

        }

        private static Livros NovoLivro()
        {
            Livros livro = new Livros();

            Console.WriteLine("Cadastro de Livro");
            Console.Write("Nome: ");
            livro.Nome = Console.ReadLine();
            Console.Write("Preço: ");
            livro.Preco = Convert.ToDouble(Console.ReadLine());
            Console.Write("Número de Páginas: ");
            livro.NumeroDePaginas = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Lançamento");
            Console.Write("Dia: ");
            int launchDay = Convert.ToInt32((Console.ReadLine()));
            Console.Write("Mês: ");
            int launchMonth = Convert.ToInt32((Console.ReadLine()));
            Console.Write("Ano: ");
            int launchYear = Convert.ToInt32((Console.ReadLine()));
            if (launchDay > 0 && launchDay <= 31 && launchMonth > 0 && launchMonth <= 12 && launchYear <= 2019)
            {
                livro.LaunchDate = ($"{launchDay}/{launchMonth}/{launchYear}");
            }
            else
            {
                Console.WriteLine("Data inválida, subindo como 0/0/0");
                livro.LaunchDate = ($"0/0/0");
            }
                
            Console.Write("Pontuação(0 à 10): ");
            float scoreaux = float.Parse(Console.ReadLine());
            if (scoreaux >= 0 && scoreaux <= 10)
            {
                livro.ScoreRating = scoreaux;
            }
            else
            {
                Console.WriteLine("Nota Inválida, subindo como 0");
                livro.ScoreRating = 0;
            }

            return livro;
        }
        private static void CounterToMenu()
        {
            System.Threading.Thread.Sleep(500);
            Console.Write(" . ");
            System.Threading.Thread.Sleep(500);
            Console.Write(" . ");
            System.Threading.Thread.Sleep(500);
            Console.Write(" . ");
            System.Threading.Thread.Sleep(500);
        }
    }
}
