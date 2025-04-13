# 🧑‍💼 User Service - eCommerce Microservice

**User Service** is the authentication and identity management microservice in a modular, scalable **eCommerce platform**.  
Built with a focus on **clean architecture, best practices**, and **modern .NET tooling**, this service manages:

- User registration
- Authentication (JWT)
- Profile management

---

## 🚀 Tech Stack

| Technology        | Description                             |
|------------------|-----------------------------------------|
| ASP.NET Core      | Backend framework (.NET 8)              |
| PostgreSQL        | Relational database                     |
| Dapper            | Lightweight micro ORM                   |
| Clean Architecture| Scalable, layered project structure     |
| AutoMapper        | Object-to-object mapping                |
| DTOs              | For clean data transfer between layers  |
| FluentValidation  | Validation of models and DTOs           |
| JWT Auth          | Secure token-based authentication       |
| Docker            | Containerized for easy deployment       |

---

## 📁 Project Structure


---

## ⚙️ Features

- ✅ Register new users
- ✅ Login and receive JWT token
- ✅ Secure endpoints with `[Authorize]`
- ✅ AutoMapper for clean mapping
- ✅ FluentValidation for input validation
- ✅ Clean, testable architecture
- ✅ Docker support for local development

---

## 🐳 Getting Started (Docker)

### 📦 Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- [Docker](https://www.docker.com/)
- [pgAdmin (optional)](https://www.pgadmin.org/)

### 🔧 Run Locally

```bash
docker-compose up --build
📬 API Endpoints
Method	Endpoint	Description
POST	/api/users/register	Register a new user
POST	/api/users/login	Login and receive JWT

🔧 Configuration
appsettings.json

"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=ShoppingCartUsers;Username=postgres;Password=test123"
},
"Jwt": {
  "Key": "your_secret_key_here",
  "Issuer": "eCommerceApp",
  "Audience": "eCommerceClient",
  "ExpiresInMinutes": 60
}


🧪 Testing the API

Use Postman, curl, or the Swagger UI to test endpoints:

curl -X POST http://localhost:5000/api/users/login \
  -H "Content-Type: application/json" \
  -d '{"email":"test@example.com", "password":"password123"}'

🛠️ To Do / Roadmap

Password hashing (BCrypt)

Email verification

Role-based access (admin, customer, etc.)

Refresh tokens

Unit & integration tests

CI/CD pipeline (GitHub Actions)
