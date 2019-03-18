import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_contrasenia {
	idusuario!: string;
	fecharegistro!: any;
	clave!: string;
}

@Component
export default class AdministrarContraseniaComponent extends Vue {
	public contrasenia = new clase_contrasenia();
	public config = { headers: { 'Content-Type': 'application/json' } };
	public error: string = '';
	operacion = '';

	created() {
	}
	mounted() {
		this.operacion = this.$route.query.operacion.toString();
		if (this.operacion == 'Update') {
			this.contrasenia.idusuario = String(this.$route.query.idusuario);
			this.contrasenia.fecharegistro = (this.$route.query.fecharegistro);
			const params = new URLSearchParams();
			params.append('idusuario', this.contrasenia.idusuario.toString());
			params.append('fecharegistro', this.contrasenia.fecharegistro.toString());
			axios.get('api/contrasenia/BuscarContrasenia?' + params, this.config).then((res) => {
				this.contrasenia = res.data
			}).catch((err) => {});
		};
	}
	Cancelar(): void {
		this.$router.push({ path: '/contrasenia-consultar' });
	}
	Grabar(): void {
		if (this.operacion == 'Update') {
			axios.put('api/Contrasenia', this.contrasenia, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Modificado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/contrasenia-consultar' })
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
			axios.post('api/contrasenia', this.contrasenia, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Ingresado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/contrasenia-consultar' })
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
