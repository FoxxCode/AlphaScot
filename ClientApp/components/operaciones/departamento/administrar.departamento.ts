import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_departamento {
	iddepartamento!: string;
	idempresa!: number;
	descripcion!: string;
	nivel!: number;
	deptopadre!: string;
}

@Component
export default class AdministrarDepartamentoComponent extends Vue {
	public departamento = new clase_departamento();
	public config = { headers: { 'Content-Type': 'application/json' } };
	public error: string = '';
	operacion = '';

	created() {
	}
	mounted() {
		this.operacion = this.$route.query.operacion.toString();
		if (this.operacion == 'Update') {
			this.departamento.iddepartamento = String(this.$route.query.iddepartamento);
			this.departamento.idempresa = Number(this.$route.query.idempresa);
			const params = new URLSearchParams();
			params.append('iddepartamento', this.departamento.iddepartamento.toString());
			params.append('idempresa', this.departamento.idempresa.toString());
			axios.get('api/departamento/BuscarDepartamento?' + params, this.config).then((res) => {
				this.departamento = res.data
			}).catch((err) => {});
		};
	}
	Cancelar(): void {
		this.$router.push({ path: '/departamento-consultar' });
	}
	Grabar(): void {
		if (this.operacion == 'Update') {
			axios.put('api/Departamento', this.departamento, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Modificado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/departamento-consultar' })
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
			axios.post('api/departamento', this.departamento, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Ingresado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/departamento-consultar' })
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
