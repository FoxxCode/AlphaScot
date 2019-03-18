import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_serviciopatrones {
	idpatron!: string;
	idtarifa!: number;
	descripcion!: string;
}

@Component
export default class AdministrarServicioPatronesComponent extends Vue {
	public serviciopatrones = new clase_serviciopatrones();
	public config = { headers: { 'Content-Type': 'application/json' } };
	public error: string = '';
	operacion = '';

	created() {
	}
	mounted() {
		this.operacion = this.$route.query.operacion.toString();
		if (this.operacion == 'Update') {
			this.serviciopatrones.idpatron = String(this.$route.query.idpatron);
			const params = new URLSearchParams();
			params.append('idpatron', this.serviciopatrones.idpatron.toString());
			axios.get('api/serviciopatrones/BuscarServicioPatrones?' + params, this.config).then((res) => {
				this.serviciopatrones = res.data
			}).catch((err) => {});
		};
	}
	Cancelar(): void {
		this.$router.push({ path: '/serviciopatrones-consultar' });
	}
	Grabar(): void {
		if (this.operacion == 'Update') {
			axios.put('api/ServicioPatrones', this.serviciopatrones, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Modificado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/serviciopatrones-consultar' })
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
			axios.post('api/serviciopatrones', this.serviciopatrones, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Ingresado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/serviciopatrones-consultar' })
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
