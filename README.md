# 🏛️ Confy (Conference Management App)
### Monolithic Architecture

This repository contains the **monolithic version** of a backend application created as part of my master's thesis project focused on **comparing performance between monolithic and microservices architectures**.

📌 **[Click here to see the Microservices version](https://github.com/MichalZdanuk/ConfyMicroservices)**

---

## 📚 Project Overview

This is a simplified MVP backend application that allows conference organizers, lecturers and attendees to:

- Create and manage conferences 📝  
- Add and edit lectures within conferences 🎤  
- Register for events as a participant 🙋
- Receive notifications about registrations and updates related to their conferences 📣
- Authenticate users via email & password 🔐

All functionality is encapsulated within a **single monolithic .NET Web API application**.

---

## 🧠 Part of Master's Thesis

This application is part of my thesis exploring:

> **"Comparison of Monolithic Architecture and Microservices-Based Architecture"**

The application is designed and implemented in two different architectural styles for a direct, hands-on comparison.

---

## 🏗️ Architecture  

This monolithic application follows the principles of **Clean Architecture** and **Domain-Driven Design (DDD)** to ensure scalability, maintainability, and separation of concerns. It also incorporates:  

- **CQRS (Command Query Responsibility Segregation)** – Separates read and write operations to improve performance and maintainability.  
- **Unit of Work Pattern** – Ensures atomic database operations and consistency in transactions. 

![monolithArchitecture](https://github.com/user-attachments/assets/068d01fc-889f-4a14-9612-52611de10938)

*High-level architecture of the monolithic system.* 

---

## 🔧 Technologies Used

### ⚙️ Backend:
- .NET Core Web API
- .NET Class Library
- MediatR
- Entity Framework Core
- Microsoft.AspNetCore.Authentication.JwtBearer
- AspNetCore.HealthChecks
- BCrypt.Net-Next

### 🛢️ Infrastructure:
- MSSQL Server
- Docker

### 🧪 Tools:
- Visual Studio
- Postman
- SSMS (SQL Server Management Studio)
- NBomber (for performance testing)

---

## 🧪 Use Cases for Performance Testing

These are the **six core use cases** selected for benchmarking with [NBomber](https://nbomber.com/):

1. ✅ Create a new conference  
2. ✏️ Edit an existing conference  
3. 🔍 Browse conferences (filters & pagination)  
4. 📄 Get conference details

![use_cases_for_experiments](https://github.com/user-attachments/assets/90c5fc7a-6ffa-410d-89eb-97e634e58d98)

---

## 🏃 How to Run the Application

To run the entire microservices system locally using **Docker**, execute the following commands:

```bash
git clone https://github.com/MichalZdanuk/ConfyMonolith.git
```
```bash
cd ConfyMonolith/src
```
```bash
docker-compose -f docker-compose.yml -f docker-compose.override.yml up
```

**Note:**
- When run manually locally app is available on 5008 (HTTP) and 5058 (HTTPS). When running with Docker: 6008 (HTTP) and 6068 (HTTPS).

---

## 🔗 Related Projects

👉 Check out the [Microservices version here](https://github.com/MichalZdanuk/ConfyMicroservices) for comparison.

👉 Performance analysis can be found here [Performance analysis](https://github.com/MichalZdanuk/ArchitecturesAnalysis).

---

## 📄 License

This project is part of an academic research thesis and intended for educational purposes.
