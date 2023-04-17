import Vue from 'vue'
import App from './App.vue'
import vuetify from './plugins/vuetify'
import routers from './routers'
import VueCompositionAPI from '@vue/composition-api'
import Motion from '@vueuse/motion'

Vue.config.productionTip = false
Vue.use(VueCompositionAPI)

new Vue({
  vuetify,
  routers,
  VueCompositionAPI,
  Motion,
  render: h => h(App)
}).$mount('#app')
