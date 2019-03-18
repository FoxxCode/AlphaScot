import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_sericioareapais {
	idareapais!: number;
	idservicio!: number;
	idarea!: number;
	idpais!: number;
	fecharegistro!: any;
}

@Component
export default class AdministrarSericioAreaPaisComponent extends Vue {
	public sericioareapais = new clase_sericioareapais();
	public config = { headers: { 'Content-Type': 'application/json' } };
	public error: string = '';
	operacion = '';

	created() {
	}
	mounted() {
		this.operacion = this.$route.query.operacion.toString();
		if (this.operacion == 'Update') {
			this.sericioareapais.idareapais = Number(this.$route.query.idareapais);
			this.sericioareapais.idservicio = Number(this.$route.query.idservicio);
			const params = new URLSearchParams();
			params.append('idareapais', this.sericioareapais.idareapais.toString());
			params.append('idservicio', this.sericioareapais.idservicio.toString());
			axios.get('api/sericioareapais/BuscarSericioAreaPais?' + params, this.config).then((res) => {
				this.sericioareapais = res.data
			}).catch((err) => {});
		};
	}
	Cancelar(): void {
		this.$router.push({ path: '/sericioareapais-consultar' });
	}
	Grabar(): void {
		if (this.operacion == 'Update') {
			axios.put('api/SericioAreaPais', this.sericioareapais, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Modificado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/sericioareapais-consultar' })
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
			axios.post('api/sericioareapais', this.sericioareapais, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Ingresado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/sericioareapais-consultar' })
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
