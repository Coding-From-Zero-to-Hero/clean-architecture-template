# Clean Architecture Template

A production-ready .NET 10 template implementing Clean Architecture principles with modern best practices, Docker support, and comprehensive architecture testing.

![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?style=flat&logo=dotnet)
![PostgreSQL](https://img.shields.io/badge/Database-PostgreSQL-336791?style=flat&logo=postgresql)
![Docker](https://img.shields.io/badge/Container-Docker-2496ED?style=flat&logo=docker)
![License](https://img.shields.io/badge/License-MIT-green?style=flat)

## 🏗️ Architecture Overview

This template follows **Clean Architecture** principles, organizing code into concentric layers with clear separation of concerns:

```
┌─────────────────────────────────────────────────────────┐
│                    Web.Api (Presentation)                │
│                  ┌─────────────────────┐                │
│                  │   Infrastructure    │                │
│  ┌───────────────▼─────────────────────▼────────────┐  │
│  │              Application (Use Cases)              │  │
│  │  ┌─────────────────────────────────────────────┐  │  │
│  │  │           Domain (Business Logic)           │  │  │
│  │  │  ┌───────────────────────────────────────┐  │  │  │
│  │  │  │     SharedKernel (Common Types)       │  │  │  │
│  │  │  └───────────────────────────────────────┘  │  │  │
│  │  └─────────────────────────────────────────────┘  │  │
│  └───────────────────────────────────────────────────┘  │
└─────────────────────────────────────────────────────────┘
```

### Layer Dependencies

```
Web.Api → Infrastructure → Application → Domain → SharedKernel
                         Application → Domain
```

## 📁 Project Structure

```
clean-architecture-template/
├── src/
│   ├── Domain/              # Core business entities and logic
│   ├── Application/         # Use cases, interfaces, DTOs
│   ├── Infrastructure/      # External implementations (DB, APIs)
│   ├── SharedKernel/        # Common types (Result, Error, Entity)
│   └── Web.Api/             # REST API, controllers, middleware
├── tests/
│   └── ArchitectureTests/   # NetArchTest rules enforcement
├── docker-compose.yml       # Full stack orchestration
└── Directory.Packages.props # Central package management
```

## 🚀 Features

### Core Features
- ✅ **Clean Architecture** - Strict layer separation with dependency rules
- ✅ **.NET 10** - Latest framework with modern C# features
- ✅ **Docker Ready** - Multi-stage builds with docker-compose
- ✅ **PostgreSQL** - Configured with EF Core and naming conventions
- ✅ **Serilog** - Structured logging with Seq integration
- ✅ **Health Checks** - Built-in health monitoring endpoints
- ✅ **Swagger/OpenAPI** - Auto-configured API documentation
- ✅ **JWT Authentication** - Ready-to-configure authentication

### Quality & Testing
- ✅ **Architecture Tests** - NetArchTest enforces layer boundaries
- ✅ **SonarAnalyzer** - Static code analysis
- ✅ **Central Package Management** - Consistent versions
- ✅ **Strict Code Analysis** - Treat warnings as errors

### Shared Kernel Patterns
- ✅ **Result Pattern** - Functional error handling
- ✅ **Domain Events** - Event-driven architecture support
- ✅ **Base Entity** - Common entity infrastructure

## 🛠️ Tech Stack

| Layer | Technologies |
|-------|-------------|
| **Framework** | .NET 10, ASP.NET Core |
| **Database** | PostgreSQL, EF Core 10 |
| **Logging** | Serilog, Seq |
| **Validation** | FluentValidation |
| **Testing** | xUnit, NetArchTest, Shouldly |
| **API Docs** | Swagger/OpenAPI |
| **Container** | Docker, Docker Compose |

## 🚀 Getting Started

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [Docker Desktop](https://www.docker.com/products/docker-desktop)
- IDE (Visual Studio 2022, Rider, or VS Code)

### Quick Start

1. **Clone the repository**
   ```bash
   git clone https://github.com/yourusername/clean-architecture-template.git
   cd clean-architecture-template
   ```

2. **Run with Docker Compose**
   ```bash
   docker-compose up --build
   ```

3. **Access the application**
   - API: `http://localhost:5000`
   - Swagger UI: `http://localhost:5000/swagger`
   - Seq Logs: `http://localhost:8081`
   - PostgreSQL: `localhost:5432`

### Development Setup

```bash
# Restore dependencies
dotnet restore

# Run the API (development)
dotnet run --project src/Web.Api

# Run architecture tests
dotnet test tests/ArchitectureTests
```

## 📦 Solution Structure

### Domain Layer
Pure business logic with no external dependencies.
- Entities
- Value Objects
- Domain Events
- Domain Services

### Application Layer
Use cases and application orchestration.
- Commands & Queries (CQRS ready)
- DTOs & Mappers
- Validation (FluentValidation)
- Service Interfaces

### Infrastructure Layer
External concerns implementation.
- EF Core DbContext & Migrations
- Repository Implementations
- External Services
- JWT Authentication

### Web.Api Layer
Presentation layer.
- Minimal APIs / Endpoints
- Middleware Pipeline
- Swagger Configuration
- Health Checks

## 🔒 Architecture Enforcement

Architecture tests using **NetArchTest** ensure layer boundaries are never violated:

```csharp
// Example rules enforced by tests
Domain → No dependencies on Application/Infrastructure/Presentation
Application → No dependencies on Infrastructure/Presentation
Infrastructure → No dependencies on Presentation
```

Run tests to verify:
```bash
dotnet test --filter "ArchitectureTests"
```

## 🐳 Docker Configuration

The template includes a complete Docker setup:

| Service | Port | Description |
|---------|------|-------------|
| web-api | 5000/5001 | ASP.NET Core API |
| postgres | 5432 | PostgreSQL database |
| seq | 8081 | Log aggregation |

## ⚙️ Configuration

### Environment Variables

Key configuration in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=postgres;Database=clean-architecture;Username=postgres;Password=postgres"
  },
  "Serilog": {
    "Using": [ "Serilog.Sinks.Console", "Serilog.Sinks.Seq" ],
    "WriteTo": [
      { "Name": "Seq", "Args": { "serverUrl": "http://seq:80" } }
    ]
  }
}
```

## 🎯 Usage Example

### Result Pattern

```csharp
public class UserService
{
    public async Task<Result<User>> GetUserByIdAsync(Guid id)
    {
        var user = await _repository.GetByIdAsync(id);
        
        if (user is null)
            return Result.Failure<User>(Error.NotFound);
        
        return Result.Success(user);
    }
}
```

### Domain Event

```csharp
public class UserCreatedEvent : IDomainEvent
{
    public Guid UserId { get; }
    public DateTime CreatedAt { get; }
}
```

<div align="center">

**Built with ❤️ using Clean Architecture principles**

</div>
