# Roteiro de construção — MVC

## Model

1. Atributos.
2. Propriedades.
3. Construtor completo.
4. Construtor vazio.

## View

1. Atributos: coordenadas e lista de campos.
2. Construtor: preparar campos e calcular posições.
3. Mostrar formulário.
4. Entrar dados: PK e DT.
5. Mostrar dados.
6. Perguntar.

## Controller

1. Atributos.
2. Construtor: inicializar objetos e coleção.
3. Buscar código.
4. Executar CRUD.

### 4.1. Preparar a operação

1. Mostrar formulário.
2. Ler PK.
3. Buscar código.

### 4.2. Não encontrou: oferecer cadastro

1. Perguntar se deseja cadastrar.
2. Se sim: ler DT.
3. Confirmar cadastro.
4. Se sim: adicionar à coleção.

### 4.3. Encontrou

1. Mostrar dados.
2. Perguntar A/E/V.
   - A: ler DT, confirmar e substituir na posição encontrada.
   - E: confirmar e remover da posição encontrada.
   - V: voltar sem modificar a coleção.

## Tela

1. Atributos: cores.
2. Construtor sem parâmetros.
3. Construtor com parâmetros.
4. Configurar tela.
5. Limpar área.
6. Montar moldura.
7. Centralizar.
8. Mostrar menu.
