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
export default class ConsultarDepartamentoComponent extends Vue {
	headers: Array < any > = [
	{ text: 'IDDepartamento',align: 'left', sortable: false,value: 'iddepartamento'},
	{ text: 'IDEmpresa',align: 'left', sortable: false,value: 'idempresa'},
	{ text: 'Descripcion',align: 'left', sortable: false,value: 'descripcion'},
	{ text: 'Nivel',align: 'left', sortable: false,value: 'nivel'},
	{ text: 'DeptoPadre',align: 'left', sortable: false,value: 'deptopadre'},
	]
	lstdepartamento: clase_departamento[] = [];
	public config = { headers: { 'Content-Type': 'application/json' } };
	public buscardepartamento = '';
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
		axios.get('api/departamento/ConsultarDepartamento', this.config)
			.then((res) => {
				this.lstdepartamento = res.data
				this.totalItems = this.lstdepartamento.length;
			})
			.catch ((err) => {
		});
	}
	Cancelar(): void {
		this.$router.push({ path: '/' });
	}
	Insertar(): void {
		this.$router.push({ path: '/departamento-administrar', query: { operacion: 'Insert' } });
	}
	Actualizar(dataiddepartamento: string,dataidempresa: number): void {
		this.$router.push({ path: '/departamento-administrar', query: { iddepartamento: String(dataiddepartamento),idempresa: String(dataidempresa), operacion: 'Update' } });
	}
	Eliminar(data: clase_departamento): void {
		swal({
			title: 'Esta seguro de esta operacion?',
			text: "Eliminacion de Registro" + data.iddepartamento + data.idempresa
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
				axios.delete('api/Departamento', {
					headers:{
						'Content-Type': 'application/json'
					},
					data: data }).then(() => {
					axios.get('api/Departamento/ConsultarDepartamento', this.config)
						.then((res) => { this.lstdepartamento = res.data })
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
