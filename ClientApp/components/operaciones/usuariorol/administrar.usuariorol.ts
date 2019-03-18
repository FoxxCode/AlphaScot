import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_usuariorol {
	idusuario!: string;
	idrolempresa!: number;
	idempresa!: number;
	fecharegistro!: any;
}

@Component
export default class AdministrarUsuarioRolComponent extends Vue {
	public usuariorol = new clase_usuariorol();
	public config = { headers: { 'Content-Type': 'application/json' } };
	public error: string = '';
	operacion = '';

	created() {
	}
	mounted() {
		this.operacion = this.$route.query.operacion.toString();
		if (this.operacion == 'Update') {
			this.usuariorol.idusuario = String(this.$route.query.idusuario);
			this.usuariorol.idrolempresa = Number(this.$route.query.idrolempresa);
			const params = new URLSearchParams();
			params.append('idusuario', this.usuariorol.idusuario.toString());
			params.append('idrolempresa', this.usuariorol.idrolempresa.toString());
			axios.get('api/usuariorol/BuscarUsuarioRol?' + params, this.config).then((res) => {
				this.usuariorol = res.data
			}).catch((err) => {});
		};
	}
	Cancelar(): void {
		this.$router.push({ path: '/usuariorol-consultar' });
	}
	Grabar(): void {
		if (this.operacion == 'Update') {
			axios.put('api/UsuarioRol', this.usuariorol, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Modificado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/usuariorol-consultar' })
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
			axios.post('api/usuariorol', this.usuariorol, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Ingresado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/usuariorol-consultar' })
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
