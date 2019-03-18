import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_costointernacional {
	iddia!: number;
	idtramo!: number;
	idtarifa!: number;
	idservicio!: number;
	idareapais!: number;
	costo!: number;
}

@Component
export default class AdministrarCostoInterNacionalComponent extends Vue {
	public costointernacional = new clase_costointernacional();
	public config = { headers: { 'Content-Type': 'application/json' } };
	public error: string = '';
	operacion = '';

	created() {
	}
	mounted() {
		this.operacion = this.$route.query.operacion.toString();
		if (this.operacion == 'Update') {
			this.costointernacional.iddia = Number(this.$route.query.iddia);
			this.costointernacional.idtramo = Number(this.$route.query.idtramo);
			this.costointernacional.idtarifa = Number(this.$route.query.idtarifa);
			this.costointernacional.idservicio = Number(this.$route.query.idservicio);
			this.costointernacional.idareapais = Number(this.$route.query.idareapais);
			const params = new URLSearchParams();
			params.append('iddia', this.costointernacional.iddia.toString());
			params.append('idtramo', this.costointernacional.idtramo.toString());
			params.append('idtarifa', this.costointernacional.idtarifa.toString());
			params.append('idservicio', this.costointernacional.idservicio.toString());
			params.append('idareapais', this.costointernacional.idareapais.toString());
			axios.get('api/costointernacional/BuscarCostoInterNacional?' + params, this.config).then((res) => {
				this.costointernacional = res.data
			}).catch((err) => {});
		};
	}
	Cancelar(): void {
		this.$router.push({ path: '/costointernacional-consultar' });
	}
	Grabar(): void {
		if (this.operacion == 'Update') {
			axios.put('api/CostoInterNacional', this.costointernacional, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Modificado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/costointernacional-consultar' })
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
			axios.post('api/costointernacional', this.costointernacional, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Ingresado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/costointernacional-consultar' })
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
