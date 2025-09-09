# ✅ ToDo App  

A clean, modular **To-Do list application** built with **.NET** following a layered architecture.  
This project demonstrates best practices in **API design, business logic separation, data persistence, and testing**.  

---

## 🚀 Features  
- Create, update, delete tasks  
- Mark tasks as completed  
- Categorize and prioritize todos  
- RESTful API with Swagger documentation  
- Unit & integration tests  

---

## 🎯 Problem & Solution  
**Problem:** Managing tasks effectively often requires more than just a checklist—apps should be structured, scalable, and maintainable.  

**Solution:** This project demonstrates how to design a **modular .NET To-Do application** with clean architecture principles:  
- Separation of concerns (API, business, data, tests).  
- Scalable structure for future features.  
- Production-ready patterns (dependency injection, layered design).  

---

## 🛠️ Tech Stack  
- **Backend:** .NET 7, C#  
- **API:** ASP.NET Core Web API  
- **Data:** Entity Framework Core, SQL Server/MySQL  
- **Testing:** xUnit / NUnit (with mocking)  
- **Other:** Swagger for API docs, Dependency Injection  

---

## 📂 Solution Structure 
```plaintext
project-root
 ├── todo.api        # REST API layer (controllers, Swagger setup)
 ├── todo.app        # Application services (use cases, DTOs, validation)
 ├── todo.business   # Business logic (domain rules, entities)
 ├── todo.core       # Core models, shared utilities
 ├── todo.data       # Data access (repositories, EF Core DbContext)
 ├── todo.tests      # Unit & integration tests
 └── README.md

```

---

## ⚡ Getting Started  

### Prerequisites  
- .NET 7 SDK  
- SQL Server or MySQL (local or containerized via Docker)  

### Installation  
```bash
# clone the repo
git clone https://github.com/username/todo-app.git

# navigate to project folder
cd todo-app

# restore dependencies
dotnet restore

Swagger will be available at:
👉 https://localhost:5002/swagger

# Running Tests
dotnet test

```
---
### 📡 API Endpoints
---
### ✅ Roadmap

- User authentication & roles

- Task due dates & reminders

- Frontend Blazor integration

- CI/CD pipeline setup
---

### 🧪 Tests & CI/CD

- Unit tests for business logic

- Integration tests for API endpoints

---

### 👤 Author

Abdallah

LinkedIn: [Your Profile]

Portfolio: [Your Website]

GitHub: [Your GitHub]
- Future: GitHub Actions pipeline for CI/CD

