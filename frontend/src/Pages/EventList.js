import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import './EventList.css'; // Importer le fichier CSS

const EventList = () => {
    const [events, setEvents] = useState([]);
    const userId = localStorage.getItem('userId'); // Récupérer l'ID de l'utilisateur depuis le localStorage

    useEffect(() => {
        const fetchEvents = async () => {
            try {
                const response = await fetch('https://localhost:7151/api/events'); // Ajuste l'URL selon ton backend
                if (!response.ok) {
                    throw new Error('Network response was not ok');
                }
                const data = await response.json();
                const eventsData = data.$values; // Extraire la liste des événements
                setEvents(eventsData);
            } catch (error) {
                console.error('Error fetching events', error);
            }
        };

        fetchEvents();
    }, []);

    const handleRegister = async (eventId) => {
        if (!userId) {
            alert('Vous devez être connecté pour vous inscrire à un événement.');
            return;
        }

        const confirm = window.confirm("Voulez-vous vous inscrire à cet événement ?");
        if (confirm) {
            try {
                const registration = {
                    userId: parseInt(userId, 10), // Convertir en entier
                    eventId: eventId
                };
                const response = await fetch('https://localhost:7151/api/registration', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify(registration)
                });
                if (!response.ok) {
                    throw new Error('Network response was not ok');
                }
                const data = await response.json();
                alert('Inscription réussie !');
                console.log('Registration successful:', data);
            } catch (error) {
                console.error('Error registering for event:', error);
                alert('Erreur lors de l\'inscription à l\'événement.');
            }
        }
    };

    return (
        <div className="event-list-container">
            <h2>Liste des événements</h2>
            <ul>
                {events.map(event => (
                    <li key={event.id}>
                        <Link to={`/event/${event.id}`}>{event.name}</Link>
                        <button onClick={() => handleRegister(event.id)}>Register</button>
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default EventList;