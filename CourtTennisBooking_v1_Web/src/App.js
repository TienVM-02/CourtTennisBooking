import Router from "./routes/routes";
import "./App.css";
import { ThemeProvider } from "@material-ui/core";

function App() {
  return (
    <ThemeProvider>
      <Router/>
    </ThemeProvider>
  );
}

export default App;
