import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_continente {
	idcontinente!: number;
	descripcion!: string;
}

@Component
export default class AdministrarContinenteComponent extends Vue {
	public continente = new clase_continente();
	public config = { headers: { 'Content-Type': 'application/json' } };
	public error: string = '';
	operacion = '';

	created() {
	}
    mounted() {
        this.operacion = this.$route.query.operacion.toString();
		if (this.operacion == 'Update') {
			this.continente.idcontinente = Number(this.$route.query.idcontinente);
			const params = new URLSearchParams();
			params.append('idcontinente', this.continente.idcontinente.toString());
			axios.get('api/continente/BuscarContinente?' + params, this.config).then((res) => {
				this.continente = res.data
			}).catch((err) => {});
		};
	}
	Cancelar(): void {
		this.$router.push({ path: '/continente-consultar' });
	}
	Grabar(): void {
		if (this.operacion == 'Update') {
			axios.put('api/Continente', this.continente, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Modificado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/continente-consultar' })
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
			axios.post('api/continente', this.continente, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Ingresado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/continente-consultar' })
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
