# 📚 LIBRIX --- Library Management System

A production-oriented **Library Management System** built to manage
books, authors, publishers, categories, students, book copies,
issue/return operations, reservations, and library reports.

The project is designed with a clean separation between the **Angular
frontend** and **ASP.NET Core Web API backend**, with **SQL Server** as
the database.

🔗 [Open ER Diagram in Eraser]https://app.eraser.io/workspace/dA4jKsaOdh49f5M22yMT?origin=share&diagram=Ly8bg1dVTKbnl5EyXzsh4

------------------------------------------------------------------------

## 🚀 Project Overview

LIBRIX is a full-stack library management application intended to
replace manual library operations with a centralized digital system.

### Main Goals

-   Manage books and book metadata
-   Manage authors, publishers, and categories
-   Manage students
-   Manage individual book copies
-   Issue and return books
-   Track due dates and fines
-   Manage reservations
-   Generate useful library reports
-   Secure APIs using JWT authentication
-   Control access using user roles
-   Provide documented REST APIs through Swagger

------------------------------------------------------------------------

## 🛠️ Technology Stack

### Backend

  Technology              Purpose
  ----------------------- ------------------------------
  ASP.NET Core Web API    REST API
  C#                      Backend programming language
  Entity Framework Core   ORM / database access
  SQL Server              Relational database
  LINQ                    Querying data
  JWT                     Authentication
  BCrypt                  Password hashing
  Swagger / OpenAPI       API documentation

### Frontend

  Technology        Purpose
  ----------------- --------------------
  Angular           Frontend framework
  TypeScript        Frontend language
  SCSS              Styling
  Angular Signals   State management
  Reactive Forms    Form handling
  Lucide Angular    Icons

------------------------------------------------------------------------

## 🏗️ Architecture

LIBRIX follows a layered backend architecture:

``` text
Client / Angular
       │
       ▼
   Controller
       │
       ▼
    Service
       │
       ▼
   DbContext
       │
       ▼
    SQL Server
```

### Backend responsibilities

``` text
Controllers
    ↓
Handle HTTP requests and responses

Services
    ↓
Contain business logic

DTOs
    ↓
Control data entering/leaving the API

Models
    ↓
Represent database entities

Data
    ↓
Entity Framework Core DbContext

Exceptions
    ↓
Custom application exceptions

Middleware
    ↓
Global exception handling
```

------------------------------------------------------------------------

## 📂 Backend Structure

``` text
LibraryManagementSystem.API/
│
├── Controllers/
│   ├── AuthController.cs
│   ├── BookController.cs
│   ├── AuthorController.cs
│   ├── PublisherController.cs
│   ├── CategoryController.cs
│   ├── StudentController.cs
│   ├── BookCopyController.cs
│   ├── IssueRecordController.cs
│   ├── ReservationController.cs
│   └── ReportController.cs
│
├── Data/
│   ├── ApplicationDbContext.cs
│   └── SeedData.cs
│
├── DTOs/
│   ├── Auth/
│   ├── Book/
│   ├── Author/
│   ├── Publisher/
│   ├── Category/
│   ├── Student/
│   └── Reports/
│
├── Exceptions/
│   ├── NotFoundException.cs
│   ├── BadRequestException.cs
│   └── UnauthorizedException.cs
│
├── Interfaces/
│   ├── IBookService.cs
│   ├── IAuthorService.cs
│   ├── IPublisherService.cs
│   ├── ICategoryService.cs
│   └── ...
│
├── Middleware/
│   └── ExceptionMiddleware.cs
│
├── Models/
│   ├── User.cs
│   ├── Book.cs
│   ├── Author.cs
│   ├── Publisher.cs
│   ├── Category.cs
│   ├── Student.cs
│   ├── BookCopy.cs
│   ├── IssueRecord.cs
│   └── Reservation.cs
│
├── Services/
│   ├── AuthService.cs
│   ├── BookService.cs
│   ├── AuthorService.cs
│   ├── PublisherService.cs
│   ├── CategoryService.cs
│   ├── StudentService.cs
│   ├── BookCopyService.cs
│   ├── IssueRecordService.cs
│   ├── ReservationService.cs
│   └── ReportService.cs
│
└── Program.cs
```

------------------------------------------------------------------------

# 🔐 Authentication & Authorization

LIBRIX uses **JWT Bearer Authentication**.

After successful login, the API generates a JWT containing the
authenticated user's information and role.

### Supported roles

-   **Admin**
-   **Librarian**
-   **Student**

### Permission model

  Feature               Admin   Librarian   Student
  -------------------- ------- ----------- ---------
  Login                  ✅        ✅         ✅
  Manage Books           ✅        ✅         ❌
  View Books             ✅        ✅         ✅
  Manage Authors         ✅        ✅         ❌
  Manage Publishers      ✅        ✅         ❌
  Manage Categories      ✅        ✅         ❌
  Manage Book Copies     ✅        ✅         ❌
  Manage Students        ✅        ✅         ❌
  Issue Books            ✅        ✅         ❌
  Return Books           ✅        ✅         ❌
  Reservations           ✅        ✅         ✅
  Reports                ✅        ✅         ❌

Role-based authorization is implemented using ASP.NET Core's
`[Authorize]` and `[Authorize(Roles = "...")]` attributes.

------------------------------------------------------------------------

# 📚 Main Modules

## 1. Authentication

Provides:

-   User login
-   Password verification
-   JWT token generation
-   Role-based authorization
-   Active/inactive account validation

------------------------------------------------------------------------

## 2. Books

Book management includes:

-   Create book
-   View books
-   View book details
-   Update book
-   Delete book
-   Search books
-   Filter by author
-   Filter by publisher
-   Filter by category
-   Pagination

Example:

``` http
GET /api/Book?search=clean&page=1&pageSize=10
```

------------------------------------------------------------------------

## 3. Authors

Manage:

-   Author name
-   Biography
-   Author creation information
-   Books associated with the author

------------------------------------------------------------------------

## 4. Publishers

Manage:

-   Publisher name
-   Address
-   Phone number
-   Email
-   Website/details as supported by the model

------------------------------------------------------------------------

## 5. Categories

Manage:

-   Category name
-   Description
-   Creation information

------------------------------------------------------------------------

## 6. Students

Manage student information and their library activity.

------------------------------------------------------------------------

## 7. Book Copies

A `Book` represents the title, while a `BookCopy` represents an
individual physical copy.

Example:

``` text
Book
 └── Clean Code

Book Copies
 ├── COPY-001
 ├── COPY-002
 └── COPY-003
```

This allows the system to track the availability of individual physical
copies.

------------------------------------------------------------------------

## 8. Issue & Return

The issue system tracks:

-   Student
-   Book copy
-   Issue date
-   Due date
-   Return date
-   Fine
-   Issued by
-   Returned by
-   Current copy status

Default issue period:

``` text
7 days
```

The system calculates a fine when a book is returned late.

------------------------------------------------------------------------

## 9. Reservations

Students can reserve books when appropriate.

The system validates business rules before creating a reservation.

For example:

``` text
Book available
      ↓
Do not reserve
      ↓
Issue the available copy instead
```

------------------------------------------------------------------------

# 📊 Reports

The backend provides useful library reports such as:

### Overdue Books

Shows books that have passed their due date and have not been returned.

### Most Borrowed Books

Shows the most frequently issued books.

### Top Readers

Shows students with the highest borrowing activity.

### Never Borrowed Books

Shows books that have never appeared in an issue record.

### Monthly Statistics

Shows monthly borrowing statistics.

------------------------------------------------------------------------

# ⚠️ Global Exception Handling

The API uses centralized exception handling through middleware.

Custom exceptions include:

``` text
NotFoundException
BadRequestException
UnauthorizedException
```

Example:

``` csharp
if (book == null)
{
    throw new NotFoundException("Book not found.");
}
```

Instead of writing repetitive error handling in every controller, the
middleware converts exceptions into consistent HTTP responses.

------------------------------------------------------------------------

# 🔎 Search, Filtering & Pagination

The Book API supports query parameters.

### Search

``` http
GET /api/Book?search=java
```

### Filter by author

``` http
GET /api/Book?authorId=1
```

### Filter by category

``` http
GET /api/Book?categoryId=2
```

### Filter by publisher

``` http
GET /api/Book?publisherId=3
```

### Pagination

``` http
GET /api/Book?page=1&pageSize=10
```

### Combined query

``` http
GET /api/Book?search=java&categoryId=2&page=1&pageSize=10
```

------------------------------------------------------------------------

# 🌱 Seed Data

The project includes seed data to make development and testing easier.

Seed data can be used to populate the database with initial:

-   Users
-   Authors
-   Publishers
-   Categories
-   Books
-   Book copies
-   Students
-   Other required relationships

This avoids manually entering test data after every database recreation.

------------------------------------------------------------------------

# 📖 API Documentation

Swagger / OpenAPI is used to document and test the API.

After running the backend, open the Swagger UI from the configured
development URL.

Swagger provides:

-   Available endpoints
-   Request parameters
-   Request bodies
-   Response types
-   Authentication support
-   Role-protected endpoints

For protected endpoints, use the **Authorize** button and provide the
JWT bearer token.

------------------------------------------------------------------------

# 🗄️ Database

The project uses:

``` text
SQL Server
     ↓
Entity Framework Core
     ↓
ApplicationDbContext
```

The database contains relationships between major entities.

Simplified relationship:

``` text
Author ───────┐
              │
Publisher ────┤
              ├──> Book ───> BookCopy
              │
Category ─────┘

Student ─────────> IssueRecord <──────── BookCopy

Student ─────────> Reservation <──────── Book
```

------------------------------------------------------------------------

# ⚙️ Getting Started

## Prerequisites

Install:

-   .NET SDK
-   SQL Server
-   Visual Studio or VS Code
-   Node.js
-   Angular CLI

------------------------------------------------------------------------

## 1. Clone the repository

``` bash
git clone YOUR_GITHUB_REPOSITORY_URL
```

``` bash
cd LibraryManagementSystem
```

------------------------------------------------------------------------

## 2. Configure the database

Update the connection string in:

``` text
appsettings.json
```

Example:

``` json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=LMS;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

Do not commit real production credentials or secrets to GitHub.

------------------------------------------------------------------------

## 3. Apply migrations

From the backend project directory:

``` bash
dotnet ef database update
```

If migrations have not been created yet:

``` bash
dotnet ef migrations add InitialCreate
```

Then:

``` bash
dotnet ef database update
```

------------------------------------------------------------------------

## 4. Run the backend

``` bash
dotnet run
```

The API will start on the configured HTTP/HTTPS ports.

Open Swagger using the URL shown in the terminal.

------------------------------------------------------------------------

# 🧪 Testing the API

Recommended testing flow:

``` text
1. Start API
      ↓
2. Open Swagger
      ↓
3. Login
      ↓
4. Copy JWT token
      ↓
5. Click Authorize
      ↓
6. Test protected endpoints
```

Test the main modules:

-   Authentication
-   Books
-   Authors
-   Publishers
-   Categories
-   Students
-   Book Copies
-   Issue Records
-   Reservations
-   Reports

------------------------------------------------------------------------

# 🔒 Security Notes

Never commit sensitive values such as:

``` text
JWT secret keys
Database passwords
Production connection strings
API keys
Private credentials
```

Use environment variables, user secrets, or a secure secret-management
system for production deployments.

------------------------------------------------------------------------

# 🧭 Development Roadmap

### Backend

-   [x] Project foundation
-   [x] Entity models
-   [x] Entity Framework Core
-   [x] Database
-   [x] CRUD APIs
-   [x] DTOs
-   [x] Service layer
-   [x] JWT authentication
-   [x] Role-based authorization
-   [x] Global exception handling
-   [x] Seed data
-   [x] Reports
-   [x] Book search
-   [x] Book filtering
-   [x] Book pagination
-   [x] Swagger documentation

### Frontend

-   [ ] Angular project setup
-   [ ] Application layout
-   [ ] Authentication UI
-   [ ] Login
-   [ ] Dashboard
-   [ ] Books management
-   [ ] Authors management
-   [ ] Publishers management
-   [ ] Categories management
-   [ ] Students management
-   [ ] Book copies management
-   [ ] Issue/return UI
-   [ ] Reservations
-   [ ] Reports dashboard
-   [ ] Route guards
-   [ ] API integration
-   [ ] Production optimization

------------------------------------------------------------------------

# 🎯 Future Improvements

Possible future enhancements:

-   Advanced sorting
-   Pagination metadata
-   Student-specific borrowing history
-   Fine payment tracking
-   Email notifications
-   Due-date reminders
-   Audit logging
-   Refresh tokens
-   Advanced dashboard analytics
-   File/image upload for book covers
-   Deployment with CI/CD
-   Automated unit and integration tests

------------------------------------------------------------------------

# 💡 What This Project Demonstrates

This project demonstrates practical knowledge of:

-   C#
-   ASP.NET Core Web API
-   REST API design
-   Entity Framework Core
-   SQL Server
-   LINQ
-   DTO pattern
-   Dependency Injection
-   Service Layer architecture
-   JWT authentication
-   Role-based authorization
-   Middleware
-   Exception handling
-   Database relationships
-   CRUD operations
-   Search and filtering
-   Pagination
-   API documentation
-   Angular
-   TypeScript
-   SCSS
-   Reactive Forms
-   Frontend architecture

------------------------------------------------------------------------

# 👨‍💻 Author

**Pradeep Kumawat**

Library Management System --- **LIBRIX**

Built as a full-stack software engineering project with a focus on clean
architecture, real-world business logic, security, and maintainability.

------------------------------------------------------------------------

## ⭐ If you find this project useful

Feel free to explore the code, raise issues, suggest improvements, or
use the project as a learning reference.

**LIBRIX --- Manage your library. Simplify your workflow.**
