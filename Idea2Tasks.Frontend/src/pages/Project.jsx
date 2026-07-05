import "bootstrap/dist/css/bootstrap.min.css";
import { useEffect, useState } from "react";
import { getProjectById } from "../api/project";
import ProjectCard from "../../components/ProjectCard";
import TaskCard from "../../components/TaskCard";
import "bootstrap/dist/js/bootstrap.bundle.min.js";

export default function Project({ id }) {
  const [project, setProject] = useState(null);

  async function fetchProject() {
    if (!id) return;

    const data = await getProjectById(id);
    setProject(data);
  }

  useEffect(() => {
    fetchProject();
  }, [id]);

  if (!id) {
    return <p className="text-center mt-5">No project selected</p>;
  }

  if (!project) {
    return <p className="text-center mt-5">Loading...</p>;
  }

  return (
    <div className="container py-5">
      <h1 className="text-center mb-5 fw-bold">Project Details</h1>

      <div className="card shadow-sm border-0">
        <div className="card-body">
          <ProjectCard project={project} />

          <button
            className="btn btn-outline-dark w-100 mt-3"
            type="button"
            data-bs-toggle="collapse"
            data-bs-target={`#tasks-${project.id}`}
          >
            View Subtasks ({project.subTasks?.length || 0})
          </button>

          <div className="collapse mt-3" id={`tasks-${project.id}`}>
            <h3 className="mb-3">SubTasks</h3>

            {project.subTasks?.length > 0 ? (
              <div className="row g-3">
                {project.subTasks.map((task) => (
                  <div className="col-12" key={task.id}>
                    <div className="card border">
                      <div className="card-body">
                        <TaskCard task={task} />
                      </div>
                    </div>
                  </div>
                ))}
              </div>
            ) : (
              <p className="text-muted mb-0">No subtasks available.</p>
            )}
          </div>
        </div>
      </div>
    </div>
  );
}
