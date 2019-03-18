import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_internos {
	idinterno!: string;
	idcentral!: number;
	descripcion!: string;
	etiqueta!: string;
}

@Component
export default class AdministrarInternosComponent extends Vue {
	public internos = new clase_internos();
	public config = { headers: { 'Content-Type': 'application/json' } };
	public error: string = '';
	operacion = '';

	created() {
	}
	mounted() {
		this.operacion = this.$route.query.operacion.toString();
		if (this.operacion == 'Update') {
			this.internos.idinterno = String(this.$route.query.idinterno);
			this.internos.idcentral = Number(this.$route.query.idcentral);
			const params = new URLSearchParams();
			params.append('idinterno', this.internos.idinterno.toString());
			params.append('idcentral', this.internos.idcentral.toString());
			axios.get('api/internos/BuscarInternos?' + params, this.config).then((res) => {
				this.internos = res.data
			}).catch((err) => {});
		};
	}
	Cancelar(): void {
		this.$router.push({ path: '/internos-consultar' });
	}
	Grabar(): void {
		if (this.operacion == 'Update') {
			axios.put('api/Internos', this.internos, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Modificado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/internos-consultar' })
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
			axios.post('api/internos', this.internos, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Ingresado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/internos-consultar' })
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
