# 🏛️ Confy = Conference Management App – Monolithic Architecture

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
5. ➕ Add a lecture to a conference  
6. 🛠️ Edit a lecture

![UseCases](https://github.com/user-attachments/assets/87e04e46-9f95-477b-a9ad-9b20c13301e7)

---

## 🔗 Related Projects

👉 Check out the [Microservices version here](https://github.com/MichalZdanuk/ConfyMicroservices) for comparison.

---

## 📄 License

This project is part of an academic research thesis and intended for educational purposes.
