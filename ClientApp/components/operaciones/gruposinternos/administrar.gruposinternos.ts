import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_gruposinternos {
	idgrupo!: number;
	idcentral!: number;
	descripcion!: string;
}

@Component
export default class AdministrarGruposInternosComponent extends Vue {
	public gruposinternos = new clase_gruposinternos();
	public config = { headers: { 'Content-Type': 'application/json' } };
	public error: string = '';
	operacion = '';

	created() {
	}
	mounted() {
		this.operacion = this.$route.query.operacion.toString();
		if (this.operacion == 'Update') {
			this.gruposinternos.idgrupo = Number(this.$route.query.idgrupo);
			const params = new URLSearchParams();
			params.append('idgrupo', this.gruposinternos.idgrupo.toString());
			axios.get('api/gruposinternos/BuscarGruposInternos?' + params, this.config).then((res) => {
				this.gruposinternos = res.data
			}).catch((err) => {});
		};
	}
	Cancelar(): void {
		this.$router.push({ path: '/gruposinternos-consultar' });
	}
	Grabar(): void {
		if (this.operacion == 'Update') {
			axios.put('api/GruposInternos', this.gruposinternos, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Modificado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/gruposinternos-consultar' })
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
			axios.post('api/gruposinternos', this.gruposinternos, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Ingresado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/gruposinternos-consultar' })
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
