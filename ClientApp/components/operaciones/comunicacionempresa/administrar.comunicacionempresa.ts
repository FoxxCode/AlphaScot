import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_comunicacionempresa {
	idcomunicacion!: number;
	idempresa!: number;
	idtipocomunicacion!: string;
	valor!: string;
	pordefecto!: boolean;
}

@Component
export default class AdministrarComunicacionEmpresaComponent extends Vue {
	public comunicacionempresa = new clase_comunicacionempresa();
	public config = { headers: { 'Content-Type': 'application/json' } };
	public error: string = '';
	operacion = '';

	created() {
	}
	mounted() {
		this.operacion = this.$route.query.operacion.toString();
		if (this.operacion == 'Update') {
			this.comunicacionempresa.idcomunicacion = Number(this.$route.query.idcomunicacion);
			this.comunicacionempresa.idempresa = Number(this.$route.query.idempresa);
			const params = new URLSearchParams();
			params.append('idcomunicacion', this.comunicacionempresa.idcomunicacion.toString());
			params.append('idempresa', this.comunicacionempresa.idempresa.toString());
			axios.get('api/comunicacionempresa/BuscarComunicacionEmpresa?' + params, this.config).then((res) => {
				this.comunicacionempresa = res.data
			}).catch((err) => {});
		};
	}
	Cancelar(): void {
		this.$router.push({ path: '/comunicacionempresa-consultar' });
	}
	Grabar(): void {
		if (this.operacion == 'Update') {
			axios.put('api/ComunicacionEmpresa', this.comunicacionempresa, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Modificado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/comunicacionempresa-consultar' })
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
			axios.post('api/comunicacionempresa', this.comunicacionempresa, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Ingresado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/comunicacionempresa-consultar' })
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
