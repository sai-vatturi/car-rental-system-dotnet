
# Car Rental System API

Welcome to the **Car Rental System API**, a RESTful service designed to manage a fleet of cars, user accounts, and rental operations. This API leverages **C#** and **Entity Framework (EF)** for scalability and performance.

---

## Overview

### Features:
- **Cars**: Add, update, delete, and list cars with availability and pricing.
- **Users**: Register and authenticate users with JWT tokens.
- **Rentals**: Book cars and check rental statuses.
- **Validation**: Input fields are validated with custom rules.
- **Swagger Integration**: Explore and test endpoints with Swagger UI.
- **Role-based Authorization**: Admin-only features for car management.

---

## Getting Started

### Prerequisites
- **.NET Core SDK** installed.
- A **SQL Server** instance or compatible database.
- Postman or Swagger for API testing.

### Installation
1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/car-rental-system-api.git
   cd car-rental-system-api
   ```
2. Restore dependencies:
   ```bash
   dotnet restore
   ```
3. Update the connection string in `appsettings.json`.
4. Run migrations:
   ```bash
   dotnet ef database update
   ```
5. Start the API:
   ```bash
   dotnet run
   ```

---

## Endpoints

### Cars

#### 1. Add a Car
**Endpoint**: `POST /api/Cars`

**Request Payload**:
```json
{
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "make": "string",
  "model": "string",
  "year": 2100,
  "pricePerDay": 1,
  "isAvailable": true
}
```

**Response**:
- `201 Created`: Car added successfully.
- `400 Bad Request`: Invalid input.

---

#### 2. Update a Car
**Endpoint**: `PUT /api/Cars/{id}`

**Request Payload**:
```json
{
  "make": "string",
  "model": "string",
  "year": 2100,
  "pricePerDay": 1,
  "isAvailable": true
}
```

**Response**:
- `200 OK`: Car updated successfully.
- `404 Not Found`: Car not found.

---

#### 3. List Cars
**Endpoint**: `GET /api/Cars`

**Response Example**:
```json
[
  {
    "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "make": "Toyota",
    "model": "Corolla",
    "year": 2021,
    "pricePerDay": 40,
    "isAvailable": true
  }
]
```

---

#### 4. Delete a Car
**Endpoint**: `DELETE /api/Cars/{id}`

**Response**:
- `200 OK`: Car deleted successfully.
- `404 Not Found`: Car not found.

---

### Users

#### 1. Register a User
**Endpoint**: `POST /api/Users/register`

**Request Payload**:
```json
{
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "name": "John Doe",
  "email": "user@example.com",
  "password": "Password@123",
  "role": "Admin",
  "phoneNumber": "1234567890",
  "age": 30,
  "address": "123 Street Name, City"
}
```

**Response**:
- `201 Created`: User registered successfully.
- `400 Bad Request`: Invalid input.

---

#### 2. Login a User
**Endpoint**: `POST /api/Users/login`

**Request Payload**:
```json
{
  "email": "user@example.com",
  "password": "Password@123"
}
```

**Response Example**:
```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR..."
}
```

---

### Rentals

#### Book a Car
**Endpoint**: `POST /api/Cars/book`

**Request Payload**:
```json
{
  "carId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "userEmail": "user@example.com",
  "userName": "John Doe"
}
```

**Response**:
- `200 OK`: Booking successful.
- `400 Bad Request`: Invalid booking details.

---

## Postman Testing

**Placeholder for Postman Collection Screenshot**:

Insert screenshots of Postman requests here to showcase API testing for:
1. Adding a car.
2. Updating a car.
3. User registration.
4. User login.
5. Booking a car.

---

## Swagger UI

Swagger is integrated for API exploration. Start the API and navigate to `http://localhost:5001/swagger` to view the Swagger UI.

**Placeholder for Swagger Screenshot**:

Insert a screenshot of the Swagger UI home page.

---

## Example Workflows

### Car Booking Workflow
1. **User Registration**:
   - Use `POST /api/Users/register` to create a user.
2. **User Login**:
   - Use `POST /api/Users/login` to authenticate and obtain a JWT token.
3. **List Cars**:
   - Use `GET /api/Cars` to fetch available cars.
4. **Book a Car**:
   - Use `POST /api/Cars/book` to book a car using the car ID.

---
