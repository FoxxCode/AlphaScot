import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_gruposinternosinterno {
	idinterno!: string;
	idcentral!: number;
	idgrupo!: number;
	fecharegistro!: any;
}

@Component
export default class AdministrarGruposInternosInternoComponent extends Vue {
	public gruposinternosinterno = new clase_gruposinternosinterno();
	public config = { headers: { 'Content-Type': 'application/json' } };
	public error: string = '';
	operacion = '';

	created() {
	}
	mounted() {
		this.operacion = this.$route.query.operacion.toString();
		if (this.operacion == 'Update') {
			this.gruposinternosinterno.idinterno = String(this.$route.query.idinterno);
			this.gruposinternosinterno.idcentral = Number(this.$route.query.idcentral);
			this.gruposinternosinterno.idgrupo = Number(this.$route.query.idgrupo);
			const params = new URLSearchParams();
			params.append('idinterno', this.gruposinternosinterno.idinterno.toString());
			params.append('idcentral', this.gruposinternosinterno.idcentral.toString());
			params.append('idgrupo', this.gruposinternosinterno.idgrupo.toString());
			axios.get('api/gruposinternosinterno/BuscarGruposInternosInterno?' + params, this.config).then((res) => {
				this.gruposinternosinterno = res.data
			}).catch((err) => {});
		};
	}
	Cancelar(): void {
		this.$router.push({ path: '/gruposinternosinterno-consultar' });
	}
	Grabar(): void {
		if (this.operacion == 'Update') {
			axios.put('api/GruposInternosInterno', this.gruposinternosinterno, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Modificado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/gruposinternosinterno-consultar' })
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
			axios.post('api/gruposinternosinterno', this.gruposinternosinterno, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Ingresado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/gruposinternosinterno-consultar' })
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
