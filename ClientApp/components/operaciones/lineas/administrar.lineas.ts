import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_lineas {
	idlinea!: string;
	idcentral!: number;
	idproveedor!: number;
	etiqueta!: string;
	descripcion!: string;
	numero!: string;
	reportaentrada!: boolean;
	reportasalida!: boolean;
}

@Component
export default class AdministrarLineasComponent extends Vue {
	public lineas = new clase_lineas();
	public config = { headers: { 'Content-Type': 'application/json' } };
	public error: string = '';
	operacion = '';

	created() {
	}
	mounted() {
		this.operacion = this.$route.query.operacion.toString();
		if (this.operacion == 'Update') {
			this.lineas.idlinea = String(this.$route.query.idlinea);
			this.lineas.idcentral = Number(this.$route.query.idcentral);
			const params = new URLSearchParams();
			params.append('idlinea', this.lineas.idlinea.toString());
			params.append('idcentral', this.lineas.idcentral.toString());
			axios.get('api/lineas/BuscarLineas?' + params, this.config).then((res) => {
				this.lineas = res.data
			}).catch((err) => {});
		};
	}
	Cancelar(): void {
		this.$router.push({ path: '/lineas-consultar' });
	}
	Grabar(): void {
		if (this.operacion == 'Update') {
			axios.put('api/Lineas', this.lineas, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Modificado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/lineas-consultar' })
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
			axios.post('api/lineas', this.lineas, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Ingresado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/lineas-consultar' })
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
