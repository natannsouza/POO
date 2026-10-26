using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmes
{
    internal class ClienteController
    {
        //atributos
        private List<ClienteModel> _colecaoClientes;
        private ClienteModel _cliente;
        private ClienteView _clienteView;
        private int _posicao;

        public ClienteController()
        {
            _clienteView = new ClienteView();
            _cliente = new ClienteModel();
            _colecaoClientes = new List<ClienteModel>();


            _colecaoClientes.Add(new ClienteModel(139.513, "Natan de Souza", 34549087));
        }

        public void ExecutarCRUD()
        {
            _clienteView.MostrarFormulario();
            _clienteView.EntrarDados("PK");
        }
    }
}
