import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_tipocomunicacion {
	idtipocomunicacion!: string;
	descripcion!: string;
}

@Component
export default class AdministrarTipoComunicacionComponent extends Vue {
	public tipocomunicacion = new clase_tipocomunicacion();
	public config = { headers: { 'Content-Type': 'application/json' } };
	public error: string = '';
	operacion = '';

	created() {
	}
	mounted() {
		this.operacion = this.$route.query.operacion.toString();
		if (this.operacion == 'Update') {
			this.tipocomunicacion.idtipocomunicacion = String(this.$route.query.idtipocomunicacion);
			const params = new URLSearchParams();
			params.append('idtipocomunicacion', this.tipocomunicacion.idtipocomunicacion.toString());
			axios.get('api/tipocomunicacion/BuscarTipoComunicacion?' + params, this.config).then((res) => {
				this.tipocomunicacion = res.data
			}).catch((err) => {});
		};
	}
	Cancelar(): void {
		this.$router.push({ path: '/tipocomunicacion-consultar' });
	}
	Grabar(): void {
		if (this.operacion == 'Update') {
			axios.put('api/TipoComunicacion', this.tipocomunicacion, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Modificado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/tipocomunicacion-consultar' })
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
			axios.post('api/tipocomunicacion', this.tipocomunicacion, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Ingresado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/tipocomunicacion-consultar' })
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
