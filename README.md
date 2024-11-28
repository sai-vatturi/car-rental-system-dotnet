# Car Rental System DotNet

Welcome to the **Car Rental System Dotnet API**, a RESTful service designed to manage a fleet of cars, user accounts, and rental operations. This API leverages **C#** and **Entity Framework (EF)** for scalability and performance.

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


### Users

1. User Registration Invalid
<img width="1005" alt="image" src="https://github.com/user-attachments/assets/78e83653-934c-4be3-b1ce-bcd4909b8050">

2. User Registration Valid
<img width="1035" alt="image" src="https://github.com/user-attachments/assets/6e70e05d-298b-45f9-ae8a-c7256aef6699">


3. User Login Invalid
<img width="1007" alt="image" src="https://github.com/user-attachments/assets/faee014d-fc2d-4b63-8ec2-e38161fd00bc">


4. User Login Valid
<img width="1006" alt="image" src="https://github.com/user-attachments/assets/77f5ff11-aa3e-410e-9590-7251e3b51a43">


### Cars

To access cars, first we should login to JWT Bearer Token

<img width="717" alt="image" src="https://github.com/user-attachments/assets/d0625822-4287-4a1f-b3d4-3b0f77557e84">

1. Post New Car as Admin
<img width="1005" alt="image" src="https://github.com/user-attachments/assets/5add2565-8642-458e-8d08-39c122887872">
2. Post New Car as User
<img width="1043" alt="image" src="https://github.com/user-attachments/assets/4e387577-63a5-46b6-9006-b07773e29b17">

3. Get All Cars
<img width="1014" alt="image" src="https://github.com/user-attachments/assets/89807603-a3a2-43d6-aad4-bcfdbfc23f7e">
4. Put Car as Admin
<img width="1012" alt="image" src="https://github.com/user-attachments/assets/c386481d-c860-49a1-9acd-87714bb9dcf9">
5. Put Car as User
<img width="1016" alt="image" src="https://github.com/user-attachments/assets/3fa3dddb-31d8-43fc-946e-9dd79499a752">

6. Delete Car as Admin
<img width="1020" alt="image" src="https://github.com/user-attachments/assets/bb1a9f29-b515-41d9-9dd0-69106f929ef4">

7. Delete Car as User
<img width="1005" alt="image" src="https://github.com/user-attachments/assets/3ad7226e-e28c-4ab1-8d9e-c938c9182c61">

8. Book Car as Admin
<img width="1016" alt="image" src="https://github.com/user-attachments/assets/6fb01b58-9895-4416-a701-10d3033aa7ed">
---

## Swagger UI

<img width="1097" alt="image" src="https://github.com/user-attachments/assets/e0ce1a69-0653-4832-bbe2-3ab7e78d0284">

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
