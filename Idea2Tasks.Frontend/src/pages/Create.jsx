import { useState } from "react";
import ProjectForm from "../../components/ProjectForm";
import { createProject } from "../api/project";

export default function Create({ onNavigate }) {
  const [projectForm, setProjectForm] = useState({
    name: "",
    description: "",
    isCompleted: false,
  });

  function handleProjectSubmit(e) {
    e.preventDefault();

    console.log("Submitting...");
    createProject(projectForm).catch(console.error);

    console.log("Navigating...");
    onNavigate?.("home", null);
  }

  return (
    <div className="container py-5">
      <ProjectForm
        projectForm={projectForm}
        setProjectForm={setProjectForm}
        handleProjectSubmit={handleProjectSubmit}
        editingProject={false}
        startProjectEdit={() => {}}
      />
    </div>
  );
}
