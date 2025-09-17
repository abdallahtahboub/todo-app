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
- **Frontend**: BLazor Server
- **API:** ASP.NET Core Web API
- ORM: Entity Framework Core  
- **Data:** PostgreSQL
- **Testing:** xUnit with In-Memory Database
- **Documentation:** Swagger/OpenAP
- **Package Managemen:** NuGet
- **Other:** Dependency Injection  

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
- .NET 9 SDK  
- Postgressql (local or containerized via Docker)  

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
### 📡 API Endpoints

🔹 Get All Todos
Request URL

http://localhost:5002/Todo

Example Server Response

<pre> [{"itemId":11,"value":"test me","isCompleted":true},{"itemId":12,"value":"hello","isCompleted":true},{"itemId":13,"value":"string","isCompleted":true},{"itemId":14,"value":"string","isCompleted":true},{"itemId":15,"value":"string","isCompleted":true},{"itemId":16,"value":"string","isCompleted":true},{"itemId":17,"value":"string","isCompleted":true},{"itemId":18,"value":"string","isCompleted":true},{"itemId":19,"value":"string","isCompleted":true},{"itemId":20,"value":"string","isCompleted":true},{"itemId":21,"value":"string","isCompleted":true},{"itemId":22,"value":"string","isCompleted":true},{"itemId":23,"value":"string","isCompleted":true}] </pre>

---
## ✅ Roadmap

- User authentication & roles

- Task due dates & reminders

- Frontend Blazor integration

- CI/CD pipeline setup
---

## 🧪 Tests & CI/CD

- Unit tests for business logic

- Integration tests for API endpoints
- Future: GitHub Actions pipeline for CI/CD

---

## 👤 Author

Abdallah

LinkedIn: [www.linkedin.com/in/abdallah-tahboub-024954a7]
