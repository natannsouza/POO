using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmes
{
    internal class ClienteView
    {
        // atributos: coordenadas e lista de campos
        private int _colIni, _linIni, _colFin, _linFin, _colDados, _linDados;

        private List<string> _campos;

        // construtor: preparar campos e calcular posições
        public ClienteView()
        {
            _campos = new List<string>();

            _campos.Add("Cpf:      ");
            _campos.Add("Nome:     ");
            _campos.Add("Telefone: ");

            //insere valores na moldura
            _colIni = 18;
            _linIni = 4;

            // início + largura do rótulo + 1 + espaço para digitação
            _colFin = _colIni + _campos[0].Length + 1 + 30;
            // início + quantidade de campos + 1 + 2
            _linFin = _linIni + _campos.Count + 1 + 2;

            //imagine como, pula um campo dps do campo + 1 para ficar com letra colado
            // início + largura do rótulo + 1
            _colDados = _colIni + _campos[0].Length + 1;
            // duas linhas abaixo do início da moldura
            _linDados = _linIni + 2;
        }

        // mostra formulário: desenhar moldura e rótulos
        public void MostrarFormulario()
        {
            Tela tela = new Tela();
            tela.MontarMoldura(_colIni, _linIni, _colFin, _linFin, "Cadastrar cliente ");


            int linha = _linDados;
            for(int i=0; i < _campos.Count; i++)
            {
                Console.SetCursorPosition(_colIni + 1, linha);
                Console.Write(_campos[i]);
                linha++;
            }
        }

        // entra dados: ler e preencher o objeto
        public ClienteModel EntrarDados(string qual, ClienteModel cliente)
        {
            if(qual == "PK")
            {
                Console.SetCursorPosition(_colDados, _linDados);
                cliente.Cpf = Console.ReadLine();
            }

            else if(qual == "DT")
            {
                Tela tela = new Tela();

                tela.LimparArea(_colDados, _linDados + 1, _colFin -1, _linFin-2);


                Console.SetCursorPosition(_colDados, _linDados + 1);
                cliente.Nome = Console.ReadLine();

                Console.SetCursorPosition(_colDados, _linDados + 2);
                cliente.Telefone = Console.ReadLine();

            }

            return cliente;
        }

        // mostra dados: exibir os valores do objeto
        public void MostrarDados(ClienteModel cliente)
        {
            Console.SetCursorPosition(_colDados, _linDados + 1);
            Console.Write(cliente.Cpf);

            Console.SetCursorPosition(_colDados, _linDados + 2);
            Console.Write(cliente.Nome);

            Console.SetCursorPosition(_colDados, _linDados + 3);
            Console.Write(cliente.Telefone);
        }

        // pergunta: perguntar, ler e retornar a resposta
        public string Perguntar(string pergunta)
        {
            string resposta = "";

            Console.SetCursorPosition(_colIni + 1, _linFin - 1);

            Console.Write(pergunta);

            resposta = Console.ReadLine();

            return resposta.ToUpper();
        }
    }
}
