import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { useParams } from 'react-router-dom';
import './EventDetail.css'; // Importer le fichier CSS

const EventDetail = () => {
    const [event, setEvent] = useState(null);
    const { id } = useParams();

    useEffect(() => {
        const fetchEventDetail = async () => {
            try {
                const response = await axios.get(`https://localhost:7151/api/events/${id}`);
                setEvent(response.data);
            } catch (error) {
                console.error('Error fetching event detail', error);
            }
        };

        fetchEventDetail();
    }, [id]);

    if (!event) return <div>Loading...</div>;

    return (
        <div className="event-detail-container">
            <h2>{event.name}</h2>
            <p>{event.description}</p>
            <p className="event-date">Date: {new Date(event.date).toLocaleDateString()}</p>
            <p className="event-organizer">
                Organisé par: {event.user ? event.user.name : 'Non spécifié'}
            </p>
        </div>
    );
};

export default EventDetail;