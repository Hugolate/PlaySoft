import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import vuetify from './plugins/vuetify'
import { MotionPlugin } from '@vueuse/motion'
import VueCompositionAPI from '@vue/composition-api'
import axiosSetUp from "./axiosSetUp";
import { BootstrapVue } from 'bootstrap-vue'
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'

axiosSetUp();
Vue.config.productionTip = false
Vue.use(MotionPlugin);
Vue.use(BootstrapVue);

new Vue({
    router,
    store,
    vuetify,
    MotionPlugin,
    VueCompositionAPI,
    render: h => h(App)
}).$mount('#app')