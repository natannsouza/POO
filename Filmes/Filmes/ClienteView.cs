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

            _colFin = _colFin + _campos[0].Length + 1 + 30;

            _linFin = _linIni + _campos.Count + 1 + 2;

            //imagine como, pula um campo dps do campo + 1 para ficar com letra colado
            _colDados = _colIni + _campos[0].Length + 1;
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

            return cliente;
        }

        // mostra dados: exibir os valores do objeto

        // pergunta: perguntar, ler e retornar a resposta
    }
}
