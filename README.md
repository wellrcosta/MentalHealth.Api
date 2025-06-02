# 🧠 MentalHealth.Api

**MentalHealth.Api** is an MVP RESTful API designed to track and support the mental well-being of employees through periodic emotional check-ins. It allows companies to register employees, record their daily sentiment, and monitor emotional trends.

---

## 📌 Purpose

This API helps companies:

* Collect employee check-ins for emotional health tracking
* Associate employees with specific teams and companies
* Analyze emotional trends over the last 7 days per employee

---

## 🚀 Base URL

```
http://localhost:5000/swagger/index.html
```
 You can edit the base URL in the `launchSettings.json` file located in `/Properties/launchSettings.json`.

---

## 📂 Endpoints

### ✅ Create a Check-in

**POST** `/v1/Checkins`

Registers a new emotional check-in for an employee.

#### Request Body

```json
{
  "employeeId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "sentiment": 0,
  "notes": "string"
}
```

#### Response Example

```json
{
  "id": "01973220-5e98-7b3d-ad19-cc5b373d7a0a",
  "sentiment": 0,
  "notes": "string",
  "createdAt": "2025-06-02T19:31:11.639861Z",
  "employeeName": "Reis",
  "employeeEmail": "string"
}
```

---

### 📊 Get Last 7 Days of Check-ins

**GET** `/v1/Checkins/last7days/{employeeId}`

#### Response Example

```json
[
  {
    "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "sentiment": 0,
    "notes": "string",
    "createdAt": "2025-06-02T19:29:57.560Z",
    "employeeName": "string",
    "employeeEmail": "string"
  }
]
```

---

### 🏢 Create a Company

**POST** `/v1/Companies`

#### Request Body

```json
{
  "name": "string"
}
```

---

### 🔍 Get Company by ID

**GET** `/v1/Companies/{id}`

---

### 👤 Register a New Employee

**POST** `/v1/Employees`

#### Request Body

```json
{
  "name": "string",
  "email": "string",
  "team": "string",
  "role": "string",
  "companyId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "acceptedTermsAt": "2025-06-02T19:32:07.194Z",
  "acceptedPrivacyAt": "2025-06-02T19:32:07.194Z"
}
```

---

### 👁️ Get Employee by ID

**GET** `/v1/Employees/{id}`

---

## 🛠️ How to Run Locally

1. **Clone the repository:**

```bash
git clone https://github.com/yourusername/mentalhealth-api.git
cd mentalhealth-api
```

2. **Configure the `appsettings.json`:**

Update the file located in `./src/MentalHealth.Api/appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=mentalhealth;Username=mentalhealth;Password=mentalhealth"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "Loki": {
    "Url": "http://localhost:3001"
  },
  "Serilog": {
    "MinimumLevel": "Information"
  }
}
```

3. **Run database migrations:**

Ensure you have the PostgreSQL server running, then apply the Entity Framework Core migrations:

```bash
dotnet ef database update --project src/MentalHealth.Infrastructure --startup-project src/MentalHealth.Api
```

4. **Run the API:**

```bash
dotnet run --project src/MentalHealth.Api
```

The API should be available at:

```
http://localhost:5000/v1/
```

---

## 📦 Technologies

* .NET 8
* Entity Framework Core
* PostgreSQL
* Serilog + Loki
