import React, { useState } from 'react';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';
import './CreateUser.css'; // Importer le fichier CSS

const CreateUser = () => {
    const [user, setUser] = useState({
        name: '',
        email: '',
        password: '',
    });

    const navigate = useNavigate(); // Utiliser le hook useNavigate

    const handleChange = (e) => {
        setUser({ ...user, [e.target.name]: e.target.value });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const response = await axios.post('https://localhost:7151/api/user', user);
            console.log('User created:', response.data);
            alert('Utilisateur cr�� avec succ�s !'); // Afficher une bo�te de message
            navigate('/events'); // Rediriger vers la page des �v�nements
        } catch (error) {
            console.error('Error creating user:', error);
            alert('Erreur lors de la cr�ation de l\'utilisateur.'); // Afficher une bo�te de message en cas d'erreur
        }
    };

    return (
        <div className="create-user-container">
            <h2>Cr�er un profil utilisateur</h2>
            <form onSubmit={handleSubmit}>
                <input type="text" name="name" value={user.name} onChange={handleChange} placeholder="Nom" />
                <input type="email" name="email" value={user.email} onChange={handleChange} placeholder="Email" />
                <input type="password" name="password" value={user.password} onChange={handleChange} placeholder="Mot de passe" />
                <button type="submit">Cr�er le profil</button>
            </form>
        </div>
    );
};

export default CreateUser;