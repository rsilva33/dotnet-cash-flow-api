## Sobre o projeto

Esta **API**, desenvolvida utilizando **.NET 8**, adota os princípios do **Domain-Driven Design (DDD)** para oferecer uma solução estruturada e eficaz no gerenciamento de despesas pessoais. O principal objetivo é permitir que os usuários registrem suas despesas, detalhando informações como título, data e hora, descrição, valor e tipo de pagamento, com os dados sendo armazenados de forma segura em um banco de dados **MySQL**.

A arquitetura da **API** baseia-se em **REST**, utilizando métodos **HTTP** padrão para uma comunicação eficiente e simplificada. Além disso, é complementada por uma documentação **Swagger**, que proporciona uma interface gráfica interativa para que os desenvolvedores possam explorar e testar os endpoints de maneira fácil.

Dentre os pacotes NuGet utilizados, o **AutoMapper** é o responsável pelo mapeamento entre objetos de domínio e requisição/resposta, reduzindo a necessidade de código repetitivo e manual. O **FluentAssertions** é utilizado nos testes de unidade para tornar as verificações mais legíveis, ajudando a escrever testes claros e compreensíveis. Para as validações, o **FluentValidation** é usado para implementar regras de validação de forma simples e intuitiva nas classes de requisições, mantendo o código limpo e fácil de manter. Por fim, o **EntityFramework** atua como um ORM (Object-Relational Mapper) que simplifica as interações com o banco de dados, permitindo o uso de objetos .NET para manipular dados diretamente, sem a necessidade de lidar com consultas SQL.

![hero-image]

### Features

- **Domain-Driven Design (DDD)**: Estrutura modular que facilita o entendimento e a manutenção do domínio da aplicação.
- **Testes de Unidade**: Testes abrangentes com FluentAssertions para garantir a funcionalidade e a qualidade.
- **Geração de Relatórios**: Capacidade de exportar relatórios detalhados para **PDF e Excel**, oferecendo uma análise visual e eficaz das despesas.
- **RESTful API com Documentação Swagger**: Interface documentada que facilita a integração e o teste por parte dos desenvolvedores.

### Construído com

![badge-dot-net]
![badge-windows]
![badge-visual-studio]
![badge-mysql]
![badge-swagger]

## Getting Started

Para obter uma cópia local funcionando, siga estes passos simples.

### Requisitos

* Visual Studio versão 2022+ ou Visual Studio Code
* Windows 10+ ou Linux/MacOS com [.NET SDK][dot-net-sdk] instalado
* MySql Server

### Instalação

1. Clone o repositório:
    ```sh
    git clone https://github.com/rsilva33/dotnet-cash-flow-api.git
    ```

2. Preencha as informações no arquivo `appsettings.Development.json`.
3. Execute a API e aproveite o seu teste :)



<!-- Links -->
[dot-net-sdk]: https://dotnet.microsoft.com/en-us/download/dotnet/8.0

<!-- Images -->
[hero-image]: images/heroimage.png

<!-- Badges -->
[badge-dot-net]: https://img.shields.io/badge/.NET-512BD4?logo=dotnet&logoColor=fff&style=for-the-badge
[badge-windows]: https://img.shields.io/badge/Windows-0078D4?logo=windows&logoColor=fff&style=for-the-badge
[badge-visual-studio]: https://img.shields.io/badge/Visual%20Studio-5C2D91?logo=visualstudio&logoColor=fff&style=for-the-badge
[badge-mysql]: https://img.shields.io/badge/MySQL-4479A1?logo=mysql&logoColor=fff&style=for-the-badge
[badge-swagger]: https://img.shields.io/badge/Swagger-85EA2D?logo=swagger&logoColor=000&style=for-the-badge


A gente tem três formas.

17:21
A gente pode enviar dados no body da request, no corpo da requisição.

17:26.440000000000055
Segunda forma, a gente pode enviar dados como query parameter, que é o que a gente está

17:31.960000000000036
fazendo aqui agora, que eu acabei de trocar, ou seja, enviar dados na URL.

17:37.72000000000003
E terceira e última opção, a gente pode enviar dados nos headers.

17:43.3599999999999
Como que eu vou saber qual dessas opções escolher?

17:46.960000000000036
É bem simples.

17:48.200000000000045
Olha a frase que você vai memorizar e vai lembrar aí.

17:52.27999999999997
Se os dados que você estiver enviando vão alterar o resultado, então você vai escolher

17:59.559999999999945
enviar esses dados, ou no corpo da requisição, ou como query parameter.

18:6.119999999999891
Se os dados que você estiver enviando para a requisição não forem alterar o resultado,

18:13.599999999999909
então você vai estar enviando esses dados no header.

18:17.799999999999955
Simples assim.

18:18.839999999999918
Aqui, então, eu escolhi estar utilizando como query parameter, porque a gente tem um

18:25.799999999999955
dado para ser enviado, apenas a data.

18:29.079999999999927
Caso fossem muitos dados, aí sim eu precisaria trocar isso aqui.

18:34.319999999999936
Ao invés de GET, deveria ser um PUT ou um POST, porque GET não aceita um corpo na requisição,

18:43.039999999999964
então sim, eu precisaria trocar para colocar um corpo nessa request.

18:48.799999999999955
Só que aqui é somente um dado que eu estou esperando, então não tem problema a gente

18:54
enviar ali como query parameter
