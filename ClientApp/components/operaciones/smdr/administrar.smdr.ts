import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_smdr {
	idllamada!: string;
	idestado!: number;
	codigo!: string;
	fecha!: string;
	hora!: string;
	duracion!: string;
	linea!: string;
	interno!: string;
	cuenta!: string;
	numero!: string;
}

@Component
export default class AdministrarSMDRComponent extends Vue {
	public smdr = new clase_smdr();
	public config = { headers: { 'Content-Type': 'application/json' } };
	public error: string = '';
	operacion = '';

	created() {
	}
	mounted() {
		this.operacion = this.$route.query.operacion.toString();
		if (this.operacion == 'Update') {
			this.smdr.idllamada = String(this.$route.query.idllamada);
			const params = new URLSearchParams();
			params.append('idllamada', this.smdr.idllamada.toString());
			axios.get('api/smdr/BuscarSMDR?' + params, this.config).then((res) => {
				this.smdr = res.data
			}).catch((err) => {});
		};
	}
	Cancelar(): void {
		this.$router.push({ path: '/smdr-consultar' });
	}
	Grabar(): void {
		if (this.operacion == 'Update') {
			axios.put('api/SMDR', this.smdr, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Modificado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/smdr-consultar' })
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
			axios.post('api/smdr', this.smdr, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Ingresado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/smdr-consultar' })
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
