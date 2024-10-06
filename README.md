ContatoApi
Descrição
A ContatoApi é uma API para gerenciar contatos. Ela permite criar, ler, atualizar e deletar contatos armazenados em um banco de dados MongoDB.

Estrutura do Projeto
Models: Contém as classes de modelo, como Contato.
Services: Contém os serviços que encapsulam a lógica de negócios e a interação com o banco de dados.
Controllers: Contém os controladores que expõem os endpoints da API.
Tests: Contém os testes unitários para os controladores e serviços.
Dependências
.NET 8.0
MongoDB.Driver
Moq
xUnit
Configuração
Clone o repositório:

Restaure as dependências:

Configure a string de conexão do MongoDB no arquivo appsettings.json:

Executando a API
Para executar a API, use o comando:

1 vulnerability
A API estará disponível em http://localhost:5000.

Testes
Os testes unitários estão localizados no projeto ContatoApi.Tests. Eles utilizam o framework xUnit e a biblioteca Moq para criar mocks dos serviços.

Executando os Testes
Para executar os testes, use o comando:

Exemplos de Testes
Teste para Verificar se o Contato Não Existe
Este teste verifica se o método Get do ContatosController retorna um NotFoundResult quando o contato não é encontrado.

Teste para Verificar se o Contato Existe
Este teste verifica se o método Get do ContatosController retorna o contato correto quando ele existe.

Contribuição
Se você deseja contribuir com este projeto, por favor, faça um fork do repositório e envie um pull request com suas alterações.
