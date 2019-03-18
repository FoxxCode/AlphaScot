import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_gruposcuentas {
	idgrupo!: number;
	idcentral!: number;
	descripcion!: string;
}

@Component
export default class ConsultarGruposCuentasComponent extends Vue {
	headers: Array < any > = [
	{ text: 'IDGrupo',align: 'left', sortable: false,value: 'idgrupo'},
	{ text: 'IDCentral',align: 'left', sortable: false,value: 'idcentral'},
	{ text: 'Descripcion',align: 'left', sortable: false,value: 'descripcion'},
	]
	lstgruposcuentas: clase_gruposcuentas[] = [];
	public config = { headers: { 'Content-Type': 'application/json' } };
	public buscargruposcuentas = '';
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
		axios.get('api/gruposcuentas/ConsultarGruposCuentas', this.config)
			.then((res) => {
				this.lstgruposcuentas = res.data
				this.totalItems = this.lstgruposcuentas.length;
			})
			.catch ((err) => {
		});
	}
	Cancelar(): void {
		this.$router.push({ path: '/' });
	}
	Insertar(): void {
		this.$router.push({ path: '/gruposcuentas-administrar', query: { operacion: 'Insert' } });
	}
	Actualizar(dataidgrupo: number): void {
		this.$router.push({ path: '/gruposcuentas-administrar', query: { idgrupo: String(dataidgrupo), operacion: 'Update' } });
	}
	Eliminar(data: clase_gruposcuentas): void {
		swal({
			title: 'Esta seguro de esta operacion?',
			text: "Eliminacion de Registro" + data.idgrupo
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
				axios.delete('api/GruposCuentas', {
					headers:{
						'Content-Type': 'application/json'
					},
					data: data }).then(() => {
					axios.get('api/GruposCuentas/ConsultarGruposCuentas', this.config)
						.then((res) => { this.lstgruposcuentas = res.data })
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
