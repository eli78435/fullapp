import React, { useState, useEffect } from 'react';
import styles from './UserManagementOptions.module.css';


const UserManagementOptions: React.FC = () => {
    return (
        <div className={styles['options-container']}>
            <a href="/users">Users</a>
            <a href="/roles">Roles</a>
            <a href="/userDirectories">User Directories</a>
        </div>
    );
}

export default UserManagementOptions;