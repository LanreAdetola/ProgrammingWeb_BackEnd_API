# NomadsNestApp – Backend API

Robust and scalable backend API built with **ASP.NET Core** for the **NomadsNestApp**, a platform for managing camping spots, amenities, bookings, payments, reviews, images, locations, and user profiles. The project emphasizes clean architecture, security, and modular design using the Repository pattern.

## 🔧 Features

**User Management**: Register, update profiles, upload profile pictures, and delete user accounts.
**Camping Spot Management**: Create, update, delete, and list camping spots.
**Amenity Management**: Manage amenities for camping spots.
**Booking System**: Book camping spots, view and manage bookings.
**Location Management**: CRUD operations for locations.
**Payment Processing**: Handle payments for bookings.
**Review System**: Users can leave reviews for camping spots.
**Image Uploads**: Upload and manage images for users and camping spots.
**JWT Authentication**: Secure login and access control using JSON Web Tokens.
**Modular Architecture**: Follows MVC and Repository patterns for maintainability and scalability.
**RESTful API Design**: Clean endpoints using standard HTTP verbs (`GET`, `POST`, `PUT`, `DELETE`).
**LiteDB Integration**: Lightweight, file-based NoSQL database for user data.
**Error Handling**: Graceful exception handling for better reliability.
**File Upload Support**: Allows users to upload and update profile pictures.
**Swagger Documentation**: Interactive API docs at `/swagger` in development mode.
**Static File Serving**: User images and other static files served from `wwwroot`.

## 📁 Project Structure

Main folders:
- `Controllers/`: API endpoints for Users, Amenities, Bookings, CampingSpots, Images, Locations, Payments, Reviews
- `DataAccess/`: Repository and interface files for all entities
- `Models/`: Entity models and DTOs
- `Helpers/`: Utility classes (e.g., password hashing)
- `Services/`: Business logic (e.g., user service)
- `wwwroot/`: Static files (e.g., user images)
- `Program.cs`: Main entry point and configuration
## 📚 API Endpoints

All endpoints follow RESTful conventions and are prefixed with `/api/[controller]`.

**User**
- `POST /api/User/register` — Register new user
- `POST /api/User/login` — Login and receive JWT
- `GET /api/User` — List all users
- `GET /api/User/{id}` — Get user by ID
- `PUT /api/User/{id}` — Update user
- `DELETE /api/User/{id}` — Delete user
- `POST /api/User/upload-profile-picture` — Upload profile picture

**CampingSpot**
- `GET /api/CampingSpot` — List all camping spots
- `POST /api/CampingSpot` — Create camping spot
- `PUT /api/CampingSpot/{id}` — Update camping spot
- `DELETE /api/CampingSpot/{id}` — Delete camping spot

**Amenity**
- `GET /api/Amenity` — List amenities
- `POST /api/Amenity` — Add amenity
- `PUT /api/Amenity/{id}` — Update amenity
- `DELETE /api/Amenity/{id}` — Delete amenity

**Booking**
- `GET /api/Booking` — List bookings
- `POST /api/Booking` — Create booking
- `PUT /api/Booking/{id}` — Update booking
- `DELETE /api/Booking/{id}` — Delete booking

**Location**
- `GET /api/Location` — List locations
- `POST /api/Location` — Add location
- `PUT /api/Location/{id}` — Update location
- `DELETE /api/Location/{id}` — Delete location

**Payment**
- `GET /api/Payment` — List payments
- `POST /api/Payment` — Add payment
- `PUT /api/Payment/{id}` — Update payment
- `DELETE /api/Payment/{id}` — Delete payment

**Review**
- `GET /api/Review` — List reviews
- `POST /api/Review` — Add review
- `PUT /api/Review/{id}` — Update review
- `DELETE /api/Review/{id}` — Delete review

**Image**
- `GET /api/Image` — List images
- `POST /api/Image` — Upload image
- `DELETE /api/Image/{id}` — Delete image

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

2. Navigate to the main project folder:
   ```bash
   cd ProgrammingWeb_BackEnd_API/NomadsNestApp/NomadsNestApp
   ```

3. Restore dependencies and build:
   ```bash
   dotnet restore
   dotnet build
   ```

4. Run the API:
   ```bash
   dotnet run
   ```

5. Access Swagger UI for API documentation (development mode):
   - [http://localhost:5213/swagger](http://localhost:5213/swagger)

6. Static files (e.g., user images) are served from `/wwwroot`.
