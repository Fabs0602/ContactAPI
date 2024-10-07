# ContatoApi

**ContatoApi** é uma API que permite gerenciar contatos, construída com **ASP.NET Core** e **MongoDB**.

## Funcionalidades

- Adicionar um novo contato
- Atualizar um contato existente
- Deletar um contato
- Listar todos os contatos
- Obter detalhes de um contato específico

## Tecnologias Utilizadas

- **ASP.NET Core**
- **MongoDB**
- **MongoDB.Driver**
- **Newtonsoft.Json**

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

## Testes Unitários

Os testes unitários estão localizados no projeto `ContatoApi.Tests`. Eles utilizam o framework **xUnit** e a biblioteca **Moq** para criar mocks dos serviços, garantindo que a lógica do controlador e dos serviços funcione conforme esperado.

### Executando os Testes

Para executar os testes, use o seguinte comando:

```sh
dotnet test
Teste para Verificar se o Contato Não Existe
Este teste verifica se o método Get do ContatosController retorna um NotFoundResult quando o contato
não é encontrado.


Teste para Verificar se o Contato Existe
Descrição: Este teste verifica se o método Get do ContatosController retorna o contato correto quando ele existe no banco de dados. O teste assegura que a API retorna os dados esperados para um contato específico, garantindo que a consulta ao banco de dados funcione corretamente e que os dados retornados estejam completos e corretos.

[Fact]
public async Task Get_ReturnsContato_WhenContatoExists()
{
    // Arrange
    var mockConnectionStringProvider = new Mock<IConnectionStringProvider>();
    mockConnectionStringProvider.Setup(provider => provider.GetConnectionString("MongoDb")).Returns("mongodb://localhost:27017");
    var mockService = new Mock<ContatoService>(mockConnectionStringProvider.Object);
    var contato = new Contato { Id = "60c72b2f9b1e8b3f4c8e4d3a", Nome = "Teste", Telefone = 123456789, Email = "teste@exemplo.com" };
    mockService.Setup(service => service.GetAsync(It.IsAny<string>())).ReturnsAsync(contato);
    var controller = new ContatosController(mockService.Object);

    // Act
    var result = await controller.Get("60c72b2f9b1e8b3f4c8e4d3a");

    // Assert
    var actionResult = Assert.IsType<ActionResult<Contato>>(result);
    var returnValue = Assert.IsType<Contato>(actionResult.Value);
    Assert.Equal(contato.Id, returnValue.Id);
}
```

## Contribuição
 - Faça um fork do projeto.
 - Crie uma branch para sua feature.
 - Commit suas mudanças.
 - Faça um push para a branch.
 - Crie um novo Pull Request.
