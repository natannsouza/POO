using Filmes;
namespace Filmes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tela tela = new Tela(ConsoleColor.Black, ConsoleColor.Green);
            tela.ConfigurarTela();

            FilmeView view = new FilmeView();
            ClienteView clienteView = new ClienteView();
            FilmeController filmeController = new FilmeController();
            ClienteController clienteController = new ClienteController();


            List<string> opcoes = new List<string>();

            opcoes.Add("1 - Filmes         ");
            opcoes.Add("2 - Clientes       ");


            string opcao;

            while (true)
            {
                tela.MontarMoldura(0,0,79,24, "Sistema de locação de filmes");
                opcao = tela.MostrarMenu(opcoes, 2, 2);

                if(opcao == "0")
                {
                    break;
                }else if(opcao == "1")
                {
                    filmeController.ExecutarCRUD();
                }
                else if(opcao == "2")
                {
                    clienteController.ExecutarCRUD();
                }
                else
                {
                    tela.Centralizar("Opção inválida! Acione uma tecla.",
                        1, 78, 23);
                    Console.ReadKey();
                }
            }

            Console.Clear();
            Console.WriteLine("Adeus...");
        }
    }
}