import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_costosnacional {
	iddia!: number;
	idtramo!: number;
	idtarifa!: number;
	idservicio!: number;
	idrango!: number;
	costo!: number;
}

@Component
export default class AdministrarCostosNacionalComponent extends Vue {
	public costosnacional = new clase_costosnacional();
	public config = { headers: { 'Content-Type': 'application/json' } };
	public error: string = '';
	operacion = '';

	created() {
	}
	mounted() {
		this.operacion = this.$route.query.operacion.toString();
		if (this.operacion == 'Update') {
			this.costosnacional.iddia = Number(this.$route.query.iddia);
			this.costosnacional.idtramo = Number(this.$route.query.idtramo);
			this.costosnacional.idtarifa = Number(this.$route.query.idtarifa);
			this.costosnacional.idservicio = Number(this.$route.query.idservicio);
			this.costosnacional.idrango = Number(this.$route.query.idrango);
			const params = new URLSearchParams();
			params.append('iddia', this.costosnacional.iddia.toString());
			params.append('idtramo', this.costosnacional.idtramo.toString());
			params.append('idtarifa', this.costosnacional.idtarifa.toString());
			params.append('idservicio', this.costosnacional.idservicio.toString());
			params.append('idrango', this.costosnacional.idrango.toString());
			axios.get('api/costosnacional/BuscarCostosNacional?' + params, this.config).then((res) => {
				this.costosnacional = res.data
			}).catch((err) => {});
		};
	}
	Cancelar(): void {
		this.$router.push({ path: '/costosnacional-consultar' });
	}
	Grabar(): void {
		if (this.operacion == 'Update') {
			axios.put('api/CostosNacional', this.costosnacional, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Modificado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/costosnacional-consultar' })
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
			axios.post('api/costosnacional', this.costosnacional, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Ingresado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/costosnacional-consultar' })
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
