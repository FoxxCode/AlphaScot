import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_ciudad {
	idciudad!: number;
	idpais!: number;
	descripcion!: string;
}

@Component
export default class AdministrarCiudadComponent extends Vue {
	public ciudad = new clase_ciudad();
	public config = { headers: { 'Content-Type': 'application/json' } };
	public error: string = '';
	operacion = '';

	created() {
	}
	mounted() {
		this.operacion = this.$route.query.operacion.toString();
		if (this.operacion == 'Update') {
			this.ciudad.idciudad = Number(this.$route.query.idciudad);
			this.ciudad.idpais = Number(this.$route.query.idpais);
			const params = new URLSearchParams();
			params.append('idciudad', this.ciudad.idciudad.toString());
			params.append('idpais', this.ciudad.idpais.toString());
			axios.get('api/ciudad/BuscarCiudad?' + params, this.config).then((res) => {
				this.ciudad = res.data
			}).catch((err) => {});
		};
	}
	Cancelar(): void {
		this.$router.push({ path: '/ciudad-consultar' });
	}
	Grabar(): void {
		if (this.operacion == 'Update') {
			axios.put('api/Ciudad', this.ciudad, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Modificado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/ciudad-consultar' })
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
			axios.post('api/ciudad', this.ciudad, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Ingresado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/ciudad-consultar' })
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
