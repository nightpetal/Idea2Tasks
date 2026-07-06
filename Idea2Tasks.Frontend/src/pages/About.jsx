import "bootstrap/dist/css/bootstrap.min.css";
import "../App.css";

export default function About() {
  return (
    <div className="container py-5">
      {/* About Me */}
      <div className="text-center mb-5">
        <h1>About Me & Project</h1>
        <p className="text-muted">
          I built this Project Manager to turn ideas into structured tasks using
          AI.
        </p>
      </div>

      {/* How it works */}
      <div className="row g-4">
        <div className="col-md-4">
          <div className="card h-100 shadow-sm card-animated">
            <div className="card-body text-center">
              <h4>Create Idea</h4>
              <p className="text-muted">
                Users enter a project name and description describing what they
                want to build.
              </p>
            </div>
          </div>
        </div>

        <div className="col-md-4">
          <div className="card h-100 shadow-sm card-animated">
            <div className="card-body text-center">
              <h4>Gemini Breakdown</h4>
              <p className="text-muted">
                Google Gemini AI converts the idea into structured subtasks,
                breaking it into step-by-step development tasks.
              </p>
            </div>
          </div>
        </div>

        <div className="col-md-4">
          <div className="card h-100 shadow-sm card-animated">
            <div className="card-body text-center">
              <h4>Build & Track</h4>
              <p className="text-muted">
                Users follow generated subtasks, track progress, and complete
                their project efficiently.
              </p>
            </div>
          </div>
        </div>
      </div>

      {/* Features */}
      <div className="card mt-5 shadow-sm card-animated">
        <div className="card-body">
          <h3 className="mb-3">What This App Does</h3>
          <ul className="mb-0">
            <li>Create projects with a name and description</li>
            <li>Use AI (Gemini) to generate subtasks automatically</li>
            <li>Track progress of each task</li>
            <li>Organize ideas into structured execution steps</li>
            <li>Simple Bootstrap UI for fast productivity</li>
          </ul>
        </div>
      </div>
    </div>
  );
}
