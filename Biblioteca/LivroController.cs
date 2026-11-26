using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    internal class LivroController
    {
        // atributos
        private List<LivroModel> _colecaoLivros;
        private int _posicao;


        // construtor
        public LivroController()
        {
            this._colecaoLivros = new List<LivroModel>();
            // adiciona 1 livro na coleção para testarmos a consulta posteriormente
            this._colecaoLivros.Add(
                new LivroModel("123", "Faca", "Jo Nesbo", "Policial", 450)
            );
        }


        private bool Buscar(string isbn)
        {
            bool encontrei = false;

            for (int i = 0; i < this._colecaoLivros.Count; i++)
            {
                if (this._colecaoLivros[i].Isbn == isbn)
                {
                    this._posicao = i;
                    encontrei = true;
                    break;
                }
            }

            return encontrei;
        }


        public void ExecutarCRUD()
        {
            LivroView view = new LivroView();
            LivroModel livro = new LivroModel();
            string resp;
            view.MostrarFormulario();

            // pergunta o código
            view.EntrarDados("PK", livro);

            // busca pelo código
            bool achei = this.Buscar(livro.Isbn);

            // se o código NÃO FOI encontrado
            if (!achei)
            {
                // informa que NÃO EXISTE e pergunta se deseja cadastrar
                resp = view.Perguntar("ISBN não encontrado! Deseja cadastrar (S/N) : ");

                // se SIM
                if (resp.ToLower() == "s")
                {
                    // pergunta demais dados
                    view.EntrarDados("DT", livro);

                    // pergunta se confirma o cadastro
                    resp = view.Perguntar("Confirma cadastro (S/N) : ");

                    // se SIM
                    if (resp.ToLower() == "s")
                    {
                        // adiciona o novo registro
                        this._colecaoLivros.Add(livro);
                    }
                }
            }
            // se o codigo FOI encontrado
            else
            {
                // mostra os dados do registro encontrado
                view.MostrarDados(this._colecaoLivros[this._posicao]);

                // pergunta se deseja alterar/excluir/voltar
                resp = view.Perguntar("Deseja alterar/excluir/voltar (A/E/V) : ");

                // se deseja ALTERAR
                if (resp.ToLower() == "a")
                {
                    // pergunta os novos dados
                    view.EntrarDados("DT", livro);

                    // pergunta se confirma alteração
                    resp = view.Perguntar("Confirma alteração (S/N) : ");

                    // se SIM
                    if (resp.ToLower() == "s")
                    {
                        // atualiza dos dados do registro
                        this._colecaoLivros[this._posicao] = livro;

                        // ou...
                        // this._colecaoLivros[this._posicao].Titulo = livro.Titulo;
                        // this._colecaoLivros[this._posicao].Autor = livro.Autor;
                        // this._colecaoLivros[this._posicao].Genero = livro.Genero;
                        // this._colecaoLivros[this._posicao].Paginas = livro.Paginas;
                    }
                }

                // se deseja EXCLUIR
                if (resp.ToLower() == "e")
                {
                    // pergunta se confirma exclusão
                    resp = view.Perguntar("Confirma exclusão (S/N) : ");

                    // se SIM
                    if (resp.ToLower() == "s")
                    {
                        // exclui o registro
                        this._colecaoLivros.RemoveAt(this._posicao);
                    }
                }
            }
        }
    }
}
