import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_usuario {
	idusuario!: string;
	idempresa!: number;
	idcomunicacion!: number;
	descripcion!: string;
	encargado!: boolean;
}

@Component
export default class AdministrarUsuarioComponent extends Vue {
	public usuario = new clase_usuario();
	public config = { headers: { 'Content-Type': 'application/json' } };
	public error: string = '';
	operacion = '';

	created() {
	}
	mounted() {
		this.operacion = this.$route.query.operacion.toString();
		if (this.operacion == 'Update') {
			this.usuario.idusuario = String(this.$route.query.idusuario);
			this.usuario.idempresa = Number(this.$route.query.idempresa);
			const params = new URLSearchParams();
			params.append('idusuario', this.usuario.idusuario.toString());
			params.append('idempresa', this.usuario.idempresa.toString());
			axios.get('api/usuario/BuscarUsuario?' + params, this.config).then((res) => {
				this.usuario = res.data
			}).catch((err) => {});
		};
	}
	Cancelar(): void {
		this.$router.push({ path: '/usuario-consultar' });
	}
	Grabar(): void {
		if (this.operacion == 'Update') {
			axios.put('api/Usuario', this.usuario, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Modificado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/usuario-consultar' })
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
			axios.post('api/usuario', this.usuario, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Ingresado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/usuario-consultar' })
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
