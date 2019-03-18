import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_rolempresa {
	idrolempresa!: number;
	idempresa!: number;
	idrol!: number;
	fecharegistro!: any;
}

@Component
export default class AdministrarRolEmpresaComponent extends Vue {
	public rolempresa = new clase_rolempresa();
	public config = { headers: { 'Content-Type': 'application/json' } };
	public error: string = '';
	operacion = '';

	created() {
	}
	mounted() {
		this.operacion = this.$route.query.operacion.toString();
		if (this.operacion == 'Update') {
			this.rolempresa.idrolempresa = Number(this.$route.query.idrolempresa);
			const params = new URLSearchParams();
			params.append('idrolempresa', this.rolempresa.idrolempresa.toString());
			axios.get('api/rolempresa/BuscarRolEmpresa?' + params, this.config).then((res) => {
				this.rolempresa = res.data
			}).catch((err) => {});
		};
	}
	Cancelar(): void {
		this.$router.push({ path: '/rolempresa-consultar' });
	}
	Grabar(): void {
		if (this.operacion == 'Update') {
			axios.put('api/RolEmpresa', this.rolempresa, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Modificado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/rolempresa-consultar' })
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
			axios.post('api/rolempresa', this.rolempresa, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Ingresado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/rolempresa-consultar' })
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
