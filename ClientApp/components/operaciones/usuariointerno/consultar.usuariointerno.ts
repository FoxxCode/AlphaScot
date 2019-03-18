import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_usuariointerno {
	idinternousuario!: number;
	idinterno!: string;
	idcentral!: number;
	idusuario!: string;
	idempresa!: number;
	fecharegistro!: any;
}

@Component
export default class ConsultarUsuarioInternoComponent extends Vue {
	headers: Array < any > = [
	{ text: 'IDInternoUsuario',align: 'left', sortable: false,value: 'idinternousuario'},
	{ text: 'IDInterno',align: 'left', sortable: false,value: 'idinterno'},
	{ text: 'IDCentral',align: 'left', sortable: false,value: 'idcentral'},
	{ text: 'IDUsuario',align: 'left', sortable: false,value: 'idusuario'},
	{ text: 'IDEmpresa',align: 'left', sortable: false,value: 'idempresa'},
	{ text: 'FechaRegistro',align: 'left', sortable: false,value: 'fecharegistro'},
	]
	lstusuariointerno: clase_usuariointerno[] = [];
	public config = { headers: { 'Content-Type': 'application/json' } };
	public buscarusuariointerno = '';
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
		axios.get('api/usuariointerno/ConsultarUsuarioInterno', this.config)
			.then((res) => {
				this.lstusuariointerno = res.data
				this.totalItems = this.lstusuariointerno.length;
			})
			.catch ((err) => {
		});
	}
	Cancelar(): void {
		this.$router.push({ path: '/' });
	}
	Insertar(): void {
		this.$router.push({ path: '/usuariointerno-administrar', query: { operacion: 'Insert' } });
	}
	Actualizar(dataidinternousuario: number): void {
		this.$router.push({ path: '/usuariointerno-administrar', query: { idinternousuario: String(dataidinternousuario), operacion: 'Update' } });
	}
	Eliminar(data: clase_usuariointerno): void {
		swal({
			title: 'Esta seguro de esta operacion?',
			text: "Eliminacion de Registro" + data.idinternousuario
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
				axios.delete('api/UsuarioInterno', {
					headers:{
						'Content-Type': 'application/json'
					},
					data: data }).then(() => {
					axios.get('api/UsuarioInterno/ConsultarUsuarioInterno', this.config)
						.then((res) => { this.lstusuariointerno = res.data })
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
