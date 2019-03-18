import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_roles {
	idrol!: number;
	descripcion!: string;
	etiqueta!: string;
}

@Component
export default class AdministrarRolesComponent extends Vue {
	public roles = new clase_roles();
	public config = { headers: { 'Content-Type': 'application/json' } };
	public error: string = '';
	operacion = '';

	created() {
	}
	mounted() {
		this.operacion = this.$route.query.operacion.toString();
		if (this.operacion == 'Update') {
			this.roles.idrol = Number(this.$route.query.idrol);
			const params = new URLSearchParams();
			params.append('idrol', this.roles.idrol.toString());
			axios.get('api/roles/BuscarRoles?' + params, this.config).then((res) => {
				this.roles = res.data
			}).catch((err) => {});
		};
	}
	Cancelar(): void {
		this.$router.push({ path: '/roles-consultar' });
	}
	Grabar(): void {
		if (this.operacion == 'Update') {
			axios.put('api/Roles', this.roles, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Modificado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/roles-consultar' })
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
			axios.post('api/roles', this.roles, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Ingresado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/roles-consultar' })
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
