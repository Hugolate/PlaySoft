import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import vuetify from './plugins/vuetify'
import {MotionPlugin} from '@vueuse/motion'
import VueCompositionAPI from '@vue/composition-api'

Vue.config.productionTip = false
Vue.use(MotionPlugin);

new Vue({
  router,
  store, 
  vuetify,
  MotionPlugin,
  VueCompositionAPI,
  render: h => h(App)
}).$mount('#app')
