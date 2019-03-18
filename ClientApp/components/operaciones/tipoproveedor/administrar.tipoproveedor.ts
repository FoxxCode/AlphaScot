import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_tipoproveedor {
	idtipo!: number;
	descripcion!: string;
}

@Component
export default class AdministrarTipoProveedorComponent extends Vue {
	public tipoproveedor = new clase_tipoproveedor();
	public config = { headers: { 'Content-Type': 'application/json' } };
	public error: string = '';
	operacion = '';

	created() {
	}
	mounted() {
		this.operacion = this.$route.query.operacion.toString();
		if (this.operacion == 'Update') {
			this.tipoproveedor.idtipo = Number(this.$route.query.idtipo);
			const params = new URLSearchParams();
			params.append('idtipo', this.tipoproveedor.idtipo.toString());
			axios.get('api/tipoproveedor/BuscarTipoProveedor?' + params, this.config).then((res) => {
				this.tipoproveedor = res.data
			}).catch((err) => {});
		};
	}
	Cancelar(): void {
		this.$router.push({ path: '/tipoproveedor-consultar' });
	}
	Grabar(): void {
		if (this.operacion == 'Update') {
			axios.put('api/TipoProveedor', this.tipoproveedor, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Modificado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/tipoproveedor-consultar' })
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
			axios.post('api/tipoproveedor', this.tipoproveedor, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Ingresado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/tipoproveedor-consultar' })
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
