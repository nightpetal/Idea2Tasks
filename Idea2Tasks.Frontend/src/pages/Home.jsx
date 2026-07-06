import { useEffect, useState } from "react";
import { createProject, getProjects } from "../api/project";
import ProjectCard from "../../components/ProjectCard";

export default function Home({ onNavigate }) {
  const [projects, setProjects] = useState([]);

  const [projectForm, setProjectForm] = useState({
    name: "",
    description: "",
    isCompleted: false,
  });

  async function fetchProjects() {
    const data = await getProjects();
    setProjects(data);
  }

  useEffect(() => {
    fetchProjects();
  }, []);

  async function handleProjectSubmit(event) {
    event.preventDefault();

    const created = await createProject(projectForm);

    setProjects([...projects, created]);

    setProjectForm({
      name: "",
      description: "",
      isCompleted: false,
    });
  }

  function handleProjectClick(id) {
    onNavigate?.("project", id);
  }

  return (
    <div className="container py-5">
      <div className="row">
        {/* Project List */}
        <div className="col-12">
          <h2 className="mb-3 text-start">Projects</h2>

          <div className="row">
            {projects.map((project) => (
              <div className="col-md-12" key={project.id}>
                <ProjectCard
                  project={project}
                  onClick={() => handleProjectClick(project.id)}
                />
              </div>
            ))}

            {projects.length === 0 && (
              <p className="text-muted">No projects found.</p>
            )}
          </div>
        </div>
      </div>
    </div>
  );
}
