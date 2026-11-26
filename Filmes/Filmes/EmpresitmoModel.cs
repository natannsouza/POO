using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmes
{
    internal class EmprestimoModel
    {
        //atributos
        private int _numero;
        private string _isbn;
        private string _matricula;
        private DateTime _dataEmprestimo;
        private DateTime _dataDevolucaoPrevista;
        private DateTime _dataDevolucaoEfetiva;
        private string _situacao;

        //propriedades7
        public int Numero
        {
            get => _numero;
            set => _numero = value;
        }

        public string Isbn
        {
            get => _isbn;
            set => _isbn = value;
        }

        public string Matricula
        {
            get => _matricula;
            set => _matricula = value;
        }

        public DateTime DataEmprestimo
        {
            get => _dataEmprestimo;
            set => _dataEmprestimo = value;
        }

        public DateTime DataDevolucaoPrevista
        {
            get => _dataDevolucaoPrevista;
            set => _dataDevolucaoPrevista = value;
        }

        public DateTime DataDevolucaoEfetiva
        {
            get => _dataDevolucaoEfetiva;
            set => _dataDevolucaoPrevista = value;
        }

        public string Situacao
        {
            get => _situacao;
            set => _situacao = value;
        }


        //construtor
        public EmprestimoModel(int numero, string isbn, string matricula, DateTime dataEmprestimo, DateTime dataDevolucaoPrevista, DateTime dataDevolucaoEfetiva, string situacao)
        {
            Numero = numero;
            Isbn = isbn;
            Matricula = matricula;
            DataEmprestimo = dataEmprestimo;
            DataDevolucaoPrevista = dataDevolucaoPrevista;
            DataDevolucaoEfetiva = dataDevolucaoEfetiva;
            Situacao = situacao;
        }


        //construtor vazio
        public EmprestimoModel()
        {
            Numero = 0;
            Isbn = "";
            Matricula = "";
            //MinValue indica nao devolvido
            DataEmprestimo = DateTime.MinValue;
            DataDevolucaoPrevista = DateTime.MinValue;
            DataDevolucaoEfetiva = DateTime.MinValue;
            Situacao = "";
        }
    }
};