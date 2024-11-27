
# Car Rental System API

Welcome to the **Car Rental System API**, a robust backend service for managing a fleet of cars, user accounts, bookings, and notifications. Built with **C#** and **Entity Framework (EF)**, this project follows best practices for creating a RESTful API.

This README provides a comprehensive overview of the system's features, endpoints, and functionalities.

---

## Overview

The Car Rental System API offers the following capabilities:

- **Car Management**: Add, update, delete, and retrieve car information.
- **User Management**: User registration, authentication, and role-based access.
- **Car Rental Operations**: Check availability, rent cars, and track rental history.
- **JWT Authentication**: Secure endpoints with JSON Web Tokens.
- **Email Notifications**: Notify users via email upon successful bookings.
- **Data Validation**: Enforce input integrity with model validation.

---

## Features

1. **Models**
    - **Car Model**
      - Properties: `Id`, `Make`, `Model`, `Year`, `PricePerDay`, `IsAvailable`.
    - **User Model**
      - Properties: `Id`, `Name`, `Email`, `Password`, `Role` (Admin/User).

2. **Services**
    - **Car Rental Service**
      - `RentCar`
      - `CheckCarAvailability`
    - **User Service**
      - `RegisterUser`
      - `AuthenticateUser` (returns JWT token).

3. **Repositories**
    - **Car Repository**
      - `AddCar`, `GetCarById`, `GetAvailableCars`, `UpdateCarAvailability`.
    - **User Repository**
      - `AddUser`, `GetUserByEmail`, `GetUserById`.

4. **Validation**
    - Input validation using C# Data Annotations (`[Required]`, `[EmailAddress]`).

5. **Middlewares**
    - Middleware for validating JWT tokens for secure access.

6. **Controllers**
    - Car Controller (`/cars`)
      - `GET`, `POST`, `PUT`, `DELETE`.
    - User Controller (`/users`)
      - `POST /register`, `POST /login`.

7. **Notifications**
    - Email notifications for booking confirmations (e.g., via SendGrid).

8. **Authentication & Authorization**
    - Secure endpoints with JWT.
    - Role-based access control (Admin/User).

9. **Testing**
    - Postman collections for endpoint testing.

---

## Getting Started

### Prerequisites

- **.NET Core SDK**
- **SQL Server** or compatible database.
- Postman (for API testing).

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/car-rental-system-api.git
   ```
2. Navigate to the project directory:
   ```bash
   cd car-rental-system-api
   ```
3. Restore dependencies:
   ```bash
   dotnet restore
   ```
4. Update the database connection string in `appsettings.json`.

5. Run the migrations to set up the database:
   ```bash
   dotnet ef database update
   ```
6. Start the API:
   ```bash
   dotnet run
   ```

---

## API Endpoints

### Car Controller

- **Get Available Cars**
  ```http
  GET /cars
  ```
  **Response Example:**
  ```json
  [
    {
      "id": 1,
      "make": "Toyota",
      "model": "Camry",
      "year": 2020,
      "pricePerDay": 50,
      "isAvailable": true
    }
  ]
  ```

- **Add a New Car**
  ```http
  POST /cars
  ```
  **Request Body:**
  ```json
  {
    "make": "Toyota",
    "model": "Corolla",
    "year": 2021,
    "pricePerDay": 40,
    "isAvailable": true
  }
  ```

- **Update Car Availability**
  ```http
  PUT /cars/{id}
  ```
  **Request Body:**
  ```json
  {
    "isAvailable": false
  }
  ```

- **Delete a Car**
  ```http
  DELETE /cars/{id}
  ```

---

### User Controller

- **Register User**
  ```http
  POST /users/register
  ```
  **Request Body:**
  ```json
  {
    "name": "John Doe",
    "email": "john.doe@example.com",
    "password": "password123",
    "role": "User"
  }
  ```

- **Login**
  ```http
  POST /users/login
  ```
  **Request Body:**
  ```json
  {
    "email": "sainadhvatturi@example.com",
    "password": "Car@1234"
  }
  ```
  **Response Example:**
  ```json
  {
    "token": "sadfjakfjadsjfasdljfasjdfijasd..."
  }
  ```

---

## Authentication

All protected endpoints require a `Bearer` token in the Authorization header:
```http
Authorization: Bearer {your_token}
```

---

## Sample Workflows

### Renting a Car

1. User logs in to get a JWT token.
2. User fetches available cars using `GET /cars`.
3. User rents a car using the `RentCar` service.

---

## Testing with Postman

Import the Postman collection (`postman_collection.json`) included in this repository to test the endpoints. The collection covers:

- User Registration and Login.
- Car Management.
- Rental Operations.

---

## Screenshots

**[Include screenshots of key features, e.g., Postman tests, API responses, or database setups here.]**

---

## Future Improvements

- **Search Filters**: Add filtering options for car retrieval.
- **Enhanced Notifications**: Include SMS support.
- **Analytics Dashboard**: Real-time metrics for admins.

---
