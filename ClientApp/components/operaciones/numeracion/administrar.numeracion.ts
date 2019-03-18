import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_numeracion {
	idrango!: number;
	descripcion!: string;
	etiqueta!: string;
	numeroinicio!: string;
	numerofinal!: string;
}

@Component
export default class AdministrarNumeracionComponent extends Vue {
	public numeracion = new clase_numeracion();
	public config = { headers: { 'Content-Type': 'application/json' } };
	public error: string = '';
	operacion = '';

	created() {
	}
	mounted() {
		this.operacion = this.$route.query.operacion.toString();
		if (this.operacion == 'Update') {
			this.numeracion.idrango = Number(this.$route.query.idrango);
			const params = new URLSearchParams();
			params.append('idrango', this.numeracion.idrango.toString());
			axios.get('api/numeracion/BuscarNumeracion?' + params, this.config).then((res) => {
				this.numeracion = res.data
			}).catch((err) => {});
		};
	}
	Cancelar(): void {
		this.$router.push({ path: '/numeracion-consultar' });
	}
	Grabar(): void {
		if (this.operacion == 'Update') {
			axios.put('api/Numeracion', this.numeracion, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Modificado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/numeracion-consultar' })
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
			axios.post('api/numeracion', this.numeracion, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Ingresado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/numeracion-consultar' })
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
