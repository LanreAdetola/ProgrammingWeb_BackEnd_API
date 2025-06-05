# NomadsNestApp – Backend API

A robust and scalable backend API built with **ASP.NET Core** for the **NomadsNestApp**, a platform for managing camping spots, amenities, bookings, and user profiles. The project emphasizes clean architecture, security, and modular design using the Repository pattern.

## 🔧 Features

- **User Management**: Register, update profiles, upload profile pictures, and delete user accounts.
- **JWT Authentication**: Secure login and access control using JSON Web Tokens.
- **Modular Architecture**: Follows MVC and Repository patterns for maintainability and scalability.
- **RESTful API Design**: Clean endpoints using standard HTTP verbs (`GET`, `POST`, `PUT`, `DELETE`).
- **LiteDB Integration**: Lightweight, file-based NoSQL database for user data.
- **Error Handling**: Graceful exception handling for better reliability.
- **File Upload Support**: Allows users to upload and update profile pictures.

## 📁 Project Structure

- `User.cs`: Model defining user properties and relationships.
- `UserRepository.cs`: Handles database operations using LiteDB.
- `UserController.cs`: API endpoints for user-related operations.
- `IUserRepository.cs`: Interface for repository abstraction to support testing and modularity.

## ✅ Benefits

- **Separation of Concerns**: Modular structure improves code clarity and development speed.
- **Security**: Secure storage and authentication of user credentials.
- **Scalable Design**: Easily adaptable to other databases or external services.
- **Testability**: Interface-based design allows easy mocking for unit tests.

## 💻 Technologies

- C#
- ASP.NET Core Web API
- LiteDB
- JWT Authentication

## 🚀 Getting Started

1. Clone the repository:
   ```bash
   git clone https://github.com/LanreAdetola/ProgrammingWeb_BackEnd_API.git
