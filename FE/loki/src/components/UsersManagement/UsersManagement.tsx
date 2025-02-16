import React, { MouseEvent } from 'react';
import styles from './UsersManagement.module.css';
import UserManagementOptions from '../UserManagementOptions/UserManagementOptions';
import UsersList from '../UsersList/UsersList';

const UsersManagement: React.FC = () => {
    const addNewUserOrGroup = async ( event: MouseEvent<HTMLButtonElement>) => {
        // try {
        //     const data = await addUsers();
        //     setUsers(data);
        //     setLoading(false);
        // } catch (error) {
        //     console.error('Error fetching users:', error);
        //     setLoading(false);
        // }
    };

    return (
        <div className={styles['users-management-container']}>
            <div className={styles['users-management-header-container']}>
                <div className={styles['users-management-header']}>
                    <h2>User Management</h2>
                    <button className='button primary' onClick={addNewUserOrGroup}>Add new user / group</button>
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