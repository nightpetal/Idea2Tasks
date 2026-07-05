import { useState } from "react";
import "./App.css";
import FooterBar from "../shared/FooterBar";
import NavBar from "../shared/NavBar";
import "bootstrap/dist/css/bootstrap.min.css";

import Home from "./pages/Home";
import Project from "./pages/Project";
import About from "./pages/About";
import Create from "./pages/Create";

function App() {
  const [page, setPage] = useState("home");
  const [selectedProjectId, setSelectedProjectId] = useState(null);

  function handleNavigate(page, id = null) {
    setPage(page);
    setSelectedProjectId(id);
  }

  function renderPage() {
    switch (page) {
      case "home":
        return <Home onNavigate={handleNavigate} />;

      case "project":
        return <Project id={selectedProjectId} />;

      case "create":
        return <Create onNavigate={handleNavigate} />;

      case "about":
        return <About />;

      default:
        return <Home onNavigate={handleNavigate} />;
    }
  }

  return (
    <>
      <NavBar onNavigate={handleNavigate} />

      <main className="flex-grow-1">
        <div className="container py-4">{renderPage()}</div>
      </main>

      <FooterBar />
    </>
  );
}

export default App;
