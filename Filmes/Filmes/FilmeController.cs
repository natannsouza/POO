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


        public FilmeController()
        {
            _filmeModel = new FilmeModel();
            _filmeView = new FilmeView();
            _colecaoFilmes = new List<FilmeModel>();
            _colecaoFilmes.Add(new FilmeModel(123, "Demolidor", "Irmãos Russo", 2018, "Drama"));

        }
        public void ExecutarCRUD()
        {
            
        }
    }
}
