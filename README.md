🚀 SRM – Supplier Relationship Management System
================================================

📌 What is SRM?
---------------

**SRM** is a modular procurement system that models real-world enterprise purchasing workflows. It focuses on **business rules**, **process orchestration**, and **scalable architecture**, rather than simple CRUD operations.

The project applies the following architectural concepts:

*   Clean Architecture
    
*   Domain-Driven Design (DDD)
    
*   CQRS
    
*   Event-driven business workflows
    
*   Readiness for microservices environments
    

🎯 Why this project exists (Business Perspective)
-------------------------------------------------

This project was built to explore how procurement workflows
can be represented as explicit domain models rather than
implicit controller logic:

*   Purchase request approval flows
    
*   Supplier quotations and bidding
    
*   Business rules for awarding suppliers
    
*   Automatic Purchase Order creation
    
*   Clear ownership of responsibilities between systems
    

🧱 System Architecture
----------------------

The solution is structured as **independent services**, each owning its own:

*   Domain
    
*   Business rules
    
*   Persistence
    
*   Application logic
    

Each service follows **Clean Architecture layers**:

```
API 
Application
Domain
Infrastructure
```
This separation allows:

*   Independent evolution
    
*   Testability
    
*   Easy extraction into standalone microservices
    

🧩 Services Overview
--------------------

### 📝 PRService – Purchase Request Management

**Responsibility:**

*   Creating purchase requests
    
*   Validating business rules
    
*   Managing request lifecycle (Draft → Submitted → Approved)
    

**Key Concepts:**

*   Aggregate Root: PurchaseRequest
    
*   Explicit domain rules for state transitions
    
*   Application layer orchestration
    

📂 Path:
Services/PRService

📄 Details:➡️ Services/PRService/README.md

### 📦 RFQService – Request for Quotation & Supplier Bidding

**Responsibility:**

*   Creating RFQs from approved PRs
    
*   Managing supplier bids
    
*   Selecting awarded suppliers
    
*   Automatically creating Purchase Orders using domain events
    

**Key Concepts:**

*   RFQ Aggregate
    
*   Supplier Bids as Value Objects
    
*   Domain Events for Purchase Order creation
    
*   Event-driven workflow
    

📂 Path:
Services/RFQService

📄 Details:➡️ Services/RFQService/README.md

### 🛒 POService – Purchase Orders (Planned)

**Status:** Planned / Conceptual

Purchase Orders are currently generated through **domain events** inside RFQService.

The design intentionally allows:

*   Future extraction into a standalone PO microservice
    
*   Event-based integration without breaking existing logic
    

🧠 Architectural Decisions
--------------------------

Architectural choices were made to:

- Keep controllers thin and focused on request handling
- Place business rules inside the domain and application layers
- Isolate infrastructure concerns behind abstractions

This results in a domain-centric design where business rules
are explicit, application services handle orchestration,
and infrastructure concerns remain isolated.

🧪 Testing Strategy (Planned Enhancement)
-----------------------------------------

The architecture supports:

*   Unit Testing of Domain rules
    
*   Application Service testing
    
*   Mockable infrastructure via interfaces
    

(Current focus was architectural correctness; tests can be added without refactoring.)


📌 Key Takeaway
---------------

This project focuses on modeling business workflows explicitly
and keeping business rules isolated from technical concerns.

Design decisions favor clarity, separation of responsibilities,
and future extensibility.

🛠️ Technologies Used
---------------------

*   ASP.NET Core
    
*   Entity Framework Core
    
*   Clean Architecture
    
*   Domain-Driven Design (DDD)
    
*   CQRS
    
*   Dependency Injection
    
*   Domain Events
