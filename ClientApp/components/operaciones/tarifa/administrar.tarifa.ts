import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_tarifa {
	idtarifa!: number;
	idservicio!: number;
	descripcion!: string;
	idciudad!: number;
	idpais!: number;
	etiqueta!: string;
}

@Component
export default class AdministrarTarifaComponent extends Vue {
	public tarifa = new clase_tarifa();
	public config = { headers: { 'Content-Type': 'application/json' } };
	public error: string = '';
	operacion = '';

	created() {
	}
	mounted() {
		this.operacion = this.$route.query.operacion.toString();
		if (this.operacion == 'Update') {
			this.tarifa.idtarifa = Number(this.$route.query.idtarifa);
			const params = new URLSearchParams();
			params.append('idtarifa', this.tarifa.idtarifa.toString());
			axios.get('api/tarifa/BuscarTarifa?' + params, this.config).then((res) => {
				this.tarifa = res.data
			}).catch((err) => {});
		};
	}
	Cancelar(): void {
		this.$router.push({ path: '/tarifa-consultar' });
	}
	Grabar(): void {
		if (this.operacion == 'Update') {
			axios.put('api/Tarifa', this.tarifa, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Modificado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/tarifa-consultar' })
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
			axios.post('api/tarifa', this.tarifa, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Ingresado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/tarifa-consultar' })
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
