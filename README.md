# BloodBankManagement

## Project Overview
The Blood Bank Management System is a simple ASP.NET Core API program which is used for maintaining the records of blood donors. It allows CRUD operations, searching, pagination, and sorting of donor records.

## Features
- Add, update, delete, and retrieve donor records.
- Search donors by name, blood type, or status.
- Paginate results for efficient data presentation.

## Prerequisites
Ensure the following are installed on your system:
- .NET 6 SDK or later
- A code editor like Visual Studio or Visual Studio Code
- A REST client like Postman for testing the API.

## Setup Instructions

### 1. Clone the Repository
```bash
git clone https://github.com/hrishikesh-duvva/BloodBankManagement.git
cd BloodBankManagement
```

### 2. Build the Project
```bash
dotnet build
```

### 3. Run the API
Start the API server:
```bash
dotnet run
```
By default, the server will run at [http://localhost:5178](http://localhost:5178).

### 4. Test the API
Open [http://localhost:5178/swagger/index.html](http://localhost:5178/swagger/index.html) for API testing using Swagger.
Use Postman to test the endpoints.

## Endpoints Documentation

### 1. Get All Entries
Retrieve all donor records.

**GET** `/api/BloodBank`

**Response:**
```json
[
    {
        "donorName": "Anjali Bose",
        "age": 30,
        "bloodType": "O-",
        "contactInfo": "anjali.bose@example.com",
        "quantity": 500,
        "collectionDate": "2024-11-16T16:00:00",
        "expirationDate": "2025-01-16T16:00:00",
        "status": "Available"
    },
    ...
]
```

### 2. Get Entry by ID
Retrieve a single donor record by its unique ID.

**GET** `/api/BloodBank/{id}`

**Response:**
```json
{
    "donorName": "Anjali Bose",
    "age": 30,
    "bloodType": "O-",
    "contactInfo": "anjali.bose@example.com",
    "quantity": 500,
    "collectionDate": "2024-11-16T16:00:00",
    "expirationDate": "2025-01-16T16:00:00",
    "status": "Available"
}
```

### 3. Create a New Entry
Add a new donor record.

**POST** `/api/BloodBank`

**Request Body:**
```json
{
    "donorName": "Anjali Singh",
    "age": 28,
    "bloodType": "B+",
    "contactInfo": "anjali@example.com",
    "quantity": 450,
    "collectionDate": "2024-11-15T12:00:00",
    "expirationDate": "2025-01-15T12:00:00",
    "status": "Available"
}
```

**Response:**
```json
201 Created
{
    "id": "newly-generated-id",
    "donorName": "Anjali Singh",
    "age": 28,
    "bloodType": "B+",
    "contactInfo": "anjali@example.com",
    "quantity": 450,
    "collectionDate": "2024-11-15T12:00:00",
    "expirationDate": "2025-01-15T12:00:00",
    "status": "Available"
}
```

### 4. Update an Entry
Update an existing donor record by ID.

**PUT** `/api/BloodBank/{id}`

**Request Body:**
```json
{
    "donorName": "Anjali Sharma",
    "age": 29,
    "bloodType": "B+",
    "contactInfo": "anjali@example.com",
    "quantity": 500,
    "collectionDate": "2024-11-20T12:00:00",
    "expirationDate": "2025-01-20T12:00:00",
    "status": "Unavailable"
}
```

**Response:**
```json
204 No Content
```

### 5. Delete an Entry
Delete a donor record by ID.

**DELETE** `/api/BloodBank/{id}`

**Response:**
```json
204 No Content
```

### 6. Search
Search for donor records based on `donorName`, `bloodType`, or `status`.

**GET** `/api/BloodBank/search?donorName=Anjali&bloodType=B+&status=Available`

**Response:**
```json
[
    {
        "id": "5250c7b3-5976-44a7-a1cd-031027a353a0",
        "donorName": "Anjali Singh",
        "age": 28,
        "bloodType": "B+",
        "contactInfo": "anjali@example.com",
        "quantity": 450,
        "collectionDate": "2024-11-15T12:00:00",
        "expirationDate": "2025-01-15T12:00:00",
        "status": "Available"
    }
]
```

## Notes
- Ensure you have **.NET 6 SDK** or later installed.
- You can use **Postman** to test the API.


**Sample Data for testing:**
```json
[
  {
    "donorName": "Aarav Mehta",
    "age": 29,
    "bloodType": "B+",
    "contactInfo": "aarav.mehta@example.com",
    "quantity": 450,
    "collectionDate": "2024-11-15T09:00:00",
    "expirationDate": "2025-01-15T09:00:00",
    "status": "Available"
  },
  {
    "donorName": "Priya Sharma",
    "age": 34,
    "bloodType": "O-",
    "contactInfo": "priya.sharma@example.com",
    "quantity": 500,
    "collectionDate": "2024-11-10T11:00:00",
    "expirationDate": "2025-01-10T11:00:00",
    "status": "Used"
  },
  {
    "donorName": "Rohan Gupta",
    "age": 28,
    "bloodType": "A+",
    "contactInfo": "rohan.gupta@example.com",
    "quantity": 350,
    "collectionDate": "2024-11-12T10:30:00",
    "expirationDate": "2025-01-12T10:30:00",
    "status": "Available"
  },
  {
    "donorName": "Sanya Iyer",
    "age": 31,
    "bloodType": "AB-",
    "contactInfo": "sanya.iyer@example.com",
    "quantity": 400,
    "collectionDate": "2024-11-17T14:00:00",
    "expirationDate": "2025-01-17T14:00:00",
    "status": "Available"
  },
  {
    "donorName": "Karthik Reddy",
    "age": 26,
    "bloodType": "B-",
    "contactInfo": "karthik.reddy@example.com",
    "quantity": 600,
    "collectionDate": "2024-11-16T15:30:00",
    "expirationDate": "2025-01-16T15:30:00",
    "status": "Used"
  },
  {
    "donorName": "Neha Singh",
    "age": 33,
    "bloodType": "O+",
    "contactInfo": "neha.singh@example.com",
    "quantity": 450,
    "collectionDate": "2024-11-14T08:45:00",
    "expirationDate": "2025-01-14T08:45:00",
    "status": "Expired"
  },
  {
    "donorName": "Aditya Patel",
    "age": 27,
    "bloodType": "A-",
    "contactInfo": "aditya.patel@example.com",
    "quantity": 500,
    "collectionDate": "2024-11-18T09:15:00",
    "expirationDate": "2025-01-18T09:15:00",
    "status": "Available"
  },
  {
    "donorName": "Ishita Jain",
    "age": 30,
    "bloodType": "AB+",
    "contactInfo": "ishita.jain@example.com",
    "quantity": 300,
    "collectionDate": "2024-11-19T13:00:00",
    "expirationDate": "2025-01-19T13:00:00",
    "status": "Available"
  },
  {
    "donorName": "Rahul Malhotra",
    "age": 32,
    "bloodType": "O+",
    "contactInfo": "rahul.malhotra@example.com",
    "quantity": 400,
    "collectionDate": "2024-11-13T12:00:00",
    "expirationDate": "2025-01-13T12:00:00",
    "status": "Used"
  },
  {
    "donorName": "Sneha Das",
    "age": 29,
    "bloodType": "B+",
    "contactInfo": "sneha.das@example.com",
    "quantity": 550,
    "collectionDate": "2024-11-20T10:45:00",
    "expirationDate": "2025-01-20T10:45:00",
    "status": "Expired"
  },
  {
    "donorName": "Vikram Chawla",
    "age": 35,
    "bloodType": "A+",
    "contactInfo": "vikram.chawla@example.com",
    "quantity": 350,
    "collectionDate": "2024-11-18T09:45:00",
    "expirationDate": "2025-01-18T09:45:00",
    "status": "Available"
  },
  {
    "donorName": "Anjali Bose",
    "age": 30,
    "bloodType": "O-",
    "contactInfo": "anjali.bose@example.com",
    "quantity": 500,
    "collectionDate": "2024-11-16T16:00:00",
    "expirationDate": "2025-01-16T16:00:00",
    "status": "Available"
  }
]
