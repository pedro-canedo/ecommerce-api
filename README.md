# Arquitetura do projeto Sugerida

![image](https://github.com/pedro-canedo/ecommerce-api/assets/82132100/9a8411e4-578a-4ac9-8342-96b55017866f)

## Estrutura de projeto escolhida ( Domain-driven Design (DDD) )
```
ecommerce-api/

            api-ecommerce-maxima-tech.Tests/    <---- projeto de testes
            │
            ├── ApiTests/
            │   └── Controllers/
            │       └── ProdutosControllerTests.cs
            │
            ├── ApplicationTests/
            │   ├── Services/
            │   │   └── ProdutoServiceTests.cs
            │   └── DTOs/
            │       └── ProdutoDtoTests.cs
            │
            ├── DomainTests/
            │   └── Entities/
            │       └── ProdutoTests.cs
            ── docker/
            │   └── docker-compose.yml <- arquivo compose para subir o banco de dados com a estrutura incial, e migration inicial, feita via linguagem SQL
            │   └── scripts/
            │ 
            │       └── init.sql <-- arquivo sql para dados inciais
            │
            └── InfrastructureTests/
                └── Repositories/
                    └── ProdutoRepositoryTests.cs
            
            
            api-ecommerce-maxima-tech/  <--- projeto
            │
            ├── Api/
            │   ├── Controllers/
            │   ├── Filters/
            │   └── ViewModels/
            │
            ├── Application/
            │   ├── Interfaces/
            │   ├── Services/
            │   └── DTOs/
            │
            ├── Domain/
            │   ├── Entities/
            │   ├── Interfaces/
            │   ├── Services/
            │   └── Enums/
            │
            ├── Infrastructure/
            │   ├── Data/
            │   │   ├── Context/
            │   │   ├── Repositories/
            │   │   └── Migrations/
            │   ├── Identity/
            │   ├── IoC/
            │   └── Services/
            │
            └── Common/
                ├── Utilities/
                └── Extensions/

```

Pré-requisitos:

Docker instalado e configurado.
Docker Compose instalado.
Git instalado.
Passo a Passo:

Clone o repositório do projeto:
```
git clone [https://github.com/seu-usuario/api-ecommerce-maxima-tech.git](https://github.com/pedro-canedo/ecommerce-api.git)
```

Acesse a pasta do projeto:
cd api-ecommerce-maxima-tech
Crie e configure o arquivo .env:
Crie um arquivo .env na raiz do projeto e configure as variáveis de ambiente necessárias.

Exemplo de arquivo .env:

# Variáveis de ambiente do banco de dados
POSTGRES_HOST=localhost
POSTGRES_PORT=5432
POSTGRES_USER=postgres
POSTGRES_PASSWORD=postgres
POSTGRES_DB=ecommerce

# Variáveis de ambiente da API
ASPNETCORE_URLS=http://localhost:5000
Instale as dependências do projeto:
```
dotnet restore
```
Crie as imagens do Docker:
```
docker-compose build
```
Inicialize o banco de dados:
Execute a API:
docker-compose up
Acesse a API:
A API estará disponível em 
```
http://localhost:5000
```

Observações:

O comando docker-compose up inicia os containers do banco de dados e da API em segundo plano.
Para parar os containers, pressione Ctrl+C.
Você pode usar o comando docker-compose logs para verificar os logs dos containers.
Para acessar o container da API, use o comando docker exec -it api-ecommerce-maxima-tech bash.
Solução de problemas:

Se você encontrar erros ao executar o comando docker-compose up, verifique se o Docker e o Docker Compose estão instalados e configurados corretamente.
Verifique também se as variáveis de ambiente no arquivo .env estão configuradas corretamente.


Documentação do Docker: https://docs.docker.com/get-started/
Documentação do Docker Compose: https://docs.docker.com/compose/overview/
