import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_usuariocuenta {
	idusuariocuenta!: number;
	idcuenta!: string;
	idcentral!: number;
	idusuario!: string;
	idempresa!: number;
	fecharegistro!: any;
}

@Component
export default class ConsultarUsuarioCuentaComponent extends Vue {
	headers: Array < any > = [
	{ text: 'IDUsuarioCuenta',align: 'left', sortable: false,value: 'idusuariocuenta'},
	{ text: 'IDCuenta',align: 'left', sortable: false,value: 'idcuenta'},
	{ text: 'IDCentral',align: 'left', sortable: false,value: 'idcentral'},
	{ text: 'IDUsuario',align: 'left', sortable: false,value: 'idusuario'},
	{ text: 'IDEmpresa',align: 'left', sortable: false,value: 'idempresa'},
	{ text: 'FechaRegistro',align: 'left', sortable: false,value: 'fecharegistro'},
	]
	lstusuariocuenta: clase_usuariocuenta[] = [];
	public config = { headers: { 'Content-Type': 'application/json' } };
	public buscarusuariocuenta = '';
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
		axios.get('api/usuariocuenta/ConsultarUsuarioCuenta', this.config)
			.then((res) => {
				this.lstusuariocuenta = res.data
				this.totalItems = this.lstusuariocuenta.length;
			})
			.catch ((err) => {
		});
	}
	Cancelar(): void {
		this.$router.push({ path: '/' });
	}
	Insertar(): void {
		this.$router.push({ path: '/usuariocuenta-administrar', query: { operacion: 'Insert' } });
	}
	Actualizar(dataidusuariocuenta: number): void {
		this.$router.push({ path: '/usuariocuenta-administrar', query: { idusuariocuenta: String(dataidusuariocuenta), operacion: 'Update' } });
	}
	Eliminar(data: clase_usuariocuenta): void {
		swal({
			title: 'Esta seguro de esta operacion?',
			text: "Eliminacion de Registro" + data.idusuariocuenta
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
				axios.delete('api/UsuarioCuenta', {
					headers:{
						'Content-Type': 'application/json'
					},
					data: data }).then(() => {
					axios.get('api/UsuarioCuenta/ConsultarUsuarioCuenta', this.config)
						.then((res) => { this.lstusuariocuenta = res.data })
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
