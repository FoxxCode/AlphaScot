import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_usuariodepto {
	idusuariodepto!: number;
	iddepartamento!: string;
	idcargo!: number;
	idempresa!: number;
	idusuario!: string;
	fecharegistro!: any;
}

@Component
export default class AdministrarUsuarioDeptoComponent extends Vue {
	public usuariodepto = new clase_usuariodepto();
	public config = { headers: { 'Content-Type': 'application/json' } };
	public error: string = '';
	operacion = '';

	created() {
	}
	mounted() {
		this.operacion = this.$route.query.operacion.toString();
		if (this.operacion == 'Update') {
			this.usuariodepto.idusuariodepto = Number(this.$route.query.idusuariodepto);
			const params = new URLSearchParams();
			params.append('idusuariodepto', this.usuariodepto.idusuariodepto.toString());
			axios.get('api/usuariodepto/BuscarUsuarioDepto?' + params, this.config).then((res) => {
				this.usuariodepto = res.data
			}).catch((err) => {});
		};
	}
	Cancelar(): void {
		this.$router.push({ path: '/usuariodepto-consultar' });
	}
	Grabar(): void {
		if (this.operacion == 'Update') {
			axios.put('api/UsuarioDepto', this.usuariodepto, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Modificado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/usuariodepto-consultar' })
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
			axios.post('api/usuariodepto', this.usuariodepto, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Ingresado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/usuariodepto-consultar' })
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
