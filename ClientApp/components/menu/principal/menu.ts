import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class MenuItem {
    constructor(
        public title: string,
        public icon: string,
        public path: string
    ) { };
}
@Component
export default class GeneralComponent extends Vue {
    menuItems: MenuItem[] = [
        new MenuItem('Inicio', 'home', '/principal'),
    ];
    menuParametros: MenuItem[] = [
        new MenuItem('Datos Continente', 'domain', '/continente-consultar'),
        new MenuItem('Datos Paises', 'domain', '/pais-consultar'),
        new MenuItem('Datos Ciudades', 'location_city', '/ciudad-consultar'),
    ];
    menuSalir: MenuItem[] = [
        new MenuItem('Salir', 'exit_to_app', ''),
    ];
    mounted() {
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
}
