import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_usuariointerno {
	idinternousuario!: number;
	idinterno!: string;
	idcentral!: number;
	idusuario!: string;
	idempresa!: number;
	fecharegistro!: any;
}

@Component
export default class AdministrarUsuarioInternoComponent extends Vue {
	public usuariointerno = new clase_usuariointerno();
	public config = { headers: { 'Content-Type': 'application/json' } };
	public error: string = '';
	operacion = '';

	created() {
	}
	mounted() {
		this.operacion = this.$route.query.operacion.toString();
		if (this.operacion == 'Update') {
			this.usuariointerno.idinternousuario = Number(this.$route.query.idinternousuario);
			const params = new URLSearchParams();
			params.append('idinternousuario', this.usuariointerno.idinternousuario.toString());
			axios.get('api/usuariointerno/BuscarUsuarioInterno?' + params, this.config).then((res) => {
				this.usuariointerno = res.data
			}).catch((err) => {});
		};
	}
	Cancelar(): void {
		this.$router.push({ path: '/usuariointerno-consultar' });
	}
	Grabar(): void {
		if (this.operacion == 'Update') {
			axios.put('api/UsuarioInterno', this.usuariointerno, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Modificado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/usuariointerno-consultar' })
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
			axios.post('api/usuariointerno', this.usuariointerno, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Ingresado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/usuariointerno-consultar' })
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
