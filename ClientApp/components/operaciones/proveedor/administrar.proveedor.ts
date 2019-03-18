import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_proveedor {
	idproveedor!: number;
	idtipo!: number;
	etiqueta!: string;
	idciudad!: number;
	idpais!: number;
	descripcion!: string;
}

@Component
export default class AdministrarProveedorComponent extends Vue {
	public proveedor = new clase_proveedor();
	public config = { headers: { 'Content-Type': 'application/json' } };
	public error: string = '';
	operacion = '';

	created() {
	}
	mounted() {
		this.operacion = this.$route.query.operacion.toString();
		if (this.operacion == 'Update') {
			this.proveedor.idproveedor = Number(this.$route.query.idproveedor);
			const params = new URLSearchParams();
			params.append('idproveedor', this.proveedor.idproveedor.toString());
			axios.get('api/proveedor/BuscarProveedor?' + params, this.config).then((res) => {
				this.proveedor = res.data
			}).catch((err) => {});
		};
	}
	Cancelar(): void {
		this.$router.push({ path: '/proveedor-consultar' });
	}
	Grabar(): void {
		if (this.operacion == 'Update') {
			axios.put('api/Proveedor', this.proveedor, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Modificado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/proveedor-consultar' })
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
			axios.post('api/proveedor', this.proveedor, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Ingresado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/proveedor-consultar' })
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
