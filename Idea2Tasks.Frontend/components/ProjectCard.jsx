import "bootstrap/dist/css/bootstrap.min.css";

export default function ProjectCard({ project, onClick }) {
  const isClickable = typeof onClick === "function";

  return (
    <div
      className="card shadow-sm h-100 border-0"
      onClick={isClickable ? onClick : undefined}
      onKeyDown={
        isClickable
          ? (event) => {
              if (event.key === "Enter" || event.key === " ") {
                event.preventDefault();
                onClick();
              }
            }
          : undefined
      }
      role={isClickable ? "button" : undefined}
      tabIndex={isClickable ? 0 : undefined}
      style={isClickable ? { cursor: "pointer" } : undefined}
    >
      <div className="card-body">
        <div className="d-flex justify-content-between align-items-start mb-2">
          <h4 className="card-title mb-0">{project?.name}</h4>

          <span
            className={`badge ${
              project?.isCompleted ? "bg-success" : "bg-warning text-dark"
            }`}
          >
            {project?.isCompleted ? "Completed" : "In Progress"}
          </span>
        </div>

        <p className="card-text text-muted mb-3">
          {project?.description || "No description provided."}
        </p>

        <small className="text-secondary">
          {project?.subTasks?.length || 0} Subtask
          {(project?.subTasks?.length || 0) !== 1 ? "s" : ""}
        </small>
      </div>
    </div>
  );
}
