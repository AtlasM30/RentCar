# RentCar API

API RESTful para gerenciamento de veículos e sistema de aluguel de carros, desenvolvida em C# com ASP.NET Core e PostgreSQL.

O sistema permite cadastrar, editar, remover, listar e buscar veículos, além de registrar aluguéis e controlar automaticamente a disponibilidade dos veículos.

Também foram implementados diferenciais como autenticação JWT, hash de senha com BCrypt, validações de dados, tratamento global de exceções, restrições de unicidade no banco de dados, transações e documentação com Swagger.

---

## Tecnologias utilizadas

- C#
- .NET 10
- ASP.NET Core Web API
- Entity Framework Core
- PostgreSQL
- Npgsql
- Swagger / OpenAPI
- JWT
- BCrypt
- Visual Studio

---

## Arquitetura

O projeto foi organizado utilizando uma estrutura baseada em Clean Architecture.

RentCarIncludeJr
│
├── RentCarApi
├── RentCar.Application
├── RentCar.Core
├── RentCar.Infrastructure

## RentCarApi

Responsável pela camada de apresentação da aplicação.

Contém:

Controllers
Configuração do Swagger
Configuração do JWT
Middleware global de exceções
Injeção de dependência
Program.cs

## RentCar.Application

Responsável pelos serviços e regras da aplicação.

RentCar.Application
├── DTOs
│   ├── Auth
│   ├── Rental
│   └── Vehicle
│
└── Services
    ├── AuthService
    ├── RentalService
    ├── VehicleService
    └── Interfaces

## RentCar.Core

Contém as entidades e contratos principais do sistema.

RentCar.Core
├── Entities
│   ├── Vehicle
│   ├── Rental
│   └── User
│
├── Repositories
│   ├── IVehicleRepository
│   ├── IRentalRepository
│   └── IUserRepository
│
└── Interfaces
    └── IUnitOfWork

## RentCar.Infrastructure

Responsável pelo acesso a dados e integração com o PostgreSQL.

RentCar.Infrastructure
├── Data
│   └── RentCarDbContext
│
├── Repositories
│   ├── VehicleRepository
│   ├── RentalRepository
│   └── UserRepository
│
├── UnitOfWork
│   └── UnitOfWork
│
└── Migrations

Funcionalidades
Veículos
Cadastrar veículo
Editar veículo
Remover veículo
Listar todos os veículos
Buscar veículo por ID
Buscar veículo por placa
Controlar disponibilidade
Impedir cadastro de placas duplicadas
Aluguéis
Registrar aluguel
Relacionar aluguel com veículo
Registrar nome do cliente
Registrar data inicial e final
Impedir aluguel de veículo indisponível
Validar datas
Alterar automaticamente o veículo para indisponível
Executar aluguel dentro de uma transação
Usuários e autenticação
Cadastro de usuário
Login
Hash de senha com BCrypt
Geração de token JWT
Validação do JWT
Proteção de endpoints com [Authorize]
Impedir nomes de usuário duplicados

## Banco de dados

O projeto utiliza PostgreSQL.

Crie um banco chamado:

RentCarDb

Exemplo de configuração local:

{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=RentCarDb;Username=postgres;Password=SUA_SENHA"
  }
}

Substitua SUA_SENHA pela senha configurada no PostgreSQL.

## Configuração JWT

Exemplo no appsettings.json:

"Jwt": {
  "Key": "SUA_CHAVE_JWT",
  "Issuer": "RentCarApi",
  "Audience": "RentCarClient"
}

## Restrições de unicidade

O banco possui índices únicos para impedir inconsistências.

modelBuilder.Entity<Vehicle>()
    .HasIndex(v => v.placa)
    .IsUnique();

modelBuilder.Entity<User>()
    .HasIndex(u => u.nomeUsuario)
    .IsUnique();

Com isso, o PostgreSQL impede:

dois veículos com a mesma placa;
dois usuários com o mesmo nome de usuário.
Transações

O processo de aluguel utiliza Unit of Work para garantir consistência.

## Fluxo:

Buscar veículo
↓
Verificar se existe
↓
Verificar disponibilidade
↓
Validar datas
↓
Marcar veículo como indisponível
↓
Criar aluguel
↓
Commit

Caso ocorra algum erro:

Erro
↓
Rollback
↓
Nenhuma alteração permanece no banco

Isso evita que um veículo fique indisponível sem um aluguel correspondente.

## Migrations

No Visual Studio, abra:

Ferramentas
→ Gerenciador de Pacotes NuGet
→ Console do Gerenciador de Pacotes

Defina:

Projeto padrão: RentCar.Infrastructure
Projeto de inicialização: RentCarApi

Para criar uma migration:

Add-Migration NomeDaMigration

Para aplicar as migrations:

Update-Database
Como executar o projeto
1. Clone o repositório
git clone URL_DO_REPOSITORIO
2. Abra a solução

Abra o arquivo:

RentCarIncludeJ.sln

no Visual Studio.

3. Configure o PostgreSQL

Crie o banco:

RentCarDb
4. Configure a connection string

Edite o arquivo appsettings.json.

5. Aplique as migrations

No Console do Gerenciador de Pacotes:

Update-Database
6. Defina o projeto inicial

No Visual Studio:

RentCarApi
→ Definir como Projeto de Inicialização
7. Execute a API

Execute utilizando HTTPS.

Endpoints
Autenticação
Cadastrar usuário
POST /api/Auth/register

Exemplo:

{
  "nomeUsuario": "arthur",
  "senha": "123456"
}
Login
POST /api/Auth/login

Exemplo:

{
  "nomeUsuario": "arthur",
  "senha": "123456"
}

Resposta:

{
  "token": "TOKEN_JWT"
}
Veículos
Cadastrar veículo
POST /api/Vehicle

Exemplo:

{
  "marca": "Toyota",
  "modelo": "Corolla",
  "ano": 2024,
  "placa": "ABC1D23",
  "valorDiaria": 180.00
}
Listar veículos
GET /api/Vehicle
Buscar veículo por ID
GET /api/Vehicle/{id}

Exemplo:

GET /api/Vehicle/1
Buscar veículo por placa
GET /api/Vehicle/placa/{placa}

Exemplo:

GET /api/Vehicle/placa/ABC1D23
Editar veículo
PUT /api/Vehicle/{id}
Remover veículo
DELETE /api/Vehicle/{id}
Aluguéis
Registrar aluguel
POST /api/Rental

Exemplo:

{
  "nomeCliente": "Arthur",
  "inicioAluguel": "2026-09-10T08:00:00",
  "fimAluguel": "2026-09-15T18:00:00",
  "vehicleId": 1
}

Ao registrar um aluguel válido, o veículo passa a ficar indisponível.

Listar aluguéis
GET /api/Rental
Buscar aluguel por ID
GET /api/Rental/{id}
Endpoints protegidos

A API utiliza JWT para proteger operações sensíveis.

Exemplos:

POST   /api/Vehicle
PUT    /api/Vehicle/{id}
DELETE /api/Vehicle/{id}
POST   /api/Rental
GET    /api/Rental
GET    /api/Rental/{id}

Os endpoints de autenticação permanecem públicos:

POST /api/Auth/register
POST /api/Auth/login

## Swagger

A documentação da API pode ser acessada durante o desenvolvimento em:

https://localhost:PORTA/swagger

A porta pode variar conforme o launchSettings.json.

Autenticação no Swagger
Execute:
POST /api/Auth/login
Copie o token JWT retornado.
Clique em Authorize.
Cole o token.
Confirme.
Execute os endpoints protegidos.

Sem token válido:

401 Unauthorized
Validações

A API possui validações para impedir dados inválidos.

Entre elas:

marca obrigatória;
modelo obrigatório;
placa obrigatória;
placa única;
valor da diária maior que zero;
ano válido;
nome do cliente obrigatório;
veículo válido;
veículo disponível;
data final posterior à inicial;
nome de usuário obrigatório;
nome de usuário único;
senha obrigatória;
senha com tamanho mínimo.

Requisições inválidas retornam:

400 Bad Request
Tratamento global de exceções

A API possui um middleware global para tratamento de exceções inesperadas.

Exemplo de resposta:

{
  "statusCode": 500,
  "message": "Ocorreu um erro interno no servidor.",
  "detail": "Detalhes do erro"
}
Status HTTP utilizados
200 OK
201 Created
204 No Content
400 Bad Request
401 Unauthorized
404 Not Found
500 Internal Server Error

## Boas práticas implementadas
Clean Architecture
DTOs
Repository Pattern
Dependency Injection
Unit of Work
Transações
Entity Framework Core
Async/Await
JWT
BCrypt
Data Annotations
Middleware global
Índices únicos no banco
Swagger / OpenAPI

## Segurança

As senhas dos usuários não são armazenadas em texto puro.

O sistema utiliza BCrypt para geração e validação do hash das senhas.

## Autor

Arthur Araújo Moreira