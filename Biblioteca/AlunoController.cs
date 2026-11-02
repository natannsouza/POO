using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    internal class AlunoController
    {
        // Atributos
        private List<AlunoModel> _colecaoAlunos;

        private AlunoModel _aluno;
        private AlunoView _alunoView;

        private int _posicao;
        private int _colIni;
        private int _linFin;


        // Construtor
        public AlunoController()
        {
            this._alunoView = new AlunoView();
            this._aluno = new AlunoModel();

            this._colecaoAlunos = new List<AlunoModel>();

            // Adicionar um aluno para testar a consulta
            this._colecaoAlunos.Add(
                new AlunoModel(
                    "123",
                    "Zé Colmeia",
                    "zecolmeia@gmail.com",
                    "99967-8976"
                )
            );
        }


        // Buscar a matrícula e guardar a posição encontrada
        public bool BuscarCodigo(string matricula)
        {
            bool encontrei = false;

            for (int i = 0; i < this._colecaoAlunos.Count; i++)
            {
                if (this._colecaoAlunos[i].Matricula == matricula)
                {
                    this._posicao = i;
                    encontrei = true;
                    break;
                }
            }

            return encontrei;
        }


        // Executar as operações do cadastro
        public void ExecutarCrud()
        {
            AlunoView view = new AlunoView();
            AlunoModel aluno = new AlunoModel();
            string resp;

            // Mostrar o formulário
            view.MostrarFormulario();

            // Ler a matrícula
            view.EntrarDados("PK", aluno);

            // Buscar a matrícula na coleção
            bool achei = BuscarCodigo(aluno.Matricula);

            // Se não encontrou, oferecer o cadastro
            if (!achei)
            {
                resp = view.Perguntar(
                    "Matricula nao encontrada. Deseja cadastrar (S/N) : "
                );

                if (resp == "S")
                {
                    // Ler os demais dados
                    view.EntrarDados("DT", aluno);

                    // Guardar a resposta da confirmação
                    resp = view.Perguntar(
                        "Confirma o cadastro (S/N) : "
                    );

                    if (resp == "S")
                    {
                        // CREATE: adicionar o aluno à coleção
                        this._colecaoAlunos.Add(aluno);
                    }
                }
            }
            else
            {
                // READ: mostrar os dados do aluno encontrado
                view.MostrarDados(
                    this._colecaoAlunos[this._posicao]
                );

                // Perguntar qual operação realizar
                resp = view.Perguntar(
                    "Deseja alterar/excluir/voltar (A/E/V) : "
                );

                // Se escolheu alterar
                if (resp == "A")
                {
                    // Ler os novos dados
                    view.EntrarDados("DT", aluno);

                    // Confirmar a alteração
                    resp = view.Perguntar(
                        "Confirma a alteracao (S/N) : "
                    );

                    if (resp == "S")
                    {
                        // UPDATE: substituir o aluno da posição encontrada
                        this._colecaoAlunos[this._posicao] = aluno;
                    }
                }

                // Se escolheu excluir
                else if (resp == "E")
                {
                    // Confirmar a exclusão
                    resp = view.Perguntar(
                        "Confirma a exclusao (S/N) : "
                    );

                    if (resp == "S")
                    {
                        // DELETE: remover o aluno da posição encontrada
                        this._colecaoAlunos.RemoveAt(this._posicao);
                    }
                }

                // Se escolheu V, encerrar o método sem alterar a coleção
            }
        }
    }
}