# Idea2Tasks

Turn your ideas into structured projects and actionable tasks with AI. Idea2Tasks consists of an ASP.NET Core Web API backend, a React frontend, and Docker support for running the application in a consistent development environment.

---

## Table of Contents

- [Tech Stack](#tech-stack)
- [API Documentation](#api-documentation)
- [Getting Started](#getting-started)
- [Docker](#docker)

---

## Tech Stack

### Backend

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white) ![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-Web%20API-512BD4?style=for-the-badge&logo=dotnet&logoColor=white) ![Entity Framework Core](https://img.shields.io/badge/Entity%20Framework%20Core-5C2D91?style=for-the-badge&logo=dotnet&logoColor=white) ![SQLite](https://img.shields.io/badge/SQLite-003B57?style=for-the-badge&logo=sqlite&logoColor=white) ![Scalar OpenAPI](https://img.shields.io/badge/OpenAPI-6BA539?style=for-the-badge&logo=openapiinitiative&logoColor=white) ![Google Gemini API](https://img.shields.io/badge/Google%20Gemini-8E75B2?style=for-the-badge&logo=googlegemini&logoColor=white)

### Frontend

![React](https://img.shields.io/badge/React-20232A?style=for-the-badge&logo=react&logoColor=61DAFB)

### DevOps

![Docker](https://img.shields.io/badge/Docker-2496ED?style=for-the-badge&logo=docker&logoColor=white) ![Docker Compose](https://img.shields.io/badge/Docker%20Compose-2496ED?style=for-the-badge&logo=docker&logoColor=white)

---

## API Documentation

Complete API documentation is [available in here](docs/api/endpoints.md).

---

## Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/nightpetal/Idea2Tasks
cd Idea2Tasks
```

### 2. Configuration

Create .env file with your Gemini API key

```
APP_API_KEY=your-api-key-here
```

### 3. Running the Application

Start everything with Docker Compose:

```bash
docker compose up --build
```

Once the containers are running:

- Frontend: `http://localhost:5173`
- Backend API: `http://localhost:8080/scalar`

_(or your configured ports)_

---

## Docker

Build and start the application with Docker Compose:

```bash
docker compose up --build
```

Or run in detached mode:

```bash
docker compose up -d
```

Stop the containers:

```bash
docker compose down
```

---
