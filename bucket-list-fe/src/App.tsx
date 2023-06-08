import logo from "./logo.svg";
import style from "./App.module.scss";
import Login, { User } from "./pages/login/Login";
import {
  BrowserRouter as Router,
  Route,
  Routes,
  BrowserRouter,
} from "react-router-dom";
import Home from "./pages/home/Home";
import React from "react";


function App() {
  const [user, setUser] = React.useState<User | null>(null);
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/home" element={<Home />} />
        <Route path="/" element={<Login setUser={setUser} />} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;
