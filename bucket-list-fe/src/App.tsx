import logo from "./logo.svg";
import style from "./App.module.scss";
import Login, { User } from "./pages/login/Login";
import {
  BrowserRouter as Router,
  Route,
  Routes,
  BrowserRouter,
} from "react-router-dom";
import HomeAdmin from "./pages/home/admin/HomeAdmin";
import React from "react";

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/home" element={<HomeAdmin />} />
        <Route path="/" element={<Login />} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;
