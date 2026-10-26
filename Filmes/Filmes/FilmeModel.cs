using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmes
{
    internal class FilmeModel
    {
        //atributos
        private int _codigo;
        private string _titulo;
        private string _diretor;
        private int _ano;
        private string _genero;

        //propriedades
       public int Codigo { get => _codigo; set => _codigo = value; }
       public string Titulo { get => _titulo; set => _titulo = value; }
        public string Diretor { get => _diretor; set => _diretor = value; }
        public int Ano { get => _ano; set => _ano = value; }
        public string Genero { get => _genero; set => _genero = value; }
        //construtor
        public FilmeModel(int codigo, string titulo, string diretor, int ano, string genero)
        {
            Codigo = codigo;
            Titulo = titulo;
            Diretor = diretor;
            Ano = ano;
            Genero = genero;
        }

        public FilmeModel()
        {
            Codigo = 0;
            Titulo = "";
            Diretor = "";
            Ano = 0;
            Genero = "";
        }
    }
}
