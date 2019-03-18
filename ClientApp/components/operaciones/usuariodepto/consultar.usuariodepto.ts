import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_usuariodepto {
	idusuariodepto!: number;
	iddepartamento!: string;
	idcargo!: number;
	idempresa!: number;
	idusuario!: string;
	fecharegistro!: any;
}

@Component
export default class ConsultarUsuarioDeptoComponent extends Vue {
	headers: Array < any > = [
	{ text: 'IDUsuarioDepto',align: 'left', sortable: false,value: 'idusuariodepto'},
	{ text: 'IDDepartamento',align: 'left', sortable: false,value: 'iddepartamento'},
	{ text: 'IDCargo',align: 'left', sortable: false,value: 'idcargo'},
	{ text: 'IDEmpresa',align: 'left', sortable: false,value: 'idempresa'},
	{ text: 'IDUsuario',align: 'left', sortable: false,value: 'idusuario'},
	{ text: 'FechaRegistro',align: 'left', sortable: false,value: 'fecharegistro'},
	]
	lstusuariodepto: clase_usuariodepto[] = [];
	public config = { headers: { 'Content-Type': 'application/json' } };
	public buscarusuariodepto = '';
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
		axios.get('api/usuariodepto/ConsultarUsuarioDepto', this.config)
			.then((res) => {
				this.lstusuariodepto = res.data
				this.totalItems = this.lstusuariodepto.length;
			})
			.catch ((err) => {
		});
	}
	Cancelar(): void {
		this.$router.push({ path: '/' });
	}
	Insertar(): void {
		this.$router.push({ path: '/usuariodepto-administrar', query: { operacion: 'Insert' } });
	}
	Actualizar(dataidusuariodepto: number): void {
		this.$router.push({ path: '/usuariodepto-administrar', query: { idusuariodepto: String(dataidusuariodepto), operacion: 'Update' } });
	}
	Eliminar(data: clase_usuariodepto): void {
		swal({
			title: 'Esta seguro de esta operacion?',
			text: "Eliminacion de Registro" + data.idusuariodepto
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
				axios.delete('api/UsuarioDepto', {
					headers:{
						'Content-Type': 'application/json'
					},
					data: data }).then(() => {
					axios.get('api/UsuarioDepto/ConsultarUsuarioDepto', this.config)
						.then((res) => { this.lstusuariodepto = res.data })
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
