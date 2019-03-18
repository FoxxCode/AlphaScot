import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_comunicacionusuario {
	idcomunicacion!: number;
	idtipocomunicacion!: string;
	valor!: string;
	pordefecto!: boolean;
}

@Component
export default class AdministrarComunicacionUsuarioComponent extends Vue {
	public comunicacionusuario = new clase_comunicacionusuario();
	public config = { headers: { 'Content-Type': 'application/json' } };
	public error: string = '';
	operacion = '';

	created() {
	}
	mounted() {
		this.operacion = this.$route.query.operacion.toString();
		if (this.operacion == 'Update') {
			this.comunicacionusuario.idcomunicacion = Number(this.$route.query.idcomunicacion);
			const params = new URLSearchParams();
			params.append('idcomunicacion', this.comunicacionusuario.idcomunicacion.toString());
			axios.get('api/comunicacionusuario/BuscarComunicacionUsuario?' + params, this.config).then((res) => {
				this.comunicacionusuario = res.data
			}).catch((err) => {});
		};
	}
	Cancelar(): void {
		this.$router.push({ path: '/comunicacionusuario-consultar' });
	}
	Grabar(): void {
		if (this.operacion == 'Update') {
			axios.put('api/ComunicacionUsuario', this.comunicacionusuario, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Modificado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/comunicacionusuario-consultar' })
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
			axios.post('api/comunicacionusuario', this.comunicacionusuario, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Ingresado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/comunicacionusuario-consultar' })
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
