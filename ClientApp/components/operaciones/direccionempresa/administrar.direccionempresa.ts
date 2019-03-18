import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_direccionempresa {
	iddireccion!: number;
	idempresa!: number;
	idzona!: string;
	idciudad!: number;
	idpais!: number;
	descripcion!: string;
	numero!: number;
	pordefecto!: boolean;
}

@Component
export default class AdministrarDireccionEmpresaComponent extends Vue {
	public direccionempresa = new clase_direccionempresa();
	public config = { headers: { 'Content-Type': 'application/json' } };
	public error: string = '';
	operacion = '';

	created() {
	}
	mounted() {
		this.operacion = this.$route.query.operacion.toString();
		if (this.operacion == 'Update') {
			this.direccionempresa.iddireccion = Number(this.$route.query.iddireccion);
			this.direccionempresa.idempresa = Number(this.$route.query.idempresa);
			const params = new URLSearchParams();
			params.append('iddireccion', this.direccionempresa.iddireccion.toString());
			params.append('idempresa', this.direccionempresa.idempresa.toString());
			axios.get('api/direccionempresa/BuscarDireccionEmpresa?' + params, this.config).then((res) => {
				this.direccionempresa = res.data
			}).catch((err) => {});
		};
	}
	Cancelar(): void {
		this.$router.push({ path: '/direccionempresa-consultar' });
	}
	Grabar(): void {
		if (this.operacion == 'Update') {
			axios.put('api/DireccionEmpresa', this.direccionempresa, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Modificado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/direccionempresa-consultar' })
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
			axios.post('api/direccionempresa', this.direccionempresa, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Ingresado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/direccionempresa-consultar' })
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
