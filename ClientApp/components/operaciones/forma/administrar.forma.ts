import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_forma {
	idforma!: number;
	titulo!: string;
}

@Component
export default class AdministrarFormaComponent extends Vue {
	public forma = new clase_forma();
	public config = { headers: { 'Content-Type': 'application/json' } };
	public error: string = '';
	operacion = '';

	created() {
	}
	mounted() {
		this.operacion = this.$route.query.operacion.toString();
		if (this.operacion == 'Update') {
			this.forma.idforma = Number(this.$route.query.idforma);
			const params = new URLSearchParams();
			params.append('idforma', this.forma.idforma.toString());
			axios.get('api/forma/BuscarForma?' + params, this.config).then((res) => {
				this.forma = res.data
			}).catch((err) => {});
		};
	}
	Cancelar(): void {
		this.$router.push({ path: '/forma-consultar' });
	}
	Grabar(): void {
		if (this.operacion == 'Update') {
			axios.put('api/Forma', this.forma, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Modificado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/forma-consultar' })
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
			axios.post('api/forma', this.forma, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Ingresado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/forma-consultar' })
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
