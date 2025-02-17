import React, { useState, useEffect } from 'react';
import styles from './UserManagementOptions.module.css';
import { NavLink } from "react-router-dom";


const UserManagementOptions: React.FC = () => {
  return (
    <div className={styles['options-container']}>
      <NavLink to='/management/users'>Users</NavLink>
      <NavLink to='/management/users'>Roles</NavLink>
      <NavLink to='/management/users'>User Directories</NavLink>
    </div>
  );
}

export default UserManagementOptions;
