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

# Configuração do Ambiente com Docker para api-ecommerce-maxima-tech Este guia abrange a configuração de um ambiente de desenvolvimento Dockerizado para o projeto api-ecommerce-maxima-tech.

- Clone o repositório do projeto:
```
git clone [https://github.com/seu-usuario/api-ecommerce-maxima-tech.git](https://github.com/pedro-canedo/ecommerce-api.git)
```

## Pré-requisitos
### Antes de começar, assegure-se de que o Docker e o Docker Compose estejam instalados e corretamente configurados em sua máquina. Consulte a documentação oficial para instalação:

- Docker: https://docs.docker.com/get-docker/
- Docker Compose: https://docs.docker.com/compose/install/


### Variáveis de ambiente do banco de dados

```
POSTGRES_HOST=localhost
POSTGRES_PORT=5432
POSTGRES_USER=postgres
POSTGRES_PASSWORD=postgres
POSTGRES_DB=ecommerce
```

### Este projeto foi desenvolvido com .Net core 8.0
- Para rodar o projeto, basta executar o comando abaixo na raiz do projeto:

- importante !!! 

- Garanta que as seguintes portas estejam disponíveis em sua máquina:
    - 8000
    - 3000
    - 5432
    - 5050

- você pode verificar isto da seguinte forma:
  - Para verificar no windows:  netstat -aon | findstr :8000
  - para verificar no linux: ss -tuln | grep :8000


```
    docker-compose up --build
``` 

- você deverá receber algo como isto em seu terminal

```
[+] Running 5/5
 ✔ Network ecommerce-api_default      Created                                                                                                                                                                                   0.2s 
 ✔ Container ecommerce-api-db-1       Created                                                                                                                                                                                   0.1s 
 ✔ Container ecommerce-api-api-1      Created                                                                                                                                                                                   0.2s 
 ✔ Container ecommerce-api-web-1      Created                                                                                                                                                                                   0.2s 
 ✔ Container ecommerce-api-pgadmin-1  Created                                                                                                                                                                                   0.2s 
 ```

### Acessar os serviços
- rotas:

```
    PGADMIN: [http://localhost:5050](http://localhost:5050/login)
    API: [http://localhost:8000](http://localhost:8000/swagger/index.html)
    WEB: [http://localhost:8080](http://localhost:3000/)
```

### Acessar o banco de dados
- pgAdmin acessos
```
    user: admin@admin.com
    password: admin
```




# Testes
- Para rodar os testes, basta executar o comando abaixo na raiz do projeto:

```
    cd api-ecommerce-maxima-tech.Tests
    dotnet test
```
