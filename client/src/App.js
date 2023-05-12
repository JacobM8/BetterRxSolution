import './App.css';
import React from 'react';
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import SearchPage from "./components/SearchPage/SearchPage";
import ProviderDetails from "./components/ProviderDetails/ProviderDetails";


function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<SearchPage />} />
        <Route path="/provider/:id" element={<ProviderDetails />} />
      </Routes>
    </Router>
  );
}

export default App;
