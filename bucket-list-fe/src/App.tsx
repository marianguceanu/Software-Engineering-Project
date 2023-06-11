import Login from "./pages/login/Login";
import { Route, Routes, BrowserRouter } from "react-router-dom";
import HomeAdmin from "./pages/home/admin/HomeAdmin";
import HomeUser from "./pages/home/user/HomeUser";

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/home/admin" element={<HomeAdmin />} />
        <Route path="/home/user" element={<HomeUser />} />
        <Route path="/" element={<Login />} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;
