import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_smdrorigen {
	idllamada!: string;
	idestado!: number;
	trama!: string;
}

@Component
export default class AdministrarSMDROrigenComponent extends Vue {
	public smdrorigen = new clase_smdrorigen();
	public config = { headers: { 'Content-Type': 'application/json' } };
	public error: string = '';
	operacion = '';

	created() {
	}
	mounted() {
		this.operacion = this.$route.query.operacion.toString();
		if (this.operacion == 'Update') {
			this.smdrorigen.idllamada = String(this.$route.query.idllamada);
			const params = new URLSearchParams();
			params.append('idllamada', this.smdrorigen.idllamada.toString());
			axios.get('api/smdrorigen/BuscarSMDROrigen?' + params, this.config).then((res) => {
				this.smdrorigen = res.data
			}).catch((err) => {});
		};
	}
	Cancelar(): void {
		this.$router.push({ path: '/smdrorigen-consultar' });
	}
	Grabar(): void {
		if (this.operacion == 'Update') {
			axios.put('api/SMDROrigen', this.smdrorigen, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Modificado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/smdrorigen-consultar' })
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
			axios.post('api/smdrorigen', this.smdrorigen, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Ingresado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/smdrorigen-consultar' })
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
