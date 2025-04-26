# Aleevia Backend

Uma aplicação backend em .NET 8 construída com princípios de Arquitetura Limpa.

## Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Docker](https://www.docker.com/products/docker-desktop/) (para executar o banco de dados PostGIS)
- IDE de sua preferência

## Configuração do Banco de Dados com Docker

A aplicação requer um banco de dados PostgreSQL com extensão PostGIS, que pode ser executado usando o arquivo docker-compose fornecido:

```bash
docker-compose up -d
```

Este comando iniciará todos os serviços necessários definidos no arquivo docker-compose na raiz do projeto.

## Configuração

### Configuração do Appsettings

A aplicação usa o `appsettings.json` para configuração. Abaixo está um exemplo do ambiente de Desenvolvimento:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=aleeviadb;Username=postgres;Password=sql@123;"
  },
  "Identity": {
    "TokenObtainHelperSettings": {
      "Secret": "My#SecretKey@STR0NG"
    }
  },
  "ApiSettings": {
    "ExpireHour": 720,
    "Issuer": "Aleevia",
    "ValidIn": "https://localhost:7086"
  }
}
```

Modifique a string de conexão de acordo com a configuração do seu banco de dados, se necessário.

## Compilando o Projeto

```bash
dotnet build
```

## Rodar o projeto
```bash
dotnet run --project src/Api/Api.csproj
```

Você também pode especificar o ambiente:

```bash
dotnet run --project src/Api/Api.csproj --environment Development
```

De acordo com o launchSettings.json localizada em src/Api/Properties, a API estará disponível em:  
- <a href='https://localhost:7086'> https://localhost:7086 </a>

A interface Swagger estará disponível em:
- <a href='https://localhost:7086/swagger'> https://localhost:7086/swagger </a>

## Gerenciando Migrações

### Para criar uma nova migração:
```bash
dotnet ef migrations add NomeDaMigracao --project src/Infrastructure --startup-project src/Api --context ApiDbContext
```

### Aplicar migrações ao banco de dados
```bash
dotnet ef database update --project src/Infrastructure --startup-project src/Api --context ApiDbContext
```

### Remover a última migração:
```bash
dotnet ef migrations remove --project src/Infrastructure --startup-project src/Api --context ApiDbContext
```

## Arquitetura do Projeto (Clean Architecture)

O projeto utiliza os princípios de Clean Architecture, organizado nas seguintes camadas:

### Domain
- Núcleo da aplicação com as regras de negócio
- Contém entidades, interfaces, enums e exceções do domínio
- Independente de tecnologias/frameworks
- Representa os conceitos e regras essenciais do negócio
- **Não possui dependências com outras camadas**

### Infrastructure
- Implementa acesso a dados e serviços externos
- Contém repositórios, contexto de banco de dados e migrações
- Implementa as interfaces definidas nas camadas de domínio
- Gerencia persistência e integração com serviços externos
- **Depende apenas da camada de Domain**

### Application
- Implementa casos de uso do sistema
- Contém regras de aplicação, serviços e DTOs
- Orquestra o fluxo de dados entre a camada de apresentação e o domínio
- Define interfaces para acesso a serviços externos
- **Depende das camadas de Domain e Infrastructure**

### Api
- Camada responsável pela interface com o usuário
- Contém controllers, endpoints, middleware e configurações da API
- Gerencia requisições HTTP e respostas
- Ponto de entrada da aplicação
- **Depende da todas as camadas para configuração de Injeçãod e Dependencia. 
Mas a Api deve somente chamada a camada de Application e nunca um serviço e função de outra camada**

### CrossCutting
- Camada responsável por funcionalidades que atravessam todas as outras camadas
- Contém implementações de aspectos transversais como autenticação, logging, cache e injeção de dependência
- Fornece utilitários e serviços auxiliares utilizados por múltiplas camadas
- Implementa configurações e middlewares compartilhados
- **Não implementa regras de negócio diretamente**
- **Pode ser acessada por qualquer camada, mas deve manter baixo acoplamento**

### Fluxo de Dependências
- Domain ← Infrastructure ← Application ← Api
- CrossCutting ↔ (Api, Application, Infrastructure, Domain)

Esta estrutura proporciona:
- Alta coesão e baixo acoplamento
- Testabilidade e manutenção facilitada
- Independência de frameworks e tecnologias
- Escalabilidade e evolução do sistema
- Separação clara de responsabilidades