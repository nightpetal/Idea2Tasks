# API Endpoints

| Method     | Endpoint                             | Description                                                                     |
| ---------- | ------------------------------------ | ------------------------------------------------------------------------------- |
| **POST**   | `/api/Project`                       | Create a new project                                                            |
| **GET**    | `/api/Project`                       | Get all projects                                                                |
| **GET**    | `/api/Project/{id}`                  | Get a project by ID                                                             |
| **PUT**    | `/api/Project/{id}`                  | Update a project by ID                                                          |
| **DELETE** | `/api/Project/{id}`                  | Delete a project by ID                                                          |
| **POST**   | `/api/SubTask?projectId={projectId}` | Create a new subtask (optionally associated with a project via query parameter) |
| **GET**    | `/api/SubTask`                       | Get all subtasks                                                                |
| **GET**    | `/api/SubTask/{id}`                  | Get a subtask by ID                                                             |
| **PUT**    | `/api/SubTask/{id}`                  | Update a subtask by ID                                                          |
| **DELETE** | `/api/SubTask/{id}`                  | Delete a subtask by ID                                                          |
| **GET**    | `/api/SubTask/p/{projectId}`         | Get all subtasks for a specific project                                         |

---

# Project

## Create Project

**POST** `/api/Project`

### Request Body

```json
{
  "name": "string",
  "description": "string",
  "isCompleted": false
}
```

### Response

Returns a `ProjectDTO`.

---

## Get All Projects

**GET** `/api/Project`

### Response

Returns an array of `ProjectDTO`.

---

## Get Project By ID

**GET** `/api/Project/{id}`

### Path Parameters

| Name | Type    | Required |
| ---- | ------- | -------- |
| id   | integer | Yes      |

### Response

Returns a `ProjectDTO`.

---

## Update Project

**PUT** `/api/Project/{id}`

### Path Parameters

| Name | Type    | Required |
| ---- | ------- | -------- |
| id   | integer | Yes      |

### Request Body

```json
{
  "name": "string",
  "description": "string",
  "isCompleted": false
}
```

### Response

Returns the updated `ProjectDTO`.

---

## Delete Project

**DELETE** `/api/Project/{id}`

### Path Parameters

| Name | Type    | Required |
| ---- | ------- | -------- |
| id   | integer | Yes      |

### Response

HTTP 200 OK

---

# SubTask

## Create SubTask

**POST** `/api/SubTask`

### Query Parameters

| Name      | Type    | Required |
| --------- | ------- | -------- |
| projectId | integer | No       |

### Request Body

```json
{
  "description": "string",
  "isCompleted": false,
  "durationInHrs": 0,
  "projectId": 0
}
```

### Response

Returns a `SubTaskDTO`.

---

## Get All SubTasks

**GET** `/api/SubTask`

### Response

Returns an array of `SubTaskDTO`.

---

## Get SubTask By ID

**GET** `/api/SubTask/{id}`

### Path Parameters

| Name | Type    | Required |
| ---- | ------- | -------- |
| id   | integer | Yes      |

### Response

Returns a `SubTaskDTO`.

---

## Update SubTask

**PUT** `/api/SubTask/{id}`

### Path Parameters

| Name | Type    | Required |
| ---- | ------- | -------- |
| id   | integer | Yes      |

### Request Body

```json
{
  "description": "string",
  "isCompleted": false,
  "durationInHrs": 0,
  "projectId": 0
}
```

### Response

Returns the updated `SubTaskDTO`.

---

## Delete SubTask

**DELETE** `/api/SubTask/{id}`

### Path Parameters

| Name | Type    | Required |
| ---- | ------- | -------- |
| id   | integer | Yes      |

### Response

HTTP 200 OK

---

## Get SubTasks By Project

**GET** `/api/SubTask/p/{projectId}`

### Path Parameters

| Name      | Type    | Required |
| --------- | ------- | -------- |
| projectId | integer | Yes      |

### Response

Returns an array of `SubTaskDTO`.

---

# Models

## ProjectOnlyDTO

| Field       | Type              | Required |
| ----------- | ----------------- | -------- |
| name        | string (max 50)   | Yes      |
| description | string (max 1000) | Yes      |
| isCompleted | boolean           | No       |

---

## ProjectDTO

| Field       | Type         |
| ----------- | ------------ |
| id          | integer      |
| name        | string       |
| description | string       |
| isCompleted | boolean      |
| subTasks    | SubTaskDTO[] |

---

## SubTaskDTO

| Field         | Type              |
| ------------- | ----------------- |
| id            | integer           |
| description   | string (max 1000) |
| isCompleted   | boolean           |
| durationInHrs | integer           |
| projectId     | integer           |
