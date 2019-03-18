import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_rolempresa {
	idrolempresa!: number;
	idempresa!: number;
	idrol!: number;
	fecharegistro!: any;
}

@Component
export default class ConsultarRolEmpresaComponent extends Vue {
	headers: Array < any > = [
	{ text: 'IDRolEmpresa',align: 'left', sortable: false,value: 'idrolempresa'},
	{ text: 'IDEmpresa',align: 'left', sortable: false,value: 'idempresa'},
	{ text: 'IDRol',align: 'left', sortable: false,value: 'idrol'},
	{ text: 'FechaRegistro',align: 'left', sortable: false,value: 'fecharegistro'},
	]
	lstrolempresa: clase_rolempresa[] = [];
	public config = { headers: { 'Content-Type': 'application/json' } };
	public buscarrolempresa = '';
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
		axios.get('api/rolempresa/ConsultarRolEmpresa', this.config)
			.then((res) => {
				this.lstrolempresa = res.data
				this.totalItems = this.lstrolempresa.length;
			})
			.catch ((err) => {
		});
	}
	Cancelar(): void {
		this.$router.push({ path: '/' });
	}
	Insertar(): void {
		this.$router.push({ path: '/rolempresa-administrar', query: { operacion: 'Insert' } });
	}
	Actualizar(dataidrolempresa: number): void {
		this.$router.push({ path: '/rolempresa-administrar', query: { idrolempresa: String(dataidrolempresa), operacion: 'Update' } });
	}
	Eliminar(data: clase_rolempresa): void {
		swal({
			title: 'Esta seguro de esta operacion?',
			text: "Eliminacion de Registro" + data.idrolempresa
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
				axios.delete('api/RolEmpresa', {
					headers:{
						'Content-Type': 'application/json'
					},
					data: data }).then(() => {
					axios.get('api/RolEmpresa/ConsultarRolEmpresa', this.config)
						.then((res) => { this.lstrolempresa = res.data })
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
