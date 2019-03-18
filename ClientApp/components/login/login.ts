import Vue from 'vue';
import Component from 'vue-class-component';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_usuario {
    idusuario!: string;
    password!: string;
}

@Component
export default class login extends Vue {
    public login = new clase_usuario();

    public config = { headers: { 'Content-Type': 'application/json' } };
    public response = new Boolean;

    created() {
        if (this.$store.state.auth) {
            this.$router.push({ path: '/usuarios-select' });
        }
    }
    mounted() {
    }
    cancelar(): void {
        this.$router.push({ path: '/' });
    }
    ingresar(): void {
        if (this.login.idusuario == '' || this.login.password == '') {
            swal({
                type: 'error',
                title: 'Llene ambos campos por favor',
                showConfirmButton: false,
                timer: 1500
            })
        } else {
            const params = new URLSearchParams();

            params.append('idusuario', this.login.idusuario);
            params.append('password', this.login.password);

            // Realizar la validacion del Login 

            localStorage.setItem("tipo", "3");
            this.$store.commit('login');
            localStorage.setItem('auth', this.$store.state.auth);
            this.$router.push({ path: '/principal' });
        }
    }
}