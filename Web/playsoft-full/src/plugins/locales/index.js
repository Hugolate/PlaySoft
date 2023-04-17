import Vue from 'vue'
import VueI18n from 'vue-i18n'
import en from 'en_US.json'
import es from 'es.json'

Vue.use(VueI18n)

export default new VueI18n({
    locale: 'es',
    messages: {
        en: {
            lang: en
        },
        es: {
            lang: es
        }
    }
})