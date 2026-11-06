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
        private List<ClienteModel>_colecaoCliente;
        private ClienteModel _cliente;
        private ClienteView _clienteView;

        private int _posicao, _colIni, _linFin;
        //construtor 
        public ClienteController()
        {
            _cliente = new ClienteModel();
            _clienteView = new ClienteView();
            _colecaoCliente = new List<ClienteModel>();

            _colecaoCliente.Add(new ClienteModel("133", "Vk Mac", "3454-5478"));

        }

        public bool BuscarCodigo(string cpf)
        {
            bool encontrei = false;
            for (int i = 0; i < _colecaoCliente.Count; i++)
            {
                if (cpf == _colecaoCliente[i].Cpf)
                {
                    _posicao = i;
                    encontrei = true;
                    break;
                }
            }
            return encontrei;
        }

        public void ExecutarCRUD()
        {
            ClienteView view = new ClienteView();
            ClienteModel cliente = new ClienteModel();
            string resp;

            view.MostrarFormulario();

            view.EntrarDados("PK", cliente);

            bool achei = BuscarCodigo(cliente.Cpf);

            if (!achei)
            {
                resp = view.Perguntar("Cpf nao encontrado. Deseja Cadastrar? S/N");
                if (resp == "S")
                {
                    //add
                    view.EntrarDados("DT", cliente);

                    resp = view.Perguntar("Tem certeza que deseja salvar? (S/N)");
                    
                    if (resp == "S")
                    {
                        _colecaoCliente.Add(cliente);
                    }
                }
            }
            else
            {
                //read
                view.MostrarDados(_colecaoCliente[_posicao]);

                resp = view.Perguntar("Deseja altera/excluir ou voltar? (A/E/V)");


                if(resp  == "A")
                {
                    //update
                    view.EntrarDados("DT", cliente);

                   resp = view.Perguntar("Tem certeza que deseja alterar? (S/N)");

                    if(resp == "S")
                    {
                        _colecaoCliente[_posicao] = cliente;
                    }
                }
                else if (resp == "E")
                {
                    //delete
                   resp = view.Perguntar("Tem certeza que deseja excluir? (S/N)");

                    if(resp == "S")
                    {
                        _colecaoCliente.RemoveAt(_posicao);
                    }
                }
            }
        }
    }
}
