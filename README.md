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

#### Projeto de API

- **Endpoints:** Define os pontos de entrada da aplicação, onde as requisições externas são recebidas e processadas, direcionando-as para os casos de uso adequados.

#### Projeto de Aplicação

- **Regras de Negócio e Validações:** Contém toda a lógica de negócio e as validações específicas da aplicação.
- **Casos de Uso:** Representa as operações centrais da aplicação, organizando as regras e passos necessários para realizar cada funcionalidade principal.

#### Projeto de Comunicação

- **Classes de Request e Response:** Contém as classes que definem a estrutura de requisições e respostas, garantindo que os dados enviados e recebidos estejam no formato correto para a API.

#### Projeto de Exceção

- **Exceções Customizadas:** Define exceções específicas para o projeto, permitindo o tratamento de erros de maneira controlada e personalizada.

#### Projeto de Domínio

- **Interfaces e Contratos:** Define os contratos e interfaces que descrevem as operações essenciais do domínio, servindo como uma ponte entre as diferentes camadas.
- **Entidades:** Representa os objetos de domínio fundamentais, com suas propriedades e comportamentos específicos, encapsulando as regras de negócio relacionadas.

#### Projeto de Infraestrutura

- **Serviços Externos e Persistência:** Contém as implementações para acesso a serviços externos, como bancos de dados, APIs de terceiros, envio de e-mails e upload de arquivos.

#### Projeto Web

- **Interface de Interação com o Usuário:** Define toda a estrutura de interface e os elementos de front-end que permitem a interação com o usuário final.
- **Handlers para Consumo da API:** Configura os manipuladores necessários para consumir os endpoints da API, integrando a lógica de back-end com a interface de front-end.

![alt text](image.png)

### 🚀 Rodando o Projeto

### Fluxograma

## Backend

## Frontend
