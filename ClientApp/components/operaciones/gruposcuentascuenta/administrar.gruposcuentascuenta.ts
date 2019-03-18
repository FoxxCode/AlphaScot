import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_gruposcuentascuenta {
	idcuenta!: string;
	idcentral!: number;
	idgrupo!: number;
	fecharegistro!: any;
}

@Component
export default class AdministrarGruposCuentasCuentaComponent extends Vue {
	public gruposcuentascuenta = new clase_gruposcuentascuenta();
	public config = { headers: { 'Content-Type': 'application/json' } };
	public error: string = '';
	operacion = '';

	created() {
	}
	mounted() {
		this.operacion = this.$route.query.operacion.toString();
		if (this.operacion == 'Update') {
			this.gruposcuentascuenta.idcuenta = String(this.$route.query.idcuenta);
			this.gruposcuentascuenta.idcentral = Number(this.$route.query.idcentral);
			this.gruposcuentascuenta.idgrupo = Number(this.$route.query.idgrupo);
			const params = new URLSearchParams();
			params.append('idcuenta', this.gruposcuentascuenta.idcuenta.toString());
			params.append('idcentral', this.gruposcuentascuenta.idcentral.toString());
			params.append('idgrupo', this.gruposcuentascuenta.idgrupo.toString());
			axios.get('api/gruposcuentascuenta/BuscarGruposCuentasCuenta?' + params, this.config).then((res) => {
				this.gruposcuentascuenta = res.data
			}).catch((err) => {});
		};
	}
	Cancelar(): void {
		this.$router.push({ path: '/gruposcuentascuenta-consultar' });
	}
	Grabar(): void {
		if (this.operacion == 'Update') {
			axios.put('api/GruposCuentasCuenta', this.gruposcuentascuenta, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Modificado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/gruposcuentascuenta-consultar' })
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
			axios.post('api/gruposcuentascuenta', this.gruposcuentascuenta, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Ingresado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/gruposcuentascuenta-consultar' })
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
