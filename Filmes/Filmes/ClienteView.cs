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
        }

        // mostra formulário: desenhar moldura e rótulos

        // entra dados: ler e preencher o objeto

        // mostra dados: exibir os valores do objeto

        // pergunta: perguntar, ler e retornar a resposta
    }
}
