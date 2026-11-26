using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    internal class LivroView
    {
        // atributos
        private int _colIni, _linIni, _colFin, _linFin, _colDados, _linDados;
        private List<string> _campos;
        private Tela _tela;

        // construtor
        public LivroView()
        {
            this._tela = new Tela();

            this._campos = new List<string>();
            this._campos.Add("ISBN    :");
            this._campos.Add("Título  :");
            this._campos.Add("Autor   :");
            this._campos.Add("Gênero  :");
            this._campos.Add("Páginas :");

            this._colIni = 22;
            this._linIni = 2;

            this._colFin = _colIni + this._campos[0].Length + 1 + 42;
            // +1 para colocar o traçado vertical direito depois dos dados
            // +42 para ter espaço para o usuário digitar os dados

            this._linFin = _linIni + this._campos.Count + 1 + 2;
            // +1 para colocar o traçado horizontal na linha após o último campo
            // +2 para podermos usar um Titulo e um espaço para perguntas

            this._colDados = this._colIni + this._campos[0].Length + 2;
            this._linDados = this._linIni + 2;
        }

        public void MostrarFormulario()
        {

            this._tela.MontarMoldura(
                this._colIni, this._linIni,
                this._colFin, this._linFin,
                "Cadastro de Livros"
            );


            int linha = this._linDados;
            for (int i = 0; i < this._campos.Count; i++)
            {
                Console.SetCursorPosition(this._colIni + 1, linha);
                Console.Write(this._campos[i]);
                linha++;
            }

            // ou podemos usar o comando foreach
            /*
            foreach (string campo in this._campos)
            {
                Console.SetCursorPosition(this._colIni+1, linha);
                Console.Write(campo);
                linha++;
            }
            */
        }


        public void EntrarDados(string qual, LivroModel livro)
        {
            if (qual == "PK")
            {
                // pergunta a chave primária (código)
                Console.SetCursorPosition(this._colDados, this._linDados);
                livro.Isbn = Console.ReadLine();
            }
            else if (qual == "DT")
            {
                // limpa a área da tela antes de perguntar os dados
                // necessário no momento de alterações
                this._tela.LimparArea(_colDados, _linDados + 1, _colFin - 1, _linDados + 4);

                // pergunta todos os outros dados
                Console.SetCursorPosition(this._colDados, this._linDados + 1);
                livro.Titulo = Console.ReadLine();

                Console.SetCursorPosition(this._colDados, this._linDados + 2);
                livro.Autor = Console.ReadLine();

                Console.SetCursorPosition(this._colDados, this._linDados + 3);
                livro.Genero = Console.ReadLine();

                Console.SetCursorPosition(this._colDados, this._linDados + 4);
                livro.Paginas = Convert.ToInt32(Console.ReadLine());
            }
        }


        public string Perguntar(string pergunta)
        {
            string resposta = "";

            int coluna = this._colIni + 1;
            int linha = this._linFin - 1;
            string espacos = new string(' ', this._colFin - this._colIni - 1);

            // limpa a area da pergunta
            Console.SetCursorPosition(coluna, linha);
            Console.Write(espacos);

            // faz a pergunta ao usuário
            Console.SetCursorPosition(coluna, linha);
            Console.Write(pergunta);
            resposta = Console.ReadLine();

            return resposta;
        }


        public void MostrarDados(LivroModel livro)
        {
            Console.SetCursorPosition(this._colDados, this._linDados + 1);
            Console.Write(livro.Titulo);

            Console.SetCursorPosition(this._colDados, this._linDados + 2);
            Console.Write(livro.Autor);

            Console.SetCursorPosition(this._colDados, this._linDados + 3);
            Console.Write(livro.Genero);

            Console.SetCursorPosition(this._colDados, this._linDados + 4);
            Console.Write(livro.Paginas);
        }


        // ---------- relatório ----------
        // colunas do relatório (dentro da moldura, entre as colunas 1 e 78):
        // ISBN 2 | Título 16 | Autor 40 | Gênero 59 | Páginas 71

        // desenha a moldura e o cabeçalho das colunas
        // retorna a linha onde deve ser escrito o primeiro registro
        public int MostrarCabecalhoRelatorio(string titulo)
        {
            this._tela.MontarMoldura(0, 0, 79, 24, titulo);

            Console.SetCursorPosition(2, 2);
            Console.Write("ISBN");
            Console.SetCursorPosition(16, 2);
            Console.Write("Título");
            Console.SetCursorPosition(40, 2);
            Console.Write("Autor");
            Console.SetCursorPosition(59, 2);
            Console.Write("Gênero");
            Console.SetCursorPosition(71, 2);
            Console.Write("Páginas");

            // linha separadora entre o cabeçalho e os dados
            Console.SetCursorPosition(1, 3);
            Console.Write(new string('─', 78));

            return 4;
        }


        // mostra os dados de um livro em uma linha do relatório
        public void MostrarLinhaRelatorio(LivroModel livro, int linha)
        {
            string titulo = livro.Titulo;
            string autor = livro.Autor;
            string genero = livro.Genero;

            // evita que um texto muito longo invada a coluna seguinte
            if (titulo.Length > 23) titulo = titulo.Substring(0, 23);
            if (autor.Length > 18) autor = autor.Substring(0, 18);
            if (genero.Length > 11) genero = genero.Substring(0, 11);

            Console.SetCursorPosition(2, linha);
            Console.Write(livro.Isbn);
            Console.SetCursorPosition(16, linha);
            Console.Write(titulo);
            Console.SetCursorPosition(40, linha);
            Console.Write(autor);
            Console.SetCursorPosition(59, linha);
            Console.Write(genero);
            Console.SetCursorPosition(71, linha);
            Console.Write(livro.Paginas);
        }


        // mostra a mensagem de fim do relatório e aguarda o usuário
        public void FinalizarRelatorio()
        {
            this._tela.Centralizar("Fim do relatório. Tecle ENTER.", 1, 78, 23);
            Console.ReadLine();
        }


    }
}
