# MoneyTracker MVP (skeleton)

[![.NET](https://img.shields.io/badge/.NET-8-informational?style=flat&logo=.net&logoColor=white)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-9.0-informational?style=flat&logo=c-sharp&logoColor=white)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![PostgreSQL](https://img.shields.io/badge/PostgreSQL-15-blue?style=flat&logo=postgresql&logoColor=white)](https://www.postgresql.org/)
[![Kafka](https://img.shields.io/badge/Kafka-3.5-orange?style=flat&logo=apachekafka&logoColor=white)](https://kafka.apache.org/)
[![Docker](https://img.shields.io/badge/Docker-24-blue?style=flat&logo=docker&logoColor=white)](https://www.docker.com/)
[![EF Core](https://img.shields.io/badge/EF_Core-8.0-informational?style=flat&logo=dotnet&logoColor=white)](https://learn.microsoft.com/en-us/ef/core/)
[![xUnit](https://img.shields.io/badge/xUnit-2.4-lightgrey?style=flat&logo=xunit&logoColor=black)](https://xunit.net/)
[![Swagger](https://img.shields.io/badge/Swagger-OpenAPI-brightgreen?style=flat&logo=swagger&logoColor=white)](https://swagger.io/)

This repository contains a skeleton **.NET 8** solution for the _Money Tracker_ MVP, demonstrating a modular architecture with **Domain-Driven Design (DDD)** layers and a simple **Kafka microservice** for event-driven processing.

---

## Technologies Used

- **.NET 8** – backend framework.
- **C#** – programming language.
- **Entity Framework Core (EF Core)** – ORM for PostgreSQL database access.
- **PostgreSQL** – relational database.
- **Kafka & Zookeeper** – message broker for asynchronous event handling.
- **Docker & Docker Compose** – containerization and service orchestration.
- **xUnit** – unit testing framework.
- **Swagger / OpenAPI** – API documentation and testing.
- **DDD (Domain-Driven Design)** – layered architecture (Domain, Application, Infrastructure, API).

---

## Projects

- `MoneyTracker.Api` – main API containing Domain, Application, Infrastructure, and API layers.
- `MoneyTracker.EventsService` – background worker that produces and consumes Kafka events.
- `MoneyTracker.Tests` – minimal unit tests.

---

## How to run (basic)

1. Install the .NET 8 SDK.
2. Start services with Docker Compose:
   ```bash
   docker compose up -d
   ```
   This will start PostgreSQL, Zookeeper and Kafka.
3. Configure connection strings in `src/MoneyTracker.Api/appsettings.Development.json`.
4. Restore and build:
   ```bash
   dotnet restore
   dotnet build
   ```
5. Apply EF Core migrations (from `src/MoneyTracker.Api`):
   ```bash
   dotnet tool install --global dotnet-ef
   dotnet ef migrations add Initial -p src/MoneyTracker.Infrastructure -s src/MoneyTracker.Api
   dotnet ef database update -p src/MoneyTracker.Infrastructure -s src/MoneyTracker.Api
   ```
6. Run the API:
   ```bash
   dotnet run --project src/MoneyTracker.Api
   ```
   Swagger UI will be available at `http://localhost:5000/swagger`.

## Notes

- This is a starting skeleton. Implement business rules, add real migrations, and customize as needed.
