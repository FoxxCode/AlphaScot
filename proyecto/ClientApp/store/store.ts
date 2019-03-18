import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)
const store = new Vuex.Store({
    state: {
        auth: false
    },
    mutations: {
        login(state) {
            state.auth = true;
        },
        logout(state) {
            state.auth = false;
        }
    }
})

export default store;