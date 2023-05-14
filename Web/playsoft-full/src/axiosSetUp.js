import axios from "axios";
import store from "./store";

export default function axiosSetUp() {
    axios.interceptors.request.use(
        function(config) {
            const token = store.state.token;
            if (token) {
                config.headers.Authorization = `Bearer ${token}`;
            }
            return config;
        },
        function(error) {
            return Promise.reject(error);
        }
    );
}