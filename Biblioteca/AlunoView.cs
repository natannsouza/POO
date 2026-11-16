using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    internal class AlunoView
    {
        // 1. ATRIBUTOS: guardar as posições e os rótulos do formulário

        // Coordenadas do início e do fim da moldura e do início dos dados
        private int _colIni, _linIni, _colFin, _linFin, _colDados, _linDados;

        // Lista dos textos que identificam os campos na tela
        private List<string> _campos;


        // 2. CONSTRUTOR: preparar os campos e calcular as posições
        public AlunoView()
        {
            // Criar a lista de rótulos
            this._campos = new List<string>();

            // Adicionar os rótulos na ordem em que aparecerão
            this._campos.Add("Matrícula :");
            this._campos.Add("Nome      :");
            this._campos.Add("Email     :");
            this._campos.Add("Telefone  :");

            // Definir a posição inicial da moldura
            this._colIni = 18;
            this._linIni = 4;

            // Calcular a coluna da borda direita:
            // início + largura do rótulo + 1 + espaço para digitação
            this._colFin = _colIni + this._campos[0].Length + 1 + 30;

            // Calcular a linha da borda inferior:
            // início + quantidade de campos + 1 + 2
            this._linFin = _linIni + this._campos.Count + 1 + 2;

            // Definir a coluna em que os dados serão digitados:
            // início + largura do rótulo + 1
            this._colDados = this._colIni + this._campos[0].Length + 1;

            // Definir a linha do primeiro campo:
            // duas linhas abaixo do início da moldura
            this._linDados = this._linIni + 2;
        }


        // 3. MOSTRAR FORMULÁRIO: desenhar a moldura e os rótulos
        public void MostrarFormulario()
        {
            // Criar o objeto responsável pelo desenho da tela
            Tela tela = new Tela();

            // Montar a moldura usando as posições calculadas e o título
            tela.MontarMoldura(
                this._colIni, this._linIni,
                this._colFin, this._linFin,
                "Cadastro de Alunos"
            );

            // Começar a escrever os rótulos na linha do primeiro campo
            int linha = this._linDados;

            // Percorrer todos os rótulos da lista
            for (int i = 0; i < this._campos.Count; i++)
            {
                // Posicionar o cursor uma coluna depois da borda esquerda
                Console.SetCursorPosition(this._colIni + 1, linha);

                // Escrever o rótulo correspondente à posição atual da lista
                Console.Write(this._campos[i]);

                // Avançar para a próxima linha
                linha++;
            }
        }


        // 4. ENTRAR DADOS: ler os dados e preencher o objeto recebido
        public AlunoModel EntrarDados(string qual, AlunoModel aluno)
        {
            // Se foi solicitada a chave primária, ler apenas a matrícula
            if (qual == "PK")
            {
                // Posicionar o cursor no espaço reservado à matrícula
                Console.SetCursorPosition(this._colDados, this._linDados);

                // Ler a matrícula e armazenar na propriedade do aluno
                aluno.Matricula = Console.ReadLine();
            }

            // Se foram solicitados os demais dados, ler nome, email e telefone
            else if (qual == "DT")
            {
                // Criar o objeto que será usado para limpar a área
                Tela t = new Tela();

                // Limpar a área dos demais dados, sem apagar a matrícula
                t.LimparArea(
                    this._colDados, this._linDados + 1,
                    this._colFin - 1, this._linFin - 2
                );

                // Posicionar na linha do nome, ler e armazenar
                Console.SetCursorPosition(this._colDados, this._linDados + 1);
                aluno.Nome = Console.ReadLine();

                // Posicionar na linha do email, ler e armazenar
                Console.SetCursorPosition(this._colDados, this._linDados + 2);
                aluno.Email = Console.ReadLine();

                // Posicionar na linha do telefone, ler e armazenar
                Console.SetCursorPosition(this._colDados, this._linDados + 3);
                aluno.Telefone = Console.ReadLine();
            }

            // Devolver o objeto aluno após a entrada dos dados
            return aluno;
        }


        // 5. MOSTRAR DADOS: exibir os valores que estão no objeto recebido
        public void MostrarDados(AlunoModel aluno)
        {
            // Posicionar na linha do nome e exibir seu valor
            Console.SetCursorPosition(this._colDados, this._linDados + 1);
            Console.WriteLine(aluno.Nome);

            // Posicionar na linha do email e exibir seu valor
            Console.SetCursorPosition(this._colDados, this._linDados + 2);
            Console.WriteLine(aluno.Email);

            // Posicionar na linha do telefone e exibir seu valor
            Console.SetCursorPosition(this._colDados, this._linDados + 3);
            Console.WriteLine(aluno.Telefone);
        }


        // 6. PERGUNTAR: exibir uma pergunta e devolver a resposta
        public string Perguntar(string pergunta)
        {
            // Preparar a variável que receberá a resposta
            string resposta = "";

            // Posicionar dentro da moldura, na linha anterior à borda inferior
            Console.SetCursorPosition(this._colIni + 1, this._linFin - 1);

            // Exibir a pergunta recebida pelo parâmetro
            Console.Write(pergunta);

            // Ler e guardar a resposta digitada
            resposta = Console.ReadLine();

            // Devolver a resposta convertida para letras maiúsculas
            return resposta.ToUpper();
        }
    }
}
