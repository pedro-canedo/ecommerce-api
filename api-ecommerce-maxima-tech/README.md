# Arquitetura do projeto

## Estrutura de pastas

```
api-ecommerce-maxima-tech/
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
