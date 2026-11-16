using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmes
{
    internal class FilmeController
    {
        private List<FilmeModel> _colecaoFilmes;
        private FilmeView _filmeView;
        private FilmeModel _filmeModel;
        private int _posicao;


        public FilmeController()
        {
            _filmeModel = new FilmeModel();
            _filmeView = new FilmeView();
            _colecaoFilmes = new List<FilmeModel>();
            _colecaoFilmes.Add(new FilmeModel("123", "Demolidor", "Irmãos Russo"));

        }

        public bool BuscarCodigo(string codigo)
        {
            bool encontrei = false;
            for (int i = 0; i < _colecaoFilmes.Count; i++)
            {
                if (_colecaoFilmes[i].Codigo == codigo)
                {
                    encontrei = true;
                    _posicao = i;
                    break;
                }
            }
            return encontrei;
        }
        public void ExecutarCRUD()
        {
            FilmeView view = new FilmeView();
            FilmeModel filme = new FilmeModel();
            string resp;
            
            view.MostrarFormulario();

            view.EntrarDados("PK", filme);

            bool achei = BuscarCodigo(filme.Codigo);

            if (!achei)
            {
                resp = view.Perguntar("Cpf nao encontrado, Deseja cadastrar? ");
                if (resp == "S")
                {
                    view.EntrarDados("DT", filme);
                    if (resp == "S")
                    {
                        _colecaoFilmes.Add(filme);
                    }
                }
            }
            else
            {
                view.MostrarDados(_colecaoFilmes[_posicao]);
                resp = view.Perguntar("cod encontrado, deseja alterar/excluir ou voltar?");
                if (resp == "A")
                {
                    view.EntrarDados("DT", filme);
                    resp = view.Perguntar("tem ctz?");
                    if (resp == "S")
                    {
                        _colecaoFilmes[_posicao] = filme;
                    }
                }else if (resp == "E")
                {
                    resp = view.Perguntar("Tem certeza que deseja excluir?");
                    if (resp == "S")
                    {
                        _colecaoFilmes.RemoveAt(_posicao);
                    }
                }
            }
        }
    }
}
