	import 'whatwg-fetch';

import Vue from 'vue';
import VueRouter from 'vue-router';
import Vuetify from 'vuetify';

const App =require('./components/app/app.vue');
import store from './store/store';
import colors from 'vuetify/es5/util/colors'

Vue.use(VueRouter);
Vue.use(Vuetify, {
    theme: {
        primary: colors.grey.darken3,
        secondary: colors.teal.darken4,
        accent: colors.indigo.base,
        error: '#FF5252',
        info: '#2196F3',
        success: '#4CAF50',
        warning: '#FFC107'
    }
});

const routes = [
    { path: '/', component: require('./components/inicio/inicio.vue') },
    { path: '/principal', component: require('./components/principal/principal.vue') },
    { path: '/login', component: require('./components/login/login.vue') },
	{ path: '/paises-consultar', component: require('./components/operaciones/paises/consultar.paises.vue') },
	{ path: '/paises-administrar', component: require('./components/operaciones/paises/administrar.paises.vue') },
	{ path: '/ciudades-consultar', component: require('./components/operaciones/ciudades/consultar.ciudades.vue') },
	{ path: '/ciudades-administrar', component: require('./components/operaciones/ciudades/administrar.ciudades.vue') },
];

const router = new VueRouter({ mode: 'history', routes: routes })
new Vue({
    el: '#app-root',
    router,
    render: h => h(App),
    store,
    data: {
        auth: false
    },
    created() {
        if (localStorage.auth == "true") {
            this.$store.commit('login');
        }
    },
    methods: {
        loginLS() {
            localStorage.auth = this.auth;
        }
    }
});

