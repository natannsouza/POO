using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    internal class EmprestimoView
    {
        // atributos
        private int _colIni, _linIni, _colFin, _linFin, _colDados, _linDados;
        private List<string> _campos;
        private Tela _tela;

        // construtor
        public EmprestimoView()
        {
            this._tela = new Tela();

            this._campos = new List<string>();
            this._campos.Add("Número       :");
            this._campos.Add("ISBN         :");
            this._campos.Add("Título       :");
            this._campos.Add("Matrícula    :");
            this._campos.Add("Aluno        :");
            this._campos.Add("Data Empr.   :");
            this._campos.Add("Devol. Prev. :");
            this._campos.Add("Devol. Efet. :");
            this._campos.Add("Situação     :");

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
                "Cadastro de Empréstimos"
            );


            int linha = this._linDados;
            for (int i = 0; i < this._campos.Count; i++)
            {
                Console.SetCursorPosition(this._colIni + 1, linha);
                Console.Write(this._campos[i]);
                linha++;
            }
        }


        // linhas do formulário (a partir de _linDados):
        // 0 Número | 1 ISBN | 2 Título | 3 Matrícula | 4 Aluno
        // 5 Data Empr. | 6 Devol. Prev. | 7 Devol. Efet. | 8 Situação
        public void EntrarDados(string qual, EmprestimoModel emprestimo)
        {
            if (qual == "PK")
            {
                // pergunta a chave primária (número do empréstimo)
                Console.SetCursorPosition(this._colDados, this._linDados);
                emprestimo.Numero = Convert.ToInt32(Console.ReadLine());
            }
            else if (qual == "ISBN")
            {
                // pergunta o ISBN (a consulta ao livro é feita pelo controller)
                Console.SetCursorPosition(this._colDados, this._linDados + 1);
                emprestimo.Isbn = Console.ReadLine();
            }
            else if (qual == "MATRICULA")
            {
                // pergunta a matrícula (a consulta ao aluno é feita pelo controller)
                Console.SetCursorPosition(this._colDados, this._linDados + 3);
                emprestimo.Matricula = Console.ReadLine();
            }
            else if (qual == "DT")
            {
                // demais dados são preenchidos automaticamente
                emprestimo.DataEmprestimo = DateTime.Today;
                emprestimo.DataDevolucaoPrevista = DateTime.Today.AddDays(15);
                emprestimo.DataDevolucaoEfetiva = DateTime.MinValue;
                emprestimo.Situacao = "A";

                // mostra para o usuário o que foi preenchido automaticamente
                this.MostrarDatasESituacao(emprestimo);
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


        // mostra o título do livro encontrado na consulta ao ISBN
        public void MostrarTitulo(string titulo)
        {
            // evita que um título muito longo ultrapasse a moldura
            if (titulo.Length > 40) titulo = titulo.Substring(0, 40);

            Console.SetCursorPosition(this._colDados, this._linDados + 2);
            Console.Write(titulo);
        }


        // mostra o nome do aluno encontrado na consulta à matrícula
        public void MostrarNome(string nome)
        {
            // evita que um nome muito longo ultrapasse a moldura
            if (nome.Length > 40) nome = nome.Substring(0, 40);

            Console.SetCursorPosition(this._colDados, this._linDados + 4);
            Console.Write(nome);
        }


        public void MostrarDados(EmprestimoModel emprestimo, string titulo, string nome)
        {
            Console.SetCursorPosition(this._colDados, this._linDados + 1);
            Console.Write(emprestimo.Isbn);

            if (titulo != null) this.MostrarTitulo(titulo);

            Console.SetCursorPosition(this._colDados, this._linDados + 3);
            Console.Write(emprestimo.Matricula);

            if (nome != null) this.MostrarNome(nome);

            this.MostrarDatasESituacao(emprestimo);
        }


        // mostra os campos de data e situação (usado no cadastro e na consulta)
        private void MostrarDatasESituacao(EmprestimoModel emprestimo)
        {
            Console.SetCursorPosition(this._colDados, this._linDados + 5);
            Console.Write(emprestimo.DataEmprestimo.ToString("dd/MM/yyyy"));

            Console.SetCursorPosition(this._colDados, this._linDados + 6);
            Console.Write(emprestimo.DataDevolucaoPrevista.ToString("dd/MM/yyyy"));

            // a data efetiva só existe depois que o livro for devolvido
            if (emprestimo.Situacao == "E")
            {
                Console.SetCursorPosition(this._colDados, this._linDados + 7);
                Console.Write(emprestimo.DataDevolucaoEfetiva.ToString("dd/MM/yyyy"));
            }

            Console.SetCursorPosition(this._colDados, this._linDados + 8);
            if (emprestimo.Situacao == "A") Console.Write("A - Ativo");
            else Console.Write("E - Encerrado");
        }


        // ---------- relatório ----------
        // colunas do relatório (dentro da moldura, entre as colunas 1 e 78):
        // Nº 2 | ISBN 7 | Título 21 | Matrícula 42 | Empréstimo 53 | Prev. Devol. 65

        // desenha a moldura e o cabeçalho das colunas
        // retorna a linha onde deve ser escrito o primeiro registro
        public int MostrarCabecalhoRelatorio(string titulo)
        {
            this._tela.MontarMoldura(0, 0, 79, 24, titulo);

            Console.SetCursorPosition(2, 2);
            Console.Write("Nº");
            Console.SetCursorPosition(7, 2);
            Console.Write("ISBN");
            Console.SetCursorPosition(21, 2);
            Console.Write("Título");
            Console.SetCursorPosition(42, 2);
            Console.Write("Matrícula");
            Console.SetCursorPosition(53, 2);
            Console.Write("Empréstimo");
            Console.SetCursorPosition(65, 2);
            Console.Write("Prev. Devol.");

            // linha separadora entre o cabeçalho e os dados
            Console.SetCursorPosition(1, 3);
            Console.Write(new string('─', 78));

            return 4;
        }


        // mostra os dados de um empréstimo em uma linha do relatório
        public void MostrarLinhaRelatorio(EmprestimoModel emprestimo, string titulo, int linha)
        {
            // evita que um título muito longo invada a coluna seguinte
            if (titulo.Length > 20) titulo = titulo.Substring(0, 20);

            Console.SetCursorPosition(2, linha);
            Console.Write(emprestimo.Numero);
            Console.SetCursorPosition(7, linha);
            Console.Write(emprestimo.Isbn);
            Console.SetCursorPosition(21, linha);
            Console.Write(titulo);
            Console.SetCursorPosition(42, linha);
            Console.Write(emprestimo.Matricula);
            Console.SetCursorPosition(53, linha);
            Console.Write(emprestimo.DataEmprestimo.ToString("dd/MM/yyyy"));
            Console.SetCursorPosition(65, linha);
            Console.Write(emprestimo.DataDevolucaoPrevista.ToString("dd/MM/yyyy"));
        }


        // mostra a mensagem de fim do relatório e aguarda o usuário
        public void FinalizarRelatorio()
        {
            this._tela.Centralizar("Fim do relatório. Tecle ENTER.", 1, 78, 23);
            Console.ReadLine();
        }


    }
}
