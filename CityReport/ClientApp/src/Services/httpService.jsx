import axios from "axios";


const instance = axios.create({});

instance.interceptors.response.use(null, (ex) => {
  if (ex.response) {
    if (ex.response.status === 400) {
      window.location = "/not-found";
    } else {
    
    
    }
  }
  return Promise.reject(ex);
});


export  default {
     get: instance.get,
};