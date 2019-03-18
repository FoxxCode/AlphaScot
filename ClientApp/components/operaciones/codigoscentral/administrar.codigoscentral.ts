import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_codigoscentral {
	idcodigo!: string;
	fecha!: any;
	idcuenta!: string;
	idcentral!: number;
}

@Component
export default class AdministrarCodigosCentralComponent extends Vue {
	public codigoscentral = new clase_codigoscentral();
	public config = { headers: { 'Content-Type': 'application/json' } };
	public error: string = '';
	operacion = '';

	created() {
	}
	mounted() {
		this.operacion = this.$route.query.operacion.toString();
		if (this.operacion == 'Update') {
			this.codigoscentral.idcodigo = String(this.$route.query.idcodigo);
			this.codigoscentral.fecha = (this.$route.query.fecha);
			this.codigoscentral.idcuenta = String(this.$route.query.idcuenta);
			this.codigoscentral.idcentral = Number(this.$route.query.idcentral);
			const params = new URLSearchParams();
			params.append('idcodigo', this.codigoscentral.idcodigo.toString());
			params.append('fecha', this.codigoscentral.fecha.toString());
			params.append('idcuenta', this.codigoscentral.idcuenta.toString());
			params.append('idcentral', this.codigoscentral.idcentral.toString());
			axios.get('api/codigoscentral/BuscarCodigosCentral?' + params, this.config).then((res) => {
				this.codigoscentral = res.data
			}).catch((err) => {});
		};
	}
	Cancelar(): void {
		this.$router.push({ path: '/codigoscentral-consultar' });
	}
	Grabar(): void {
		if (this.operacion == 'Update') {
			axios.put('api/CodigosCentral', this.codigoscentral, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Modificado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/codigoscentral-consultar' })
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
			axios.post('api/codigoscentral', this.codigoscentral, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Ingresado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/codigoscentral-consultar' })
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
