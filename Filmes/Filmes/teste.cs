using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmes
{
    internal class teste
    {
        //atributos
        private string _placa;
        private string _modelo;
        private int _ano;
        private double _valor;

        //propriedades
        public string Placa { get => _placa; set => _placa = value; }
        public string Modelo { get => _modelo; set => _modelo = value; }
        public int Ano { get => _ano; set => _ano = value; }
        public double Valor { get => _valor; set => _valor = value; }

        //construtor
        public teste(string placa, string modelo, int ano, double valor)
        {
            Placa = placa;
            Modelo = modelo;
            Ano = ano;
            Valor = valor;
        }

        //inicializa valores
        public teste()
        {
            Placa = "";
            Modelo = "";
            Ano = 0;
            Valor = 0.0;
        }
    }
}
