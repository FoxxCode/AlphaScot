import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_costeo {
	idllamada!: string;
	idinternousuario!: number;
	idusuariodepto!: number;
	idinterno!: string;
	idusuariocuenta!: number;
	idcuenta!: string;
	idcentral!: number;
	idlinea!: string;
	idproveedor!: number;
	idtramo!: number;
	idtarifa!: number;
	id!: string;
	fecha!: any;
	hora!: any;
	duracion!: any;
	numero!: string;
	costo!: number;
}

@Component
export default class AdministrarCosteoComponent extends Vue {
	public costeo = new clase_costeo();
	public config = { headers: { 'Content-Type': 'application/json' } };
	public error: string = '';
	operacion = '';

	created() {
	}
	mounted() {
		this.operacion = this.$route.query.operacion.toString();
		if (this.operacion == 'Update') {
			this.costeo.idllamada = String(this.$route.query.idllamada);
			const params = new URLSearchParams();
			params.append('idllamada', this.costeo.idllamada.toString());
			axios.get('api/costeo/BuscarCosteo?' + params, this.config).then((res) => {
				this.costeo = res.data
			}).catch((err) => {});
		};
	}
	Cancelar(): void {
		this.$router.push({ path: '/costeo-consultar' });
	}
	Grabar(): void {
		if (this.operacion == 'Update') {
			axios.put('api/Costeo', this.costeo, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Modificado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/costeo-consultar' })
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
			axios.post('api/costeo', this.costeo, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Ingresado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/costeo-consultar' })
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
