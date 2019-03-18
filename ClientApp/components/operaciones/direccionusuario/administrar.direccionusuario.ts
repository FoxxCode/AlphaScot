import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_direccionusuario {
	iddireccion!: number;
	idusuario!: string;
	idzona!: string;
	idciudad!: number;
	idpais!: number;
	descripcion!: string;
	numero!: number;
	pordefecto!: boolean;
}

@Component
export default class AdministrarDireccionUsuarioComponent extends Vue {
	public direccionusuario = new clase_direccionusuario();
	public config = { headers: { 'Content-Type': 'application/json' } };
	public error: string = '';
	operacion = '';

	created() {
	}
	mounted() {
		this.operacion = this.$route.query.operacion.toString();
		if (this.operacion == 'Update') {
			this.direccionusuario.iddireccion = Number(this.$route.query.iddireccion);
			this.direccionusuario.idusuario = String(this.$route.query.idusuario);
			const params = new URLSearchParams();
			params.append('iddireccion', this.direccionusuario.iddireccion.toString());
			params.append('idusuario', this.direccionusuario.idusuario.toString());
			axios.get('api/direccionusuario/BuscarDireccionUsuario?' + params, this.config).then((res) => {
				this.direccionusuario = res.data
			}).catch((err) => {});
		};
	}
	Cancelar(): void {
		this.$router.push({ path: '/direccionusuario-consultar' });
	}
	Grabar(): void {
		if (this.operacion == 'Update') {
			axios.put('api/DireccionUsuario', this.direccionusuario, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Modificado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/direccionusuario-consultar' })
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
			axios.post('api/direccionusuario', this.direccionusuario, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Ingresado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/direccionusuario-consultar' })
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
