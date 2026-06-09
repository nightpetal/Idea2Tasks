# Idea2Tasks

This API helps turn your ideas into tasks, making it easy to organize and manage your work efficiently.

---

## Table of Contents

- [Overview](#overview)
- [Getting Started](#getting-started)
- [Endpoints](#endpoints)
- [Swagger](#swagger)
- [Examples](#examples)
- [License](#license)

---

## Overview

The Idea2Tasks API is designed to facilitate the conversion of ideas into manageable tasks and projects, streamlining work organization. It provides endpoints for creating, retrieving, updating, and deleting projects and subtasks, making it versatile for various project management needs.

---

## Getting Started

1. Dependencies:
    - `Microsoft.EntityFrameworkCore`
    - `Microsoft.EntityFrameworkCore.Sqlite`
    - `Microsoft.EntityFrameworkCore.Design`
    - `Swashbuckle.AspNetCore.SwaggerUI`
    - `Swashbuckle.AspNetCore.SwaggerGen`
    
    Install them via CLI:
    ```bash
    dotnet add package Microsoft.EntityFrameworkCore
    dotnet add package Microsoft.EntityFrameworkCore.Sqlite
    dotnet add package Microsoft.EntityFrameworkCore.Design
    dotnet add package Swashbuckle.AspNetCore.SwaggerUI
    dotnet add package Swashbuckle.AspNetCore.SwaggerGen
    ```

2. Environment Variables:
Get your Gemini API key at [Google Dev](https://ai.google.dev/gemini-api/docs/api-key)
    ```bash
    dotnet user-secrets init
    dotnet user-secrets set "AppSettings:ApiKey" "your-secret-api-key"
    ```

3. Database Configuration:

    ```bash
    dotnet ef migrations add InitialCreate
    dotnet ef database update
    ```

4. Installation steps

    ```bash
    git clone https://github.com/nightpetal/Idea2Tasks
    cd Idea2Tasks
    dotnet restore
    ```

5. Running the server

    ```bash
    dotnet run --project Idea2Tasks.csproj
    ```

5. Swagger UI

    ```bash
    http://localhost:5202/swagger
    ```

---

## Endpoints

- **GET `/api/Project`**: Retrieves a list of projects.
- **POST `/api/Project`**: Creates a new project (send JSON body).
- **GET `/api/Project/{id}`**: Gets details of a specific project by ID.
- **PUT `/api/Project/{id}`**: Updates a project by ID (send JSON body).
- **DELETE `/api/Project/{id}`**: Deletes a project by ID.
- **GET `/api/project/{projectId}/SubTask`**: Lists subtasks for a project.
- **POST `/api/project/{projectId}/SubTask`**: Adds a subtask to a project (send JSON body).
- **GET `/api/SubTask`**: Lists all subtasks.
- **GET `/api/SubTask/{id}`**: Gets a subtask by ID.
- **PUT `/api/project/{projectId}/SubTask/{id}`**: Updates a subtask.
- **DELETE `/api/project/{projectId}/SubTask/{id}`**: Deletes a subtask.

Both project and subtask requests include request bodies in JSON format, and responses typically return a status code 200 for success.

---

## Swagger

<details>
<summary>View More</summary>

### GET `/api/Project`

**Tags:** `Project`

**Responses**

| Code  | Description |
| ----- | ----------- |
| `200` | OK          |

---

### POST `/api/Project`

**Tags:** `Project`

**Request Body**

Content-Type: `application/json`

_See [ProjectDTO](#schemas)_

Content-Type: `text/json`

_See [ProjectDTO](#schemas)_

Content-Type: `application/*+json`

_See [ProjectDTO](#schemas)_

**Responses**

| Code  | Description |
| ----- | ----------- |
| `200` | OK          |

---

### GET `/api/Project/{id}`

**Tags:** `Project`

**Parameters**

| Name | In   | Type      | Required | Description |
| ---- | ---- | --------- | -------- | ----------- |
| `id` | path | `integer` | ✓        |             |

**Responses**

| Code  | Description |
| ----- | ----------- |
| `200` | OK          |

---

### PUT `/api/Project/{id}`

**Tags:** `Project`

**Parameters**

| Name | In   | Type      | Required | Description |
| ---- | ---- | --------- | -------- | ----------- |
| `id` | path | `integer` | ✓        |             |

**Request Body**

Content-Type: `application/json`

_See [ProjectDTO](#schemas)_

Content-Type: `text/json`

_See [ProjectDTO](#schemas)_

Content-Type: `application/*+json`

_See [ProjectDTO](#schemas)_

**Responses**

| Code  | Description |
| ----- | ----------- |
| `200` | OK          |

---

### DELETE `/api/Project/{id}`

**Tags:** `Project`

**Parameters**

| Name | In   | Type      | Required | Description |
| ---- | ---- | --------- | -------- | ----------- |
| `id` | path | `integer` | ✓        |             |

**Responses**

| Code  | Description |
| ----- | ----------- |
| `200` | OK          |

---

### GET `/api/project/{projectId}/SubTask`

**Tags:** `SubTask`

**Parameters**

| Name        | In   | Type      | Required | Description |
| ----------- | ---- | --------- | -------- | ----------- |
| `projectId` | path | `integer` | ✓        |             |

**Responses**

| Code  | Description |
| ----- | ----------- |
| `200` | OK          |

---

### POST `/api/project/{projectId}/SubTask`

**Tags:** `SubTask`

**Parameters**

| Name        | In   | Type      | Required | Description |
| ----------- | ---- | --------- | -------- | ----------- |
| `projectId` | path | `integer` | ✓        |             |

**Request Body**

Content-Type: `application/json`

_See [SubTaskDTO](#schemas)_

Content-Type: `text/json`

_See [SubTaskDTO](#schemas)_

Content-Type: `application/*+json`

_See [SubTaskDTO](#schemas)_

**Responses**

| Code  | Description |
| ----- | ----------- |
| `200` | OK          |

---

### GET `/api/SubTask`

**Tags:** `SubTask`

**Responses**

| Code  | Description |
| ----- | ----------- |
| `200` | OK          |

---

### GET `/api/SubTask/{id}`

**Tags:** `SubTask`

**Parameters**

| Name | In   | Type      | Required | Description |
| ---- | ---- | --------- | -------- | ----------- |
| `id` | path | `integer` | ✓        |             |

**Responses**

| Code  | Description |
| ----- | ----------- |
| `200` | OK          |

---

### PUT `/api/project/{projectId}/SubTask/{id}`

**Tags:** `SubTask`

**Parameters**

| Name        | In   | Type      | Required | Description |
| ----------- | ---- | --------- | -------- | ----------- |
| `id`        | path | `integer` | ✓        |             |
| `projectId` | path | `string`  | ✓        |             |

**Request Body**

Content-Type: `application/json`

_See [SubTaskDTO](#schemas)_

Content-Type: `text/json`

_See [SubTaskDTO](#schemas)_

Content-Type: `application/*+json`

_See [SubTaskDTO](#schemas)_

**Responses**

| Code  | Description |
| ----- | ----------- |
| `200` | OK          |

---

### DELETE `/api/project/{projectId}/SubTask/{id}`

**Tags:** `SubTask`

**Parameters**

| Name        | In   | Type      | Required | Description |
| ----------- | ---- | --------- | -------- | ----------- |
| `id`        | path | `integer` | ✓        |             |
| `projectId` | path | `string`  | ✓        |             |

**Responses**

| Code  | Description |
| ----- | ----------- |
| `200` | OK          |

---

### Schemas

### ProjectDTO

| Field         | Type                                  | Required | Description |
| ------------- | ------------------------------------- | -------- | ----------- |
| `name`        | `string`                              | ✓        |             |
| `description` | `string`                              | ✓        |             |
| `isCompleted` | `boolean`                             | ✓        |             |
| `subTasks`    | array of _See [SubTaskDTO](#schemas)_ |          |             |

### SubTaskDTO

| Field         | Type      | Required | Description |
| ------------- | --------- | -------- | ----------- |
| `id`          | `integer` |          |             |
| `description` | `string`  | ✓        |             |
| `isCompleted` | `boolean` | ✓        |             |
| `duration`    | `integer` | ✓        |             |
| `projectId`   | `integer` |          |             |

</details>

---

## Examples

#### Request

<details>
<summary>Curl Example (View More):</summary>

```
curl -X POST "http://localhost:5202/api/Project" \
  -H "accept: text/plain" \
  -H "Content-Type: application/json" \
  -d '{
    "name": "Connection",
    "description": "Connect frontend with ASP .NET Core backend",
    "isCompleted": true,
    "subTasks": [
      {
        "id": 0,
        "description": "string",
        "isCompleted": true,
        "duration": 0,
        "projectId": 0
      }
    ]
  }'
```

</details>

#### Response

HTTP Status Code: 200 OK
Content-Type: application/json

<details>
<summary>Response Body (View More):</summary>

```
{
  "name": "Connection",
  "description": "Connect frontend with ASP .NET Core backend",
  "isCompleted": true,
  "subTasks": [
    {
      "id": 1,
      "description": "Configure CORS policy in ASP.NET Core Program.cs to allow incoming requests from the frontend origin",
      "isCompleted": false,
      "duration": 45,
      "projectId": 1
    },
    {
      "id": 2,
      "description": "Set up HTTP client (Axios or Fetch) with base URL and global interceptors in the frontend application",
      "isCompleted": false,
      "duration": 60,
      "projectId": 1
    },
    {
      "id": 3,
      "description": "Define environment variables for API connection strings in both development and production environments",
      "isCompleted": false,
      "duration": 45,
      "projectId": 1
    },
    {
      "id": 4,
      "description": "Implement JWT authentication flow, including backend token generation and frontend storage in cookies or localStorage",
      "isCompleted": false,
      "duration": 180,
      "projectId": 1
    },
    {
      "id": 5,
      "description": "Create backend Data Transfer Objects (DTOs) and map them to frontend TypeScript interfaces",
      "isCompleted": false,
      "duration": 90,
      "projectId": 1
    },
    {
      "id": 6,
      "description": "Integrate data fetching services in the frontend to retrieve and display data from an ASP.NET Core GET endpoint",
      "isCompleted": false,
      "duration": 120,
      "projectId": 1
    },
    {
      "id": 7,
      "description": "Implement form submission in the frontend and connect it to an ASP.NET Core POST endpoint with validation mapping",
      "isCompleted": false,
      "duration": 120,
      "projectId": 1
    },
    {
      "id": 8,
      "description": "Set up global exception handling middleware on the backend and friendly error alerts on the frontend",
      "isCompleted": false,
      "duration": 90,
      "projectId": 1
    },
    {
      "id": 9,
      "description": "Perform end-to-end integration testing to verify API routing, payload formats, and status codes",
      "isCompleted": false,
      "duration": 120,
      "projectId": 1
    }
  ]
}

```

</details>

---

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---
