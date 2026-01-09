# SRM (Supplier Relationship Management) System

## 📌 Overview
SRM is a modular procurement system designed using Clean Architecture,
DDD, CQRS, and event-driven principles.

The system is composed of independent services, each owning its own
bounded context and business rules.

---

## 🧱 Services

### 📝 PRService (Purchase Requests)
Manages the lifecycle of purchase requests from creation to approval.

➡️ `Services/PRService/README.md`

---

### 📦 RFQService (Requests for Quotation)
Handles RFQs, supplier bids, awarding, and automatic purchase order creation
via domain events.

➡️ `Services/RFQService/README.md`

---

### 🛒 POService (Purchase Orders)
Planned as a future standalone service.
Currently modeled inside RFQService via domain events.

---

## 🧠 Architecture Highlights
- Clean Architecture
- Domain-Driven Design
- CQRS
- Event-driven communication
- Designed for future microservice extraction