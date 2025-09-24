# Restaurants Web API

This project is a **RESTful Web API** built with **ASP.NET Core 9** and structured using **Clean Architecture** principles.  
The goal is to provide a scalable, maintainable, and flexible backend solution while applying industry best practices.  

---

## 📌 Features

- **RESTful API Endpoints**  
  Perform Create, Read, Update, and Delete (CRUD) operations on resources.

- **Entity Framework Core Integration**  
  MS SQL Server database setup with seamless data interaction.

- **Database Seeding**  
  Populate initial data for testing and realistic scenarios.

- **Clean Architecture with CQRS**  
  Structured codebase following Clean Architecture principles with MediatR for Command/Query Responsibility Segregation.

- **DTOs & Validation**  
  Data Transfer Objects with **FluentValidation** to ensure data integrity and security.

- **Sub-entity Management**  
  Handle nested resources in a proper RESTful manner.

- **Authentication & Authorization**  
  Implemented using **ASP.NET Identity** with roles and custom claims.

- **Pagination & Sorting**  
  Optimized endpoints for handling large datasets.

- **API Documentation**  
  Auto-generated interactive documentation with **Swagger**.

---

## 🏗️ Technologies & Libraries

- **ASP.NET Core 9**
- **Entity Framework Core (SQL Server)**
- **MediatR (CQRS pattern)**
- **FluentValidation**
- **ASP.NET Identity**
- **Swagger**

---

## 📂 Project Structure

This project follows **Clean Architecture** principles:

- **Domain** – Core entities, enums, exceptions, and business logic.
- **Application** – Application-specific business rules, DTOs, CQRS handlers.
- **Infrastructure** – Database, persistence, and external services (EF Core, Identity).
- **API** – ASP.NET Core Web API layer (controllers, Swagger setup).



### Setup & Run
1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/your-repo-name.git
