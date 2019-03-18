import Vue from 'vue';
import axios from 'axios';
import Component from 'vue-class-component';
import colors from 'vuetify/es5/util/colors'
import Vuetify from 'vuetify';
import VueRouter from 'vue-router';
import swal from 'sweetalert2';

@Component({
    components: {
        MenuComponentUsuario: require('../menu/principal/menu.vue')
    }
})
export default class AppComponent extends Vue {
    drawer: boolean = true;

    mounted() {
    }
    onMenuItemClick(){
        console.log(event)
    }
    created () {
        this.$store.commit('logout');
        localStorage.setItem('auth', this.$store.state.auth);
    }
    tipo_login() {
        return localStorage.getItem('tipo');
    }
    logout() {
        swal({
            title: 'Aplicacion',
            text: "Esta seguro de salir del Sistema?",
            type: 'warning',
            showCancelButton: true,
            confirmButtonColor: 'green',
            cancelButtonColor: 'red',
            cancelButtonText: 'Cancelar',
            confirmButtonText: 'Aceptar!'
        }).then((result) => {
            if (result.value) {
                this.$store.commit('logout');
                localStorage.setItem('auth', this.$store.state.auth);
                this.$router.push({ path: '/' });
            }
            })
    }
    inicio() {
        this.$router.push({ path: '/' });
    }
    Login() {
        this.$router.push({ path: '/login' });
    }
}
