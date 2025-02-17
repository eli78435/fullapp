import React from 'react';
import './App.css';
import { Routes, Route } from 'react-router-dom';

import MainPage from './pages/MainPage/MainPage';
import LoginPage from "./pages/LoginPage/LoginPage";
import UsersManagement from "./components/UsersManagement/UsersManagement";
import AddUser from "./components/AddUser/AddUser";

function App() {
  return (
    <div className="App">
      <Routes>
        <Route path="/" element={<MainPage />} >
          <Route index element={<UsersManagement />} />
        </Route>

        <Route path="/management" element={<MainPage />} >
          <Route index element={<UsersManagement />} />
          <Route path="users" element={<UsersManagement />} />
          <Route path="addUser" element={<AddUser />} />
        </Route>

        <Route path="/login" element={<LoginPage />} />
      </Routes>
    </div>
  );
}

export default App;
