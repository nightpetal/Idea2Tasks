import request from "./client";

export const getProjects = () => request("/Project");
export const getProjectById = (id) => request(`/Project/${id}`);
export const createProject = (project) =>
  request("/Project", { method: "POST", body: JSON.stringify(project) });
export const updateProject = (id, project) =>
  request(`/Project/${id}`, { method: "PUT", body: JSON.stringify(project) });
export const deleteProject = (id) =>
  request(`/Project/${id}`, { method: "DELETE" });

export const getProjectTasks = (projectId) =>
  request(`/SubTask/p/${projectId}`);
export const createTask = (projectId, task) =>
  request(`/SubTask?projectId=${projectId}`, {
    method: "POST",
    body: JSON.stringify(task),
  });
export const updateTask = (id, task) =>
  request(`/SubTask/${id}`, { method: "PUT", body: JSON.stringify(task) });
export const deleteTask = (id) =>
  request(`/SubTask/${id}`, { method: "DELETE" });
