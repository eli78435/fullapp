import React, {FormEventHandler} from 'react';
import {NavLink} from "react-router-dom";
import styles from './AddUser.module.css';

const AddUser: React.FC = () => {
  const [newUser, setNewUser] = React.useState({
    username: '',
    password: '',
    confirmPassword: '',
    email: '',
    role: 'user'
  });

  const handleInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setNewUser({
      ...newUser,
      [e.target.name]: e.target.value
    });
  };

  const saveUser = (e: any) => {
    e.preventDefault();
  };

  return (
    <div className={styles['add-user-container']}>
      <NavLink to='/management/users'>&#8592; User Management</NavLink>
      <h1>Add New User / Group</h1>
      <div className={styles['add-user-form-container']}>
        <form onSubmit={saveUser}>
          <div className={styles['key-value-container']}>
            <label htmlFor="username">Username</label>
            <input type="text" id="username" name="username" onChange={handleInputChange} />
          </div>

          <div className={styles['key-value-container']}>
            <label htmlFor="password">Password</label>
            <input type="password" id="password" name="password" onChange={handleInputChange} />
          </div>

          <div className={styles['key-value-container']}>
            <label htmlFor="confirm-password">Confirm Password</label>
            <input type="password" id="confirm-password" name="confirm-password" onChange={handleInputChange} />
          </div>

          <div className={styles['key-value-container']}>
            <label htmlFor="email">Email</label>
            <input type="email" id="email" name="email" onChange={handleInputChange} />
          </div>

          <div className={styles['key-value-container']}>
            <label htmlFor="role">Role</label>
            <select id="role" name="role">
              <option value="admin">Admin</option>
              <option value="user">User</option>
            </select>
          </div>

          <div className={styles['key-value-container']}>
            <button type="submit" className='button primary'>Add User</button>
          </div>
        </form>
      </div>
    </div>
  );
};

export default AddUser;
