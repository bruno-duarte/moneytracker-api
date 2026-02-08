# 💰 MoneyTracker API

[![.NET](https://img.shields.io/badge/.NET-8-informational?style=flat&logo=.net&logoColor=white)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-9.0-informational?style=flat&logo=c-sharp&logoColor=white)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![PostgreSQL](https://img.shields.io/badge/PostgreSQL-15-blue?style=flat&logo=postgresql&logoColor=white)](https://www.postgresql.org/)
[![Kafka](https://img.shields.io/badge/Kafka-3.5-orange?style=flat&logo=apachekafka&logoColor=white)](https://kafka.apache.org/)
[![Docker](https://img.shields.io/badge/Docker-24-blue?style=flat&logo=docker&logoColor=white)](https://www.docker.com/)
[![EF Core](https://img.shields.io/badge/EF_Core-8.0-informational?style=flat&logo=dotnet&logoColor=white)](https://learn.microsoft.com/en-us/ef/core/)
[![xUnit](https://img.shields.io/badge/xUnit-2.4-lightgrey?style=flat&logo=xunit&logoColor=black)](https://xunit.net/)
[![Swagger](https://img.shields.io/badge/Swagger-OpenAPI-brightgreen?style=flat&logo=swagger&logoColor=white)](https://swagger.io/)

MoneyTracker is a **residential expense control system** implemented as a modern .NET 8 API, following **Clean Architecture** and **Domain-Driven Design (DDD)** principles.

The project exposes RESTful endpoints for managing people, categories, transactions, and financial reports, with persistence in a relational database and asynchronous event processing using Kafka.

---

## 📌 Overview

The MoneyTracker API allows clients to:

- Manage people (CRUD)
- Manage categories
- Register income and expense transactions
- Enforce business rules defined in the domain
- Generate financial reports by person and category
- Persist data across system restarts
- Publish domain events via Kafka

This backend is designed to be consumed by a React frontend application.

---

## 🧠 Business Rules Implemented

### 👤 People

- Each person has a unique identifier, name (max 200 chars), and age.
- Deleting a person removes all related transactions (cascade rule).

### 🗂️ Categories

- Each category has a description (max 400 chars) and a purpose:
  - Income
  - Expense
  - Both

### 💰 Transactions

- Transaction value must be positive.
- Minors (under 18 years old) can only register expenses.
- Categories must match the transaction type (purpose validation).

---

## 🏗️ Architecture

The solution follows Clean Architecture with DDD concepts:

```bash
src/
├── MoneyTracker.Api/            # Presentation layer (Controllers, Filters, Swagger)
├── MoneyTracker.Application/    # Application layer (DTOs, Services, Use Cases)
├── MoneyTracker.Domain/         # Domain layer (Entities, Value Objects, Rules, Events)
├── MoneyTracker.Infrastructure/ # Infrastructure layer (EF Core, Repositories, Persistence)
├── MoneyTracker.EventsService/  # Kafka producer/consumer background service
tests/
└── MoneyTracker.Tests/          # Unit tests
```

### Layer Responsibilities

- **Domain** → Core business rules and invariants.
- **Application** → Use cases and orchestration logic.
- **Infrastructure** → Database, messaging, and external integrations.
- **API** → HTTP endpoints and request/response handling.

---

## 🧱 Domain Model

### Entities

- Person
- Category
- Transaction

### Value Objects

- Money

### Enums

- TransactionType (Income, Expense)
- CategoryPurpose (Income, Expense, Both)

### Patterns Used

- Repository Pattern
- Specification Pattern
- DTOs & Mappers
- Domain Events
- Unit of Work (via EF Core)

---

## 🔗 API Endpoints

### 👤 People

| Method | Endpoint            |
| ------ | ------------------- |
| POST   | /api/v1/People      |
| GET    | /api/v1/People      |
| GET    | /api/v1/People/{id} |
| PUT    | /api/v1/People/{id} |
| PATCH  | /api/v1/People/{id} |
| DELETE | /api/v1/People/{id} |

---

### 🗂️ Categories

| Method | Endpoint                |
| ------ | ----------------------- |
| POST   | /api/v1/Categories      |
| GET    | /api/v1/Categories      |
| GET    | /api/v1/Categories/{id} |
| PUT    | /api/v1/Categories/{id} |
| PATCH  | /api/v1/Categories/{id} |
| DELETE | /api/v1/Categories/{id} |

---

### 💰 Transactions

| Method | Endpoint                  |
| ------ | ------------------------- |
| POST   | /api/v1/Transactions      |
| GET    | /api/v1/Transactions      |
| GET    | /api/v1/Transactions/{id} |
| PUT    | /api/v1/Transactions/{id} |
| PATCH  | /api/v1/Transactions/{id} |
| DELETE | /api/v1/Transactions/{id} |

---

### 📊 Reports

| Method | Endpoint                   |
| ------ | -------------------------- |
| GET    | /api/v1/Reports/people     |
| GET    | /api/v1/Reports/categories |

---

## 🖼️ API Documentation (Swagger)

After running the API:

```
http://localhost:5000/swagger
```

---

## 🛠️ Technologies Used

- **.NET 8** – backend framework.
- **C#** – programming language.
- **Entity Framework Core** – ORM.
- **PostgreSQL** – relational database.
- **Kafka & Zookeeper** – asynchronous messaging.
- **Docker & Docker Compose** – containerization.
- **Swagger / OpenAPI** – API documentation.
- **xUnit** – unit testing.
- **DDD & Clean Architecture** – architectural approach.

---

## ▶️ How to Run

### 1️⃣ Requirements

- .NET 8 SDK
- Docker & Docker Compose
- PostgreSQL (or Docker container)
- Kafka (via Docker Compose)

---

### 2️⃣ Start infrastructure services

```bash
docker compose up -d
```

This starts:

- PostgreSQL
- Zookeeper
- Kafka

---

### 3️⃣ Configure the database

Update `appsettings.Development.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=moneytracker;Username=postgres;Password=postgres"
}
```

---

### 4️⃣ Run migrations

```bash
dotnet tool install --global dotnet-ef

dotnet ef migrations add CategoryDescription \
  -p src/MoneyTracker.Infrastructure \
  -s src/MoneyTracker.Api \
  --context PostgreSqlDbContext

dotnet ef database update \
  -p src/MoneyTracker.Infrastructure \
  -s src/MoneyTracker.Api \
  --context PostgreSqlDbContext
```

---

### 5️⃣ Run the API

```bash
dotnet run --project src/MoneyTracker.Api
```

---

## 🧪 Testing

```bash
dotnet test
```

---

## 🧠 Design Decisions

- Clean Architecture ensures separation of concerns and maintainability.
- DDD models the business domain explicitly.
- Kafka is used to demonstrate event-driven architecture.
- EF Core handles persistence with PostgreSQL.
- Specification pattern avoids N+1 queries in reporting scenarios.

---

## 🚀 Future Improvements

- Authentication & authorization (JWT)
- Role-based access control
- Caching (Redis)
- CI/CD pipelines
- Observability (logging, metrics, tracing)
- More automated tests
