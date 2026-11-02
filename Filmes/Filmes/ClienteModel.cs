using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmes
{
    internal class ClienteModel
    {
        //atributos
        private string _cpf;
        private string _nome;
        private int _telefone;

        //propriedades
        public string Cpf { get => _cpf; set => _cpf = value; }
        public string Nome { get => _nome; set => _nome = value; }
        public int Telefone { get => _telefone; set => _telefone = value; }


        //contrutor 
        public ClienteModel(string cpf, string nome, int telefone)
        {
            Cpf = cpf;
            Nome = nome;
            Telefone = telefone;
        }

        public ClienteModel()
        {
            Cpf = "";
            Nome = "";
            Telefone = 0;
        }
    }
}
