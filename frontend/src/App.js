import React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Home from "./Pages/Home";
import EventDetail from "./Pages/EventDetail";
import EventList from "./Pages/EventList";
import CreateUser from "./Pages/CreateUser"; 

function App() {
    return (
        <Router>
            <Routes>
                <Route path="/" element={<Home />} />
                <Route path="/events" element={<EventList />} />
                <Route path="/event/:id" element={<EventDetail />} />
                <Route path="/register" element={<CreateUser />} />
            </Routes>
        </Router>
    );
}

export default App;
