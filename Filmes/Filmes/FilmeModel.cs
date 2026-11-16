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
        private string _codigo;
        private string _titulo;
        private string _diretor;
   

        //propriedades
       public string Codigo { get => _codigo; set => _codigo = value; }
       public string Titulo { get => _titulo; set => _titulo = value; }
        public string Diretor { get => _diretor; set => _diretor = value; }
      
        //construtor
        public FilmeModel(string codigo, string titulo, string diretor)
        {
            Codigo = codigo;
            Titulo = titulo;
            Diretor = diretor;
        
        }

        public FilmeModel()
        {
            Codigo = "";
            Titulo = "";
            Diretor = "";
          
        }
    }
}
