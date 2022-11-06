import React from 'react';
import styles from './price-card.module.css';

interface Props {
    serviceStation: string;
    location: string;
    dieselPrice: number;
    petrolPrice: number;
    dateTimeAdded: string;
}

const PriceCard = () => {
    return (
        <div className={styles.priceCard}>
            <p>Circle K</p>
            <p>Hinna</p>
            <p>24.6</p>
            <p>22.9</p>
            <p>05.11.2022, 18.34</p>
        </div>
    );
};

export default PriceCard;
