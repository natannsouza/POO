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
        private ClienteView _clienteView;
        private ClienteModel _clienteModel;
        private List<ClienteModel> _colecaoCliente;


        //constutor
        public ClienteController()
        {
            _clienteView = new ClienteView();
            _clienteModel = new ClienteModel();
            _colecaoCliente = new List<ClienteModel>();

            _colecaoCliente.Add(
                new ClienteModel("111.111.111-89", "Natan de Souza", "3454-6723"));
        }

        public void ExecutarCRUD()
        {
            ClienteView view = new ClienteView();
            ClienteModel cliente = new ClienteModel();
            string resp;


        }
    }
}
