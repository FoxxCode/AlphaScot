import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_empresa {
	idempresa!: number;
	descripcion!: string;
	nit!: string;
}

@Component
export default class ConsultarEmpresaComponent extends Vue {
	headers: Array < any > = [
	{ text: 'IDEmpresa',align: 'left', sortable: false,value: 'idempresa'},
	{ text: 'Descripcion',align: 'left', sortable: false,value: 'descripcion'},
	{ text: 'NIT',align: 'left', sortable: false,value: 'nit'},
	]
	lstempresa: clase_empresa[] = [];
	public config = { headers: { 'Content-Type': 'application/json' } };
	public buscarempresa = '';
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
		axios.get('api/empresa/ConsultarEmpresa', this.config)
			.then((res) => {
				this.lstempresa = res.data
				this.totalItems = this.lstempresa.length;
			})
			.catch ((err) => {
		});
	}
	Cancelar(): void {
		this.$router.push({ path: '/' });
	}
	Insertar(): void {
		this.$router.push({ path: '/empresa-administrar', query: { operacion: 'Insert' } });
	}
	Actualizar(dataidempresa: number): void {
		this.$router.push({ path: '/empresa-administrar', query: { idempresa: String(dataidempresa), operacion: 'Update' } });
	}
	Eliminar(data: clase_empresa): void {
		swal({
			title: 'Esta seguro de esta operacion?',
			text: "Eliminacion de Registro" + data.idempresa
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
				axios.delete('api/Empresa', {
					headers:{
						'Content-Type': 'application/json'
					},
					data: data }).then(() => {
					axios.get('api/Empresa/ConsultarEmpresa', this.config)
						.then((res) => { this.lstempresa = res.data })
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
