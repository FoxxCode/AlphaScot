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
export default class ConsultarRolesComponent extends Vue {
	headers: Array < any > = [
	{ text: 'IDRol',align: 'left', sortable: false,value: 'idrol'},
	{ text: 'Descripcion',align: 'left', sortable: false,value: 'descripcion'},
	{ text: 'Etiqueta',align: 'left', sortable: false,value: 'etiqueta'},
	]
	lstroles: clase_roles[] = [];
	public config = { headers: { 'Content-Type': 'application/json' } };
	public buscarroles = '';
	public rowsPerPageText = 'Registros por Pagina:';
	public rowsperpageitems: number[] = [10, 50, 100];
	public rowsPerPage = 0;
	public totalItems = 0;

	pages()
	{
		if (this.rowsPerPage == null ||
			this.totalItems == null
		) return 0
		return Math.ceil(this.totalItems / this.rowsPerPage)
	}

	created() {
	}
	mounted() {
		axios.get('api/roles/ConsultarRoles', this.config)
			.then((res) => {
				this.lstroles = res.data
				this.totalItems = this.lstroles.length;
			})
			.catch ((err) => {
		});
	}
	Cancelar(): void {
		this.$router.push({ path: '/' });
	}
	Insertar(): void {
		this.$router.push({ path: '/roles-administrar', query: { operacion: 'Insert' } });
	}
	Actualizar(dataidrol: number): void {
		this.$router.push({ path: '/roles-administrar', query: { idrol: String(dataidrol), operacion: 'Update' } });
	}
	Eliminar(data: clase_roles): void {
		swal({
			title: 'Esta seguro de esta operacion?',
			text: "Eliminacion de Registro" + data.idrol
			,type: 'warning',
			showCancelButton: true,
			confirmButtonColor: 'green',
			cancelButtonColor: 'red',
			cancelButtonText:'Cancelar',
			confirmButtonText: 'Eliminar!'
		}).then((result) => {
			if (result.value) {
				swal(
					'Eliminado!',
					'El regitro fue eliminado.'
				);
				axios.delete('api/Roles', {
					headers:{
						'Content-Type': 'application/json'
					},
					data: data }).then(() => {
					axios.get('api/Roles/ConsultarRoles', this.config)
						.then((res) => { this.lstroles = res.data })
						.catch((err) => { });
				}).catch((err) => { 
						swal({
							type: 'error',
							title: err.response.data,
							showConfirmButton: false,
							timer: 2000
					})
				})
			}
		})
	}
}
