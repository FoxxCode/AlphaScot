import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_servicionumeracion {
	idrango!: number;
	idservicio!: number;
	idciudad!: number;
	idpais!: number;
	descripcion!: string;
	etiqueta!: string;
	numeroinicio!: string;
	numerofinal!: string;
}

@Component
export default class AdministrarServicioNumeracionComponent extends Vue {
	public servicionumeracion = new clase_servicionumeracion();
	public config = { headers: { 'Content-Type': 'application/json' } };
	public error: string = '';
	operacion = '';

	created() {
	}
	mounted() {
		this.operacion = this.$route.query.operacion.toString();
		if (this.operacion == 'Update') {
			this.servicionumeracion.idrango = Number(this.$route.query.idrango);
			this.servicionumeracion.idservicio = Number(this.$route.query.idservicio);
			const params = new URLSearchParams();
			params.append('idrango', this.servicionumeracion.idrango.toString());
			params.append('idservicio', this.servicionumeracion.idservicio.toString());
			axios.get('api/servicionumeracion/BuscarServicioNumeracion?' + params, this.config).then((res) => {
				this.servicionumeracion = res.data
			}).catch((err) => {});
		};
	}
	Cancelar(): void {
		this.$router.push({ path: '/servicionumeracion-consultar' });
	}
	Grabar(): void {
		if (this.operacion == 'Update') {
			axios.put('api/ServicioNumeracion', this.servicionumeracion, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Modificado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/servicionumeracion-consultar' })
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
			axios.post('api/servicionumeracion', this.servicionumeracion, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Ingresado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/servicionumeracion-consultar' })
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
