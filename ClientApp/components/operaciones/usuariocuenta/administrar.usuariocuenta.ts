import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_usuariocuenta {
	idusuariocuenta!: number;
	idcuenta!: string;
	idcentral!: number;
	idusuario!: string;
	idempresa!: number;
	fecharegistro!: any;
}

@Component
export default class AdministrarUsuarioCuentaComponent extends Vue {
	public usuariocuenta = new clase_usuariocuenta();
	public config = { headers: { 'Content-Type': 'application/json' } };
	public error: string = '';
	operacion = '';

	created() {
	}
	mounted() {
		this.operacion = this.$route.query.operacion.toString();
		if (this.operacion == 'Update') {
			this.usuariocuenta.idusuariocuenta = Number(this.$route.query.idusuariocuenta);
			const params = new URLSearchParams();
			params.append('idusuariocuenta', this.usuariocuenta.idusuariocuenta.toString());
			axios.get('api/usuariocuenta/BuscarUsuarioCuenta?' + params, this.config).then((res) => {
				this.usuariocuenta = res.data
			}).catch((err) => {});
		};
	}
	Cancelar(): void {
		this.$router.push({ path: '/usuariocuenta-consultar' });
	}
	Grabar(): void {
		if (this.operacion == 'Update') {
			axios.put('api/UsuarioCuenta', this.usuariocuenta, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Modificado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/usuariocuenta-consultar' })
				}).catch((err) => {
						swal({
							type: 'error',
							title: err.response.data,
							showConfirmButton: false,
							timer: 2000
					})
				})
		}
		else {
			axios.post('api/usuariocuenta', this.usuariocuenta, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Ingresado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/usuariocuenta-consultar' })
				}).catch((err) => {
						swal({
							type: 'error',
							title: err.response.data,
							showConfirmButton: false,
							timer: 2000
					})
				})
		}
	}
}
