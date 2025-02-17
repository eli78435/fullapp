import axios from 'axios';
import { API_ENDPOINTS } from '../config/apiConfig';
import { User } from '../models/User';

export const fetchUsers = async (): Promise<User[]> => {
  try {
    const response = await axios.get<User[]>(API_ENDPOINTS.GET_USERS);
    return response.data;
  } catch (error) {
    throw new Error('Error fetching users');
  }
};

export const addUser = async (user: User): Promise<string> => {
  try {
    const response = await axios.post<string>(API_ENDPOINTS.ADD_USER, user);
    return response.data;
  } catch (error) {
    throw new Error('Error adding user');
  }
};