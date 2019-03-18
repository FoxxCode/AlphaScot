import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_proveedorservicio {
	idservicio!: number;
	idproveedor!: number;
	descripcion!: string;
	etiqueta!: string;
}

@Component
export default class AdministrarProveedorServicioComponent extends Vue {
	public proveedorservicio = new clase_proveedorservicio();
	public config = { headers: { 'Content-Type': 'application/json' } };
	public error: string = '';
	operacion = '';

	created() {
	}
	mounted() {
		this.operacion = this.$route.query.operacion.toString();
		if (this.operacion == 'Update') {
			this.proveedorservicio.idservicio = Number(this.$route.query.idservicio);
			this.proveedorservicio.idproveedor = Number(this.$route.query.idproveedor);
			const params = new URLSearchParams();
			params.append('idservicio', this.proveedorservicio.idservicio.toString());
			params.append('idproveedor', this.proveedorservicio.idproveedor.toString());
			axios.get('api/proveedorservicio/BuscarProveedorServicio?' + params, this.config).then((res) => {
				this.proveedorservicio = res.data
			}).catch((err) => {});
		};
	}
	Cancelar(): void {
		this.$router.push({ path: '/proveedorservicio-consultar' });
	}
	Grabar(): void {
		if (this.operacion == 'Update') {
			axios.put('api/ProveedorServicio', this.proveedorservicio, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Modificado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/proveedorservicio-consultar' })
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
			axios.post('api/proveedorservicio', this.proveedorservicio, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Ingresado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/proveedorservicio-consultar' })
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
