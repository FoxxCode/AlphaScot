import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_gruposlineas {
	idgrupo!: number;
	idcentral!: number;
	descripcion!: string;
}

@Component
export default class AdministrarGruposLineasComponent extends Vue {
	public gruposlineas = new clase_gruposlineas();
	public config = { headers: { 'Content-Type': 'application/json' } };
	public error: string = '';
	operacion = '';

	created() {
	}
	mounted() {
		this.operacion = this.$route.query.operacion.toString();
		if (this.operacion == 'Update') {
			this.gruposlineas.idgrupo = Number(this.$route.query.idgrupo);
			const params = new URLSearchParams();
			params.append('idgrupo', this.gruposlineas.idgrupo.toString());
			axios.get('api/gruposlineas/BuscarGruposLineas?' + params, this.config).then((res) => {
				this.gruposlineas = res.data
			}).catch((err) => {});
		};
	}
	Cancelar(): void {
		this.$router.push({ path: '/gruposlineas-consultar' });
	}
	Grabar(): void {
		if (this.operacion == 'Update') {
			axios.put('api/GruposLineas', this.gruposlineas, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Modificado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/gruposlineas-consultar' })
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
			axios.post('api/gruposlineas', this.gruposlineas, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Ingresado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/gruposlineas-consultar' })
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
