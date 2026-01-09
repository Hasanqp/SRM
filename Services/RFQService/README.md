# RFQService

## 📌 Overview
RFQService is a clean, event‑driven microservice responsible for managing **Request For Quotation (RFQ)** lifecycle.
It is designed following **Clean Architecture**, **CQRS**, and **DDD** principles and is fully interview‑ready.

The service handles:
- RFQ creation and lifecycle (Send, Close, Cancel, Award)
- Supplier bid submissions
- Selecting a winning bid
- Automatically creating Purchase Orders via Domain Events

---

## 🏗️ Architecture Principles

- **Clean Architecture** (Domain‑centric)
- **CQRS** (Commands / Queries separated)
- **Domain Events** for cross‑aggregate communication
- **No infrastructure leakage into Domain**
- **MediatR** for in‑process messaging

---

## 🧱 Project Structure

```
RFQService
├── RFQService.API
│   ├── Controllers
│   ├── Contracts
│   ├── Middleware
│   └── Program.cs
│
├── RFQService.Application
│   ├── RFQs
│   │   ├── Commands
│   │   ├── Queries
│   │   └── EventHandlers
│   ├── PurchaseOrders
│   │   └── EventHandlers
│   └── Abstractions
│
├── RFQService.Domain
│   ├── Entities
│   ├── Events
│   ├── Enums
│   ├── Exceptions
│   └── Common
│
├── RFQService.Infrastructure
│   └── Persistence
│       └── Repositories
```

---

## 🔄 High Level Flow

### RFQ Lifecycle

```
API Request
   ↓
Controller
   ↓
Command / Query (MediatR)
   ↓
Application Handler
   ↓
Domain Aggregate (RFQ)
   ↓
Repository (InMemory)
```

---

## ⚡ Event‑Driven Flow (Award RFQ)

```
AwardRFQCommand
   ↓
RFQ.Award()
   ↓
RFQAwardedDomainEvent
   ↓
Application Event Handler
   ↓
PurchaseOrder Created
```

✔ RFQ does NOT know about PurchaseOrder
✔ Loose coupling via Domain Events

---

## 🧠 Domain Model

### RFQ Aggregate

- Controls lifecycle
- Validates state transitions
- Owns Bids
- Raises Domain Events

### PurchaseOrder Aggregate

- Created from RFQAwardedDomainEvent
- Independent lifecycle

---

## 🧪 Error Handling

Global exception handling implemented using **ProblemDetails (RFC 7807)**.

| Exception Type | HTTP Status |
|---------------|------------|
| NotFoundException | 404 |
| DomainException | 409 |
| Unknown | 500 |

---

## 🧰 Tech Stack

- .NET 8
- ASP.NET Core Web API
- MediatR
- In‑Memory Repositories (replaceable)
- Swagger / OpenAPI

---

## 🚀 Why This Design?

- Easy to extend (real DB, message broker)
- Testable business logic
- Interview‑friendly explanation
- Matches real enterprise systems

---

## 🧾 Example Endpoints

```
POST   /api/rfqs
POST   /api/rfqs/{id}/send
POST   /api/rfqs/{id}/bids
POST   /api/rfqs/{id}/award
GET    /api/rfqs/{id}
GET    /api/rfqs/{id}/details
```

---

## ✅ Status

✔ Feature‑complete
✔ Clean Architecture compliant
✔ Event‑driven
✔ Ready for production discussion

---

👨‍💻 Author

Built as a professional showcase project focusing on architecture, correctness, and clarity.

