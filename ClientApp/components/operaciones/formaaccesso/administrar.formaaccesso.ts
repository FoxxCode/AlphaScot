import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_formaaccesso {
	idrol!: number;
	idforma!: number;
	acceso!: boolean;
	insercion!: boolean;
	modificacion!: boolean;
	eliminacion!: boolean;
	consulta!: boolean;
	impresion!: boolean;
	operacion!: boolean;
}

@Component
export default class AdministrarFormaAccessoComponent extends Vue {
	public formaaccesso = new clase_formaaccesso();
	public config = { headers: { 'Content-Type': 'application/json' } };
	public error: string = '';
	operacion = '';

	created() {
	}
	mounted() {
		this.operacion = this.$route.query.operacion.toString();
		if (this.operacion == 'Update') {
			this.formaaccesso.idrol = Number(this.$route.query.idrol);
			this.formaaccesso.idforma = Number(this.$route.query.idforma);
			const params = new URLSearchParams();
			params.append('idrol', this.formaaccesso.idrol.toString());
			params.append('idforma', this.formaaccesso.idforma.toString());
			axios.get('api/formaaccesso/BuscarFormaAccesso?' + params, this.config).then((res) => {
				this.formaaccesso = res.data
			}).catch((err) => {});
		};
	}
	Cancelar(): void {
		this.$router.push({ path: '/formaaccesso-consultar' });
	}
	Grabar(): void {
		if (this.operacion == 'Update') {
			axios.put('api/FormaAccesso', this.formaaccesso, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Modificado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/formaaccesso-consultar' })
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
			axios.post('api/formaaccesso', this.formaaccesso, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Ingresado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/formaaccesso-consultar' })
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
