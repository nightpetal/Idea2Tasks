export default function TaskCard({ task }) {
  return (
    <>
      <div className="row g-3">
        <div className="col-12" key={task.id}>
          <div className="card border-0 shadow-sm">
            <div className="card-body d-flex justify-content-between align-items-start">
              <div>
                <p className="mb-1">{task.description}</p>
                <small className="text-muted">⏱ {task.durationInHrs} hrs</small>
              </div>
              <span className="badge bg-primary">Task #{task.id}</span>
            </div>
          </div>
        </div>
      </div>
    </>
  );
}
