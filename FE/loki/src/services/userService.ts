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