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

## Instalação do MongoDB Localmente

Passos para instalação:
Baixar o MongoDB:

Acesse o site oficial do MongoDB: https://www.mongodb.com/try/download/community.
Escolha sua plataforma (Windows, macOS, Linux).

Faça o download da versão Community Server.
Instalar o MongoDB:

Siga as instruções de instalação de acordo com o sistema operacional escolhido.
No Windows, certifique-se de marcar a opção Install MongoDB as a Service para que o MongoDB seja iniciado automaticamente.
Verificar a Instalação:

Após a instalação, abra o terminal ou prompt de comando e digite o comando:

```sh
mongod --version
```
Isso deve exibir a versão do MongoDB instalada.
Executar o MongoDB Localmente:

No Windows, o MongoDB será iniciado automaticamente como um serviço. No Linux e macOS, você pode iniciar o MongoDB usando o comando:

mongod
Conectar ao MongoDB:

O MongoDB estará rodando na porta padrão 27017. Para conectar ao MongoDB localmente, utilize a string de conexão:
json
Copiar código
```sh
"mongodb://localhost:27017"
```
Configuração no Projeto
Após instalar o MongoDB localmente, configure a string de conexão no arquivo appsettings.json conforme o exemplo abaixo:

```sh
{
  "ConnectionStrings": {
    "MongoDb": "mongodb://localhost:27017"
  }
}
```

## Testes Unitários

Os testes unitários estão localizados no projeto `ContatoApi.Tests`. Eles utilizam o framework **xUnit** e a biblioteca **Moq** para criar mocks dos serviços, garantindo que a lógica do controlador e dos serviços funcione conforme esperado.

### Executando os Testes

Para executar os testes, use o seguinte comando:

```sh
dotnet test
Teste para Verificar se o Contato Não Existe
Teste verifica se o método Get do ContatosController retorna um NotFoundResult quando o contato
não é encontrado.


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

        [Fact]
        public async Task Get_ReturnsNotFound_WhenContatoDoesNotExist()
        {
            // Arrange
            var mockConnectionStringProvider = new Mock<IConnectionStringProvider>();
            mockConnectionStringProvider.Setup(provider => provider.GetConnectionString("MongoDb")).Returns("mongodb://localhost:27017");
            var mockService = new Mock<ContatoService>(mockConnectionStringProvider.Object);
            mockService.Setup(service => service.GetAsync(It.IsAny<string>())).ReturnsAsync((Contato)null);
            var controller = new ContatosController(mockService.Object);

            // Act
            var result = await controller.Get("60c72b2f9b1e8b3f4c8e4d3a");

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }
```

## Contribuição
 - Faça um fork do projeto.
 - Crie uma branch para sua feature.
 - Commit suas mudanças.
 - Faça um push para a branch.
 - Crie um novo Pull Request.
