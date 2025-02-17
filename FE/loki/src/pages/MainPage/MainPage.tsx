import React from 'react';
import styles from './MainPage.module.css';
import UsersManagement from '../../components/UsersManagement/UsersManagement';
import {Outlet} from "react-router-dom";
const MainPage: React.FC = () => {
  return (
    <div className={styles['main-page-container']}>
      <div className={styles['nav-bar-container']}></div>
      <div className={styles['content-container']}>
        <div className={styles['main-menu-container']}></div>
        <div className={styles['user-managment-container']}>
          <Outlet />
        </div>
      </div>
    </div>
  );
};

export default MainPage;
