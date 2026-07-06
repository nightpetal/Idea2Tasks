import "bootstrap/dist/css/bootstrap.min.css";

export default function ProjectForm({
  projectForm,
  setProjectForm,
  handleProjectSubmit,
  editingProject,
  startProjectEdit,
}) {
  return (
    <div className="card shadow-sm border-0">
      <div className="card-header bg-dark text-white">
        <h5 className="mb-0">
          {editingProject ? "Edit Project" : "Create Project"}
        </h5>
      </div>

      <div className="card-body p-4">
        <form onSubmit={handleProjectSubmit}>
          {/* Project Name */}
          <div className="mb-3">
            <label className="form-label fw-semibold">Project Name</label>
            <input
              className="form-control"
              placeholder="Enter project name"
              value={projectForm.name}
              onChange={(e) =>
                setProjectForm({
                  ...projectForm,
                  name: e.target.value,
                })
              }
              required
            />
          </div>

          {/* Description */}
          <div className="mb-3">
            <label className="form-label fw-semibold">Description</label>
            <textarea
              className="form-control"
              rows={4}
              placeholder="Describe your project..."
              value={projectForm.description}
              onChange={(e) =>
                setProjectForm({
                  ...projectForm,
                  description: e.target.value,
                })
              }
            />
          </div>

          {/* Completed */}
          <div className="form-check mb-4">
            <input
              className="form-check-input"
              type="checkbox"
              id="completed"
              checked={projectForm.isCompleted}
              onChange={(e) =>
                setProjectForm({
                  ...projectForm,
                  isCompleted: e.target.checked,
                })
              }
            />
            <label className="form-check-label" htmlFor="completed">
              Mark as completed
            </label>
          </div>

          {/* Buttons */}
          <div className="d-flex gap-2">
            {editingProject && (
              <button
                type="button"
                className="btn btn-outline-secondary w-50"
                onClick={startProjectEdit}
              >
                Reset Edit
              </button>
            )}

            <button className="btn btn-dark w-100" type="submit">
              {editingProject ? "Save Changes" : "Create Project"}
            </button>
          </div>
        </form>
      </div>
    </div>
  );
}
