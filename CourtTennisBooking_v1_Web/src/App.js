import AppRouter from "./routes/routes";
import "./App.css";
import { ThemeProvider } from "@material-ui/core";
// import {BrowserRouter as Router } from "react-router-dom";

function App() {
  return (
    <ThemeProvider>
      {/* <Router> */}
        <AppRouter />
      {/* </Router> */}

    </ThemeProvider>
  );
}

export default App;
