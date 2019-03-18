import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_paises {
	idpais!: number;
	descripcion!: string;
}

@Component
export default class AdministrarPaisesComponent extends Vue {
	public paises = new clase_paises();
	public config = { headers: { 'Content-Type': 'application/json' } };
	public error: string = '';
	operacion = '';

	created() {
	}
	mounted() {
		this.operacion = this.$route.query.operacion;
		if (this.operacion == 'Update') {
			this.paises.idpais = Number(this.$route.query.idpais);
			const params = new URLSearchParams();
			params.append('idpais', this.paises.idpais.toString());
			axios.get('api/paises/BuscarPaises?' + params, this.config).then((res) => {
				this.paises = res.data
			}).catch((err) => {});
		};
	}
	Cancelar(): void {
		this.$router.push({ path: '/paises-consultar' });
	}
	Grabar(): void {
		if (this.operacion == 'Update') {
			axios.put('api/Paises', this.paises, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Modificado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/paises-consultar' })
				}).catch((err) => {
				})
		}
		else {
			axios.post('api/paises', this.paises, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Ingresado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/paises-consultar' })
				}).catch((err) => {
				})
		}
	}
}
