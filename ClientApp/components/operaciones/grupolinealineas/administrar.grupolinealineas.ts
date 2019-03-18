import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_grupolinealineas {
	idgrupo!: number;
	idlinea!: string;
	idcentral!: number;
	fecharegistro!: any;
}

@Component
export default class AdministrarGrupoLineaLineasComponent extends Vue {
	public grupolinealineas = new clase_grupolinealineas();
	public config = { headers: { 'Content-Type': 'application/json' } };
	public error: string = '';
	operacion = '';

	created() {
	}
	mounted() {
		this.operacion = this.$route.query.operacion.toString();
		if (this.operacion == 'Update') {
			this.grupolinealineas.idgrupo = Number(this.$route.query.idgrupo);
			this.grupolinealineas.idlinea = String(this.$route.query.idlinea);
			this.grupolinealineas.idcentral = Number(this.$route.query.idcentral);
			const params = new URLSearchParams();
			params.append('idgrupo', this.grupolinealineas.idgrupo.toString());
			params.append('idlinea', this.grupolinealineas.idlinea.toString());
			params.append('idcentral', this.grupolinealineas.idcentral.toString());
			axios.get('api/grupolinealineas/BuscarGrupoLineaLineas?' + params, this.config).then((res) => {
				this.grupolinealineas = res.data
			}).catch((err) => {});
		};
	}
	Cancelar(): void {
		this.$router.push({ path: '/grupolinealineas-consultar' });
	}
	Grabar(): void {
		if (this.operacion == 'Update') {
			axios.put('api/GrupoLineaLineas', this.grupolinealineas, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Modificado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/grupolinealineas-consultar' })
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
			axios.post('api/grupolinealineas', this.grupolinealineas, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Ingresado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/grupolinealineas-consultar' })
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
