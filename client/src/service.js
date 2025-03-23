import axios from 'axios';

// הגדרת כתובת בסיס לכל הבקשות
//axios.defaults.baseURL ="https://authserver-hgz5.onrender.com"
axios.defaults.baseURL =process.env.REACT_APP_API_URL

// הוספת interceptor לטיפול בבקשות יוצאות
axios.interceptors.request.use(
  (res) => {
    return res;
  },
  (err) => {
    // רישום השגיאה בקונסול
    console.error(" error in ", err)
    return Promise.reject(err);
  })

// ייצוא אובייקט עם פונקציות
export default {
  getTasks: async () => {
    const result = await axios.get(`/items`)
    return result.data;
  },

  addTask: async (name) => {
    const result = await axios.post(`/items`, { "name": `${name}` })
    return {};
  },

  setCompleted: async (id, isComplete) => {
    const result = await axios.put(`/items/${id}/${isComplete}`);
    return result.data;
  },

  deleteTask: async (id) => {
    const result = await axios.delete(`/items/${id}`)
    return result.data;
  }
};
