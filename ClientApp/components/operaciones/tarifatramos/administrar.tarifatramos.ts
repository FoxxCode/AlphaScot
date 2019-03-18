import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_tarifatramos {
	idtramo!: number;
	idtarifa!: number;
	etiqueta!: string;
	horainicio!: string;
	horafinal!: string;
}

@Component
export default class AdministrarTarifaTramosComponent extends Vue {
	public tarifatramos = new clase_tarifatramos();
	public config = { headers: { 'Content-Type': 'application/json' } };
	public error: string = '';
	operacion = '';

	created() {
	}
	mounted() {
		this.operacion = this.$route.query.operacion.toString();
		if (this.operacion == 'Update') {
			this.tarifatramos.idtramo = Number(this.$route.query.idtramo);
			const params = new URLSearchParams();
			params.append('idtramo', this.tarifatramos.idtramo.toString());
			axios.get('api/tarifatramos/BuscarTarifaTramos?' + params, this.config).then((res) => {
				this.tarifatramos = res.data
			}).catch((err) => {});
		};
	}
	Cancelar(): void {
		this.$router.push({ path: '/tarifatramos-consultar' });
	}
	Grabar(): void {
		if (this.operacion == 'Update') {
			axios.put('api/TarifaTramos', this.tarifatramos, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Modificado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/tarifatramos-consultar' })
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
			axios.post('api/tarifatramos', this.tarifatramos, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Ingresado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/tarifatramos-consultar' })
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
