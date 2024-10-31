# CPROD - Sistema de Controle de Produtividade

### Descrição

O CPROD - Sistema de Controle de Produtividade é uma ferramenta voltada para o gerenciamento e controle de atividades e pontuações de produtividade em ambientes públicos. Com o CPROD, é possível cadastrar Mapas de Produtividade, onde o usuário associa seu cargo às atividades desempenhadas, atribuindo descrições e pesos a cada tarefa.

O sistema também realiza o cadastro de setores e usuários, vinculando automaticamente os usuários a seus respectivos setores e cargos. O chefe de cada setor é responsável por assinar as produtividades de seus subordinados e definir o valor à receber, enquanto sua própria produtividade é assinada por ele e pelo chefe do setor superior.

O fluxo de produtividade é simples: o usuário acessa o sistema, seleciona a opção de pontuar produtividade, insere o período e pontua as atividades já associadas ao seu cargo. Após assinar, a produtividade é enviada para o chefe, que informa o percentual à ser recebido pelo usuário e depois assina. Em seguida, a produtividade vai para o Recursos Humanos (Admin), que valida ou devolve para correção, encerrando o processo com a finalização da produtividade validada.

O CPROD facilita o gerenciamento de produtividades com um fluxo claro e eficiente, garantindo a transparência e controle das atividades realizadas por cada usuário.

### 💻 Tecnologias

- C#
- .NET 8
- ASP.NET Web API
- Entity Framework Core
- Fluent Validation
- TiaIdentity
- Blazor
- MudBlazor
- SQL Server

### Estrutura do Projeto

O projeta utiliza dos princípios e práticas do Domain-Driven Design(DDD) de uma maneira melhorada, modelando o software com base no domínio do problema e adicionando duas camadas extras que são as camadas de **Exceção** e **Comunicação**.

##### Projeto de API

- Endpoints

##### Projeto de Aplicação

- Regras de negócio(Validações)
- Casos de uso

##### Projeto de Comunicação

- Classes com propriedades de requisições e respostas para receber e devolver informação (Request e Responses)

##### Projeto de Exceção

- Exceções customizadas

##### Projeto de Domínio

- Interfaces/Contratos
- Entidades

##### Projeto de Infraestrutura

- Tudo que está externo a API (ex: salvar no banco de dados, enviar e-mail, upload de arquivos, etc..)

##### Projeto Web

- Toda a interface de interação com o usuário
- Handlers para consumir o Projeto de API

![alt text](image.png)

### 🚀 Rodando o Projeto

### Fluxograma

## Backend

## Frontend
