# POO — Programação Orientada a Objetos

Repositório com os projetos da disciplina de **Programação Orientada a Objetos** da faculdade, desenvolvidos em **C#** como aplicações de console, seguindo o padrão **MVC (Model–View–Controller)**.

## Projetos

### 📚 Biblioteca (código do professor)

Sistema de biblioteca feito em aula, usado como referência para os demais exercícios.

- **Livros** — cadastro com ISBN, título, autor, gênero e páginas.
- **Alunos** — cadastro com matrícula, nome, e-mail e telefone.
- Menu principal com as opções Livros, Alunos, Empréstimos e Relatórios (as duas últimas ainda não implementadas).

### 🎬 Filmes (em desenvolvimento)

Sistema de locadora de filmes (**CineClub**), desenvolvido por mim com base no projeto da Biblioteca, como exercício para a N2.

- **Filmes** — cadastro com código, título e diretor.
- **Clientes** — cadastro com CPF, nome e telefone.
- Planejado: locações (prazo de 3 dias), devoluções e relatórios de filmes locados/em atraso.

Mais detalhes em [`Filmes/Filmes/readme.md`](Filmes/Filmes/readme.md).

## Estrutura (MVC)

Cada entidade é dividida em três classes:

| Camada | Responsabilidade | Exemplo |
|---|---|---|
| **Model** | Guarda os dados (atributos e propriedades) | `LivroModel`, `FilmeModel` |
| **View** | Desenha o formulário no console e lê os dados | `LivroView`, `FilmeView` |
| **Controller** | Controla o CRUD e a lista de registros | `LivroController`, `FilmeController` |

A classe `Tela` cuida da parte visual do console (cores, molduras, menus e textos centralizados) e o `Program.cs` monta o menu principal.

## Como executar

Requisito: [.NET 9 SDK](https://dotnet.microsoft.com/download).

```bash
# Biblioteca
cd Biblioteca
dotnet run

# Filmes
cd Filmes/Filmes
dotnet run
```

> Dica: rode em um terminal com pelo menos 80x25 caracteres, pois as telas usam posições fixas do cursor.

## Conceitos praticados

- Classes, objetos, atributos e propriedades (encapsulamento)
- Construtores com sobrecarga
- Listas (`List<T>`) como coleção em memória
- Separação de responsabilidades com MVC
- Interface em modo texto com `Console.SetCursorPosition`
