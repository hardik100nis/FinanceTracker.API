# 💰 FinanceTracker.API

A powerful backend Web API built with .NET 8, CQRS, and MediatR, designed for personal finance management. Easily track expenses, set budgets, and view insightful reports — all while following enterprise-grade architecture patterns.

---

## 📦 Features

- 🔐 JWT-based Authentication (planned)
- 💳 Add, update, delete expenses
- 📊 Get expenses by user with CQRS Query
- 🧠 CQRS architecture using MediatR
- 🧾 PDF report generation (planned)
- 📬 Budget alerts via email (upcoming)
- 🔎 Swagger documentation for testing

---

## 🗂️ Project Structure

FinanceTracker.API/
├── Controllers/
│   └── ExpensesController.cs
├── Application/
│   ├── Commands/
│   └── Queries/
├── Domain/
├── Infrastructure/
├── Persistence/
├── Program.cs
└── README.md

---

## ⚙️ Technologies Used

- ASP.NET Core 8
- MediatR for CQRS
- Entity Framework Core 8
- AutoMapper
- Swagger / OpenAPI
- SQL Server

---

## 🧪 API Endpoints

### ➕ POST /api/expenses

Create a new expense.

Request Body:
{
  "userId": "GUID",
  "categoryId": "GUID",
  "amount": 250.75,
  "description": "Groceries",
  "expenseDate": "2024-06-01T12:00:00Z",
  "currency": "USD"
}

---

### 📄 GET /api/expenses/{userId}

Get all expenses for a specific user.

---

## 🚀 Getting Started

1. Clone the repository:

   git clone https://github.com/your-username/FinanceTracker.API.git
   cd FinanceTracker.API

2. Restore dependencies:

   dotnet restore

3. Update the database connection string in appsettings.json.

4. Apply migrations and create the database:

   dotnet ef database update

5. Run the API:

   dotnet run

6. Open Swagger UI:

   https://localhost:7273/swagger

---

## 📅 Roadmap

- [x] Expense CRUD (API)
- [ ] JWT Authentication
- [ ] Budget monitoring logic
- [ ] Monthly PDF reports
- [ ] Email budget alerts
- [ ] Angular frontend integration

---

## 🤝 Contributing

Feel free to fork this repository and submit a pull request. Bug reports, feature requests, and suggestions are welcome!

---

## 📄 License

This project is licensed under the MIT License.

---

## 👨‍💻 Author

Hardik Soni  
LinkedIn: https://www.linkedin.com/in/hardik-soni-62b370140/
Email: hardik100nis@gmail.com
