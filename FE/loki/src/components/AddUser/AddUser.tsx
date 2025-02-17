import React, { FormEventHandler } from 'react';
import { addUser } from '../../services/userService';
import { NavLink, useNavigate } from "react-router-dom";
import styles from './AddUser.module.css';
import { User } from '../../models/User';

const AddUser: React.FC = () => {
  const navigate = useNavigate();

  const [newUser, setNewUser] = React.useState({
    firstName: '',
    lastName: '',
    userName: '',
    email: '',
    password: '',
    role: 'user'
  });
  const [error, setError] = React.useState<string | null>(null);

  const handleInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setNewUser({
      ...newUser,
      [e.target.name]: e.target.value
    });
  };

  const saveUser = async (e: any) => {
    e.preventDefault();

    try {
      const user2Add: User = {
        ...newUser,
        id: ''
      };
      const userId = await addUser(user2Add);
      console.log('User added with id:', userId);
      navigate('/management/users');
    } catch (error) {
        setError('Failed to add user');
    }
  };

  return (
    <div className={styles['add-user-container']}>
      <NavLink to='/management/users'>&#8592; User Management</NavLink>
      <h1>Add New User / Group</h1>
      <div className={styles['add-user-form-container']}>
        <form onSubmit={saveUser}>
          <div className={styles['key-value-container']}>
            <label htmlFor="firstName">First Name</label>
            <input type="text" id="firstName" name="firstName" onChange={handleInputChange} />
          </div>

          <div className={styles['key-value-container']}>
            <label htmlFor="lastName">Last Name</label>
            <input type="text" id="lastName" name="lastName" onChange={handleInputChange} />
          </div>

          <div className={styles['key-value-container']}>
            <label htmlFor="userName">User Name</label>
            <input type="text" id="userName" name="userName" onChange={handleInputChange} />
          </div>

          <div className={styles['key-value-container']}>
            <label htmlFor="password">Password</label>
            <input type="password" id="password" name="password" onChange={handleInputChange} />
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
          {error && <div className={styles['error']}>{error}</div>}
        </form>
      </div>
    </div>
  );
};

export default AddUser;
