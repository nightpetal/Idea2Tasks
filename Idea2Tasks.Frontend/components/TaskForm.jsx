import "bootstrap/dist/css/bootstrap.min.css";

export default function TaskForm({
  taskForm,
  setTaskForm,
  handleTaskSubmit,
  editingTaskId,
}) {
  return (
    <div className="card shadow-sm mb-4">
      <div className="card-header bg-success text-white">Subtasks</div>

      <div className="card-body">
        <form onSubmit={handleTaskSubmit}>
          <div className="mb-3">
            <label className="form-label">Description</label>
            <input
              className="form-control"
              value={taskForm.description}
              onChange={(e) =>
                setTaskForm({
                  ...taskForm,
                  description: e.target.value,
                })
              }
            />
          </div>

          <div className="mb-3">
            <label className="form-label">Duration (Hours)</label>
            <input
              className="form-control"
              type="number"
              min="1"
              value={taskForm.durationInHrs}
              onChange={(e) =>
                setTaskForm({
                  ...taskForm,
                  durationInHrs: Number(e.target.value),
                })
              }
            />
          </div>

          <div className="form-check mb-3">
            <input
              className="form-check-input"
              type="checkbox"
              checked={taskForm.isCompleted}
              onChange={(e) =>
                setTaskForm({
                  ...taskForm,
                  isCompleted: e.target.checked,
                })
              }
            />
            <label className="form-check-label">Completed</label>
          </div>

          <button className="btn btn-success">
            {editingTaskId ? "Save Subtask" : "Add Subtask"}
          </button>
        </form>
      </div>
    </div>
  );
}
