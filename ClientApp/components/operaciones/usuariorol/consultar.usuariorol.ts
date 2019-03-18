import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_usuariorol {
	idusuario!: string;
	idrolempresa!: number;
	idempresa!: number;
	fecharegistro!: any;
}

@Component
export default class ConsultarUsuarioRolComponent extends Vue {
	headers: Array < any > = [
	{ text: 'IDUsuario',align: 'left', sortable: false,value: 'idusuario'},
	{ text: 'IDRolEmpresa',align: 'left', sortable: false,value: 'idrolempresa'},
	{ text: 'IDEmpresa',align: 'left', sortable: false,value: 'idempresa'},
	{ text: 'FechaRegistro',align: 'left', sortable: false,value: 'fecharegistro'},
	]
	lstusuariorol: clase_usuariorol[] = [];
	public config = { headers: { 'Content-Type': 'application/json' } };
	public buscarusuariorol = '';
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
		axios.get('api/usuariorol/ConsultarUsuarioRol', this.config)
			.then((res) => {
				this.lstusuariorol = res.data
				this.totalItems = this.lstusuariorol.length;
			})
			.catch ((err) => {
		});
	}
	Cancelar(): void {
		this.$router.push({ path: '/' });
	}
	Insertar(): void {
		this.$router.push({ path: '/usuariorol-administrar', query: { operacion: 'Insert' } });
	}
	Actualizar(dataidusuario: string,dataidrolempresa: number): void {
		this.$router.push({ path: '/usuariorol-administrar', query: { idusuario: String(dataidusuario),idrolempresa: String(dataidrolempresa), operacion: 'Update' } });
	}
	Eliminar(data: clase_usuariorol): void {
		swal({
			title: 'Esta seguro de esta operacion?',
			text: "Eliminacion de Registro" + data.idusuario + data.idrolempresa
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
				axios.delete('api/UsuarioRol', {
					headers:{
						'Content-Type': 'application/json'
					},
					data: data }).then(() => {
					axios.get('api/UsuarioRol/ConsultarUsuarioRol', this.config)
						.then((res) => { this.lstusuariorol = res.data })
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
