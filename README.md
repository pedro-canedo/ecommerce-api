# Arquitetura do projeto

## Estrutura de pastas

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
            │   └── Services/ (por exemplo, serviços de log, envio de e-mail, etc.)
            │
            └── Common/ (opcional, para coisas que realmente são compartilhadas por todas as camadas)
                ├── Utilities/
                └── Extensions/

```
