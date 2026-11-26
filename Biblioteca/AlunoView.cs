using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    internal class AlunoView
    {
        // atributos
        private int _colIni, _linIni, _colFin, _linFin, _colDados, _linDados;
        private List<string> _campos;
        private Tela _tela;

        // construtor
        public AlunoView()
        {
            this._tela = new Tela();

            this._campos = new List<string>();
            this._campos.Add("Matrícula :");
            this._campos.Add("Nome      :");
            this._campos.Add("Email     :");
            this._campos.Add("Telefone  :");

            this._colIni = 22;
            this._linIni = 6;

            this._colFin = _colIni + this._campos[0].Length + 1 + 42;
            // +1 para colocar o traçado vertical direito depois dos 
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
                "Cadastro de Alunos"
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


        public void EntrarDados(string qual, AlunoModel aluno)
        {
            if (qual == "PK")
            {
                // pergunta a chave primária (código)
                Console.SetCursorPosition(this._colDados, this._linDados);
                aluno.Matricula = Console.ReadLine();
            }
            else if (qual == "DT")
            {
                // limpa a área da tela antes de perguntar os dados
                // necessário no momento de alterações
                this._tela.LimparArea(_colDados, _linDados + 1, _colFin - 1, _linDados + 3);

                // pergunta todos os outros dados
                Console.SetCursorPosition(this._colDados, this._linDados+1);
                aluno.Nome = Console.ReadLine();

                Console.SetCursorPosition(this._colDados, this._linDados+2);
                aluno.Email = Console.ReadLine();

                Console.SetCursorPosition(this._colDados, this._linDados+3);
                aluno.Telefone = Console.ReadLine();
            }
        }


        public string Perguntar(string pergunta)
        {
            string resposta = "";

            int coluna = this._colIni + 1;
            int linha = this._linFin - 1;
            string espacos = new string(' ', this._colFin - this._colIni -1 );

            // limpa a area da pergunta
            Console.SetCursorPosition(coluna, linha);
            Console.Write(espacos);

            // faz a pergunta ao usuário
            Console.SetCursorPosition(coluna, linha);
            Console.Write(pergunta);
            resposta = Console.ReadLine();

            return resposta;
        }


        public void MostrarDados(AlunoModel aluno)
        {
            Console.SetCursorPosition(this._colDados, this._linDados + 1);
            Console.Write(aluno.Nome);

            Console.SetCursorPosition(this._colDados, this._linDados + 2);
            Console.Write(aluno.Email);

            Console.SetCursorPosition(this._colDados, this._linDados + 3);
            Console.Write(aluno.Telefone);
        }


        // ---------- relatório ----------
        // colunas do relatório (dentro da moldura, entre as colunas 1 e 78):
        // Matrícula 2 | Nome 13 | Email 39 | Telefone 66

        // desenha a moldura e o cabeçalho das colunas
        // retorna a linha onde deve ser escrito o primeiro registro
        public int MostrarCabecalhoRelatorio(string titulo)
        {
            this._tela.MontarMoldura(0, 0, 79, 24, titulo);

            Console.SetCursorPosition(2, 2);
            Console.Write("Matrícula");
            Console.SetCursorPosition(13, 2);
            Console.Write("Nome");
            Console.SetCursorPosition(39, 2);
            Console.Write("Email");
            Console.SetCursorPosition(66, 2);
            Console.Write("Telefone");

            // linha separadora entre o cabeçalho e os dados
            Console.SetCursorPosition(1, 3);
            Console.Write(new string('─', 78));

            return 4;
        }


        // mostra os dados de um aluno em uma linha do relatório
        public void MostrarLinhaRelatorio(AlunoModel aluno, int linha)
        {
            string nome = aluno.Nome;
            string email = aluno.Email;

            // evita que um texto muito longo invada a coluna seguinte
            if (nome.Length > 25) nome = nome.Substring(0, 25);
            if (email.Length > 26) email = email.Substring(0, 26);

            Console.SetCursorPosition(2, linha);
            Console.Write(aluno.Matricula);
            Console.SetCursorPosition(13, linha);
            Console.Write(nome);
            Console.SetCursorPosition(39, linha);
            Console.Write(email);
            Console.SetCursorPosition(66, linha);
            Console.Write(aluno.Telefone);
        }


        // mostra a mensagem de fim do relatório e aguarda o usuário
        public void FinalizarRelatorio()
        {
            this._tela.Centralizar("Fim do relatório. Tecle ENTER.", 1, 78, 23);
            Console.ReadLine();
        }


    }
}
