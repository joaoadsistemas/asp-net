# DSCommerce API

A DSCommerce API é um sistema de comércio eletrônico que oferece funcionalidades relacionadas a usuários, produtos, pedidos, pagamentos e categorias. A API é construída usando ASP.NET Core e Entity Framework Core para interação com o banco de dados.

![Captura de tela 2024-01-28 144717](https://github.com/joaoadsistemas/asp-net/assets/121246045/fa405c4d-fac9-4c8a-8c91-0162d5056dcc)


## Configuração

### Pré-requisitos

Antes de executar a aplicação, certifique-se de ter os seguintes pré-requisitos instalados:

- [ASP.NET Core SDK](https://dotnet.microsoft.com/download)
- [Microsoft SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (ou outro banco de dados compatível)

### Configuração do Banco de Dados

1. Abra o arquivo `appsettings.json` e ajuste a string de conexão do banco de dados:

```json
"ConnectionStrings": {
  "DefaultConnection": "sua-string-de-conexao-aqui"
}
```

2. Abra o terminal na pasta do projeto e execute as migrações para criar o banco de dados:

```bash
dotnet ef database update
```

### Executando a Aplicação

No terminal, navegue até a pasta do projeto e execute:

```bash
dotnet run
```

A API estará disponível em `https://localhost:5001` (ou outra porta, dependendo da configuração).

## Endpoints da API

A API oferece os seguintes endpoints:

- **Categorias**
  - `GET /api/categories`: Retorna todas as categorias.
  - `GET /api/categories/{id}`: Retorna uma categoria específica por ID.
  - `POST /api/categories`: Adiciona uma nova categoria.
  - `PUT /api/categories/{id}`: Atualiza uma categoria existente por ID.
  - `DELETE /api/categories/{id}`: Exclui uma categoria por ID.

- **Usuários**
  - `GET /api/users`: Retorna todos os usuários.
  - `GET /api/users/{id}`: Retorna um usuário específico por ID.
  - `POST /api/users`: Adiciona um novo usuário.
  - `PUT /api/users/{id}`: Atualiza um usuário existente por ID.
  - `DELETE /api/users/{id}`: Exclui um usuário por ID.

- **Produtos**
  - `GET /api/products`: Retorna todos os produtos.
  - `GET /api/products/{id}`: Retorna um produto específico por ID.
  - `POST /api/products`: Adiciona um novo produto.
  - `PUT /api/products/{id}`: Atualiza um produto existente por ID.
  - `DELETE /api/products/{id}`: Exclui um produto por ID.

- **Pedidos**
  - `GET /api/orders`: Retorna todos os pedidos.
  - `GET /api/orders/{id}`: Retorna um pedido específico por ID.
  - `POST /api/orders`: Adiciona um novo pedido.
  - `PUT /api/orders/{id}`: Atualiza um pedido existente por ID.
  - `DELETE /api/orders/{id}`: Exclui um pedido por ID.

- **Pagamentos**
  - `GET /api/payments`: Retorna todos os pagamentos.
  - `GET /api/payments/{id}`: Retorna um pagamento específico por ID.
  - `POST /api/payments`: Adiciona um novo pagamento.
  - `PUT /api/payments/{id}`: Atualiza um pagamento existente por ID.
  - `DELETE /api/payments/{id}`: Exclui um pagamento por ID.

Consulte a documentação do Swagger em `https://localhost:5001/swagger` para obter detalhes adicionais sobre os endpoints e seus parâmetros.
![image](https://github.com/joaoadsistemas/asp-net/assets/121246045/aba70ce7-fa6b-45b3-9fab-93ef8dc397fe)



## Tecnologias Utilizadas

- ASP.NET Core
- Entity Framework Core
- Microsoft SQL Server
- Swagger (OpenAPI)

## Autor

João Silveira

