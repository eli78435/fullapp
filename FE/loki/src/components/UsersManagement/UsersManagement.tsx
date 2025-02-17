import React, { MouseEvent } from 'react';
import styles from './UsersManagement.module.css';
import UserManagementOptions from '../UserManagementOptions/UserManagementOptions';
import UsersList from '../UsersList/UsersList';
import {useNavigate} from "react-router-dom";

const UsersManagement: React.FC = () => {
  const navigate = useNavigate();

  return (
    <div className={styles['users-management-container']}>
      <div className={styles['users-management-header-container']}>
        <div className={styles['users-management-header']}>
          <h2>User Management</h2>
          <button className='button primary' onClick={() => navigate('/management/addUser')}>Add new user / group</button>
        </div>
        <div className={styles['users-management-options-container']}>
          <UserManagementOptions ></UserManagementOptions>
        </div>
      </div>
      <div className={styles['users-management-options']}></div>
      <div className={styles['users-container']}>
        <UsersList />
      </div>
    </div>
  );
};

export default UsersManagement;
