import React from 'react';
import styles from './MainPage.module.css';
import UsersManagement from '../../components/UsersManagement/UsersManagement';

const MainPage: React.FC = () => {
    return (
        <div className={styles['main-page-container']}>
            <div className={styles['nav-bar-container']}></div>
            <div className={styles['content-container']}>
                <div className={styles['main-menu-container']}></div>
                <div className={styles['user-managment-container']}>
                    <UsersManagement />
                </div>
            </div>
        </div>
    );
};

export default MainPage;