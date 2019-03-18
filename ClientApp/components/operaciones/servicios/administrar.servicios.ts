import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_servicios {
	idservicio!: number;
	descripcion!: string;
	etiqueta!: string;
}

@Component
export default class AdministrarServiciosComponent extends Vue {
	public servicios = new clase_servicios();
	public config = { headers: { 'Content-Type': 'application/json' } };
	public error: string = '';
	operacion = '';

	created() {
	}
	mounted() {
		this.operacion = this.$route.query.operacion.toString();
		if (this.operacion == 'Update') {
			this.servicios.idservicio = Number(this.$route.query.idservicio);
			const params = new URLSearchParams();
			params.append('idservicio', this.servicios.idservicio.toString());
			axios.get('api/servicios/BuscarServicios?' + params, this.config).then((res) => {
				this.servicios = res.data
			}).catch((err) => {});
		};
	}
	Cancelar(): void {
		this.$router.push({ path: '/servicios-consultar' });
	}
	Grabar(): void {
		if (this.operacion == 'Update') {
			axios.put('api/Servicios', this.servicios, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Modificado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/servicios-consultar' })
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
			axios.post('api/servicios', this.servicios, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Ingresado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/servicios-consultar' })
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
