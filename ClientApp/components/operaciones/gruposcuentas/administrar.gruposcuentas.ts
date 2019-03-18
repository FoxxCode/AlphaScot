import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_gruposcuentas {
	idgrupo!: number;
	idcentral!: number;
	descripcion!: string;
}

@Component
export default class AdministrarGruposCuentasComponent extends Vue {
	public gruposcuentas = new clase_gruposcuentas();
	public config = { headers: { 'Content-Type': 'application/json' } };
	public error: string = '';
	operacion = '';

	created() {
	}
	mounted() {
		this.operacion = this.$route.query.operacion.toString();
		if (this.operacion == 'Update') {
			this.gruposcuentas.idgrupo = Number(this.$route.query.idgrupo);
			const params = new URLSearchParams();
			params.append('idgrupo', this.gruposcuentas.idgrupo.toString());
			axios.get('api/gruposcuentas/BuscarGruposCuentas?' + params, this.config).then((res) => {
				this.gruposcuentas = res.data
			}).catch((err) => {});
		};
	}
	Cancelar(): void {
		this.$router.push({ path: '/gruposcuentas-consultar' });
	}
	Grabar(): void {
		if (this.operacion == 'Update') {
			axios.put('api/GruposCuentas', this.gruposcuentas, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Modificado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/gruposcuentas-consultar' })
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
			axios.post('api/gruposcuentas', this.gruposcuentas, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Ingresado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/gruposcuentas-consultar' })
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
