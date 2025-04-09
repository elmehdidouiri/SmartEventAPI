import React from 'react';
import { Link } from 'react-router-dom';
import './home.css'; // Assurez-vous de créer ce fichier CSS

const Home = () => {
    return (
        <div className="home-container">
            <h1>Bienvenue sur la plateforme d'événements !</h1>
            <p>Explorez les événements et inscrivez-vous à ceux qui vous intéressent.</p>
            <div className="button-container">
                <Link to="/events" className="nav-button">Voir les événements</Link>
                <Link to="/register" className="nav-button">S'inscrire</Link>
            </div>
        </div>
    );
};

export default Home;