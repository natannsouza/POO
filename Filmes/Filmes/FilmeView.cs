using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmes
{
    internal class FilmeView
    {
        //atributos
        private int _colIni, _linIni, _colFin, _linFin, _colDados, _linDados;
        private List<string> _campos;
        
        //contrutor
        public FilmeView()
        {
            _campos = new List<string>();
            
            _campos.Add("Codigo:      ");
            _campos.Add("Titulo:      ");
            _campos.Add("Diretor:     ");


            _colIni = 18;
            _linIni = 4;

            _colFin = _colIni + _campos[0].Length + 1 + 30;
            _linFin = _linIni + _campos.Count + 1 + 2;

            _colDados = _colIni + _campos[0].Length + 1;
            _linDados = _linIni + 2;
        }

        public void MostrarFormulario()
        {
            Tela t = new Tela();
            t.MontarMoldura(_colIni, _linIni, _colFin, _linFin, "Cadastro de filme");

            int linha = _linDados;
            for (int i = 0; i < _campos.Count; i++)
            {
                Console.SetCursorPosition(_colDados + 1, linha);
                Console.Write(_campos[i]);
                linha++;
            }
        }

        public FilmeModel EntrarDados(string qual, FilmeModel filme)
        {
            if (qual == "PK")
            {
                Console.SetCursorPosition(_colDados, _linDados + 1);
                filme.Codigo = Console.ReadLine();
            }else if (qual == "DT")
            {
                Tela t = new Tela();
                t.LimparArea(_colIni, _linIni+1, _colFin-1 , _linFin-2);
                Console.SetCursorPosition(_colDados, _linDados + 1);
                filme.Titulo = Console.ReadLine();
                
                Console.SetCursorPosition(_colDados, _linDados + 2);
                filme.Diretor = Console.ReadLine();
            }

            return filme;
        }

        public void MostrarDados(FilmeModel filme)
        {
            Console.SetCursorPosition(_colDados, _linDados + 1);
            Console.Write(filme.Codigo);
            
            Console.SetCursorPosition(_colDados, _linDados + 2);
            Console.Write(filme.Titulo);
            
            Console.SetCursorPosition(_colDados, _linDados + 3);
            Console.Write(filme.Diretor);
        }

        public string Perguntar(string pergunta)
        {
            string respota = "";
            
            Console.SetCursorPosition(_colIni +1, _linFin -1);
            
            Console.Write(pergunta);

            respota = Console.ReadLine();
            return respota;
        }
    }
}
