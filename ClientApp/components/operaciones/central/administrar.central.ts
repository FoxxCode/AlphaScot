import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_central {
	idcentral!: number;
	idciudad!: number;
	idpais!: number;
	idempresa!: number;
	descripcion!: string;
	codigo!: string;
	procesaentrada!: boolean;
	procesasalida!: boolean;
	procesacuentas!: boolean;
}

@Component
export default class AdministrarCentralComponent extends Vue {
	public central = new clase_central();
	public config = { headers: { 'Content-Type': 'application/json' } };
	public error: string = '';
	operacion = '';

	created() {
	}
	mounted() {
		this.operacion = this.$route.query.operacion.toString();
		if (this.operacion == 'Update') {
			this.central.idcentral = Number(this.$route.query.idcentral);
			const params = new URLSearchParams();
			params.append('idcentral', this.central.idcentral.toString());
			axios.get('api/central/BuscarCentral?' + params, this.config).then((res) => {
				this.central = res.data
			}).catch((err) => {});
		};
	}
	Cancelar(): void {
		this.$router.push({ path: '/central-consultar' });
	}
	Grabar(): void {
		if (this.operacion == 'Update') {
			axios.put('api/Central', this.central, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Modificado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/central-consultar' })
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
			axios.post('api/central', this.central, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Ingresado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/central-consultar' })
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
