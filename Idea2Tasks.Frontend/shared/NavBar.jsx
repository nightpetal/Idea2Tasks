import { useState } from "react";

export default function NavBar({ onNavigate }) {
  const [expanded, setExpanded] = useState(false);

  function handleNav(page) {
    onNavigate?.(page, null); // reset id when switching pages
    setExpanded(false);
  }

  return (
    <nav className="navbar navbar-expand-lg navbar-dark bg-dark">
      <div className="container">
        <button
          className="navbar-brand btn btn-link text-white text-decoration-none p-0"
          onClick={() => handleNav("home")}
        >
          Idea2Tasks
        </button>

        <button
          className="navbar-toggler"
          type="button"
          onClick={() => setExpanded(!expanded)}
        >
          <span className="navbar-toggler-icon"></span>
        </button>

        <div className={`collapse navbar-collapse ${expanded ? "show" : ""}`}>
          <ul className="navbar-nav me-auto">
            <li className="nav-item">
              <button
                className="nav-link btn btn-link text-white text-decoration-none"
                onClick={() => handleNav("create")}
              >
                Create
              </button>
            </li>

            <li className="nav-item">
              <button
                className="nav-link btn btn-link text-white text-decoration-none"
                onClick={() => handleNav("about")}
              >
                About
              </button>
            </li>
          </ul>
        </div>
      </div>
    </nav>
  );
}
