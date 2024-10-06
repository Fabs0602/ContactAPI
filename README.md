# ContatoApi

ContatoApi é uma API que eu fiz para gerenciar contatos, construída com ASP.NET Core e MongoDB.

## Funcionalidades

- Adicionar um novo contato
- Atualizar um contato existente
- Deletar um contato
- Listar todos os contatos
- Obter detalhes de um contato específico

## Tecnologias Utilizadas

- ASP.NET Core
- MongoDB
- MongoDB.Driver
- Newtonsoft.Json

## Estrutura do Projeto

- `Models/Contato.cs`: Define a estrutura do modelo de dados `Contato`.
- `Services/ContatoService.cs`: Contém a lógica de negócios para gerenciar contatos.
- `Controllers/ContatosController.cs`: Controlador que expõe endpoints para operações CRUD.

## Instalação

1. Clone o repositório:

    ```sh
    git clone https://github.com/Fabs0602/ContactAPI.git
    cd ContactAPI
    ```

2. Configure a string de conexão do MongoDB no arquivo `appsettings.json`:

    ```json
    {
      "ConnectionStrings": {
        "MongoDb": "sua_string_de_conexao"
      }
    }
    ```

3. Restaure as dependências e execute o projeto:

    ```sh
    dotnet restore
    dotnet run
    ```

## Endpoints

### Adicionar um Novo Contato

- **URL**: `/api/Contatos`
- **Método**: `POST`
- **Corpo da Requisição**:

    ```json
    {
      "nome": "Nome do Contato",
      "telefone": 123456789,
      "email": "email@exemplo.com"
    }
    ```

### Atualizar um Contato

- **URL**: `/api/Contatos/{id}`
- **Método**: `PUT`
- **Corpo da Requisição**:

    ```json
    {
      "id": "id_do_contato",
      "nome": "Nome Atualizado",
      "telefone": 987654321,
      "email": "email@atualizado.com"
    }
    ```

### Deletar um Contato

- **URL**: `/api/Contatos/{id}`
- **Método**: `DELETE`

### Listar Todos os Contatos

- **URL**: `/api/Contatos`
- **Método**: `GET`

### Obter Detalhes de um Contato

- **URL**: `/api/Contatos/{id}`
- **Método**: `GET`

## Contribuição

1. Faça um fork do projeto.
2. Crie uma branch para sua feature (`git checkout -b feature/nova-feature`).
3. Commit suas mudanças (`git commit -am 'Adiciona nova feature'`).
4. Faça um push para a branch (`git push origin feature/nova-feature`).
5. Crie um novo Pull Request.
