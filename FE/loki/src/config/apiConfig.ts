const API_BASE_URL = process.env.REACT_APP_API_BASE_URL ?? (
  () => { 
    throw new Error('API_BASE_URL is not set'); 
  }
)();

const API_ENDPOINTS = {
  GET_USERS: `${API_BASE_URL}/api/users`
};

export { API_BASE_URL, API_ENDPOINTS };