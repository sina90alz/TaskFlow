# TaskFlow

**TaskFlow** is a clean-architecture .NET 8 Web API project for managing tasks and users.  
It demonstrates best practices for building modern, scalable applications using **C#**, **Entity Framework Core**, and **MediatR**.

---

## Features
- User registration & authentication (JWT auth)
- Task creation, assignment, and status tracking
- Clean Architecture:
  - **Domain** (Entities, business rules)
  - **Application** (CQRS, MediatR handlers)
  - **Infrastructure** (EF Core, Repositories)
  - **API** (Controllers, Swagger, Postman)
- Extensible design for future Machine Learning integration (e.g., task prioritization)

---

## Tech Stack
- [.NET 8](https://dotnet.microsoft.com/)
- [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/)
- [MediatR](https://github.com/jbogard/MediatR)
- [Swagger / Swashbuckle](https://github.com/domaindrivendev/Swashbuckle.AspNetCore)
- [SQL Server / SQLite] (configurable)

---

## Project Structure
```plaintext
TaskFlow/
 ├── TaskFlow.Domain/         # Entities & core business rules
 ├── TaskFlow.Application/    # Use cases (CQRS + MediatR)
 ├── TaskFlow.Infrastructure/ # EF Core, Repositories, DB Context
 ├── TaskFlow.API/            # Web API entrypoint
 ├── README.md
 └── .gitignore
