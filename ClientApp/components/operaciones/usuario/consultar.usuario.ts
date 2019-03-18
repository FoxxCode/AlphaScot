import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_usuario {
	idusuario!: string;
	idempresa!: number;
	idcomunicacion!: number;
	descripcion!: string;
	encargado!: boolean;
}

@Component
export default class ConsultarUsuarioComponent extends Vue {
	headers: Array < any > = [
	{ text: 'IDUsuario',align: 'left', sortable: false,value: 'idusuario'},
	{ text: 'IDEmpresa',align: 'left', sortable: false,value: 'idempresa'},
	{ text: 'IDComunicacion',align: 'left', sortable: false,value: 'idcomunicacion'},
	{ text: 'Descripcion',align: 'left', sortable: false,value: 'descripcion'},
	{ text: 'Encargado',align: 'left', sortable: false,value: 'encargado'},
	]
	lstusuario: clase_usuario[] = [];
	public config = { headers: { 'Content-Type': 'application/json' } };
	public buscarusuario = '';
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
		axios.get('api/usuario/ConsultarUsuario', this.config)
			.then((res) => {
				this.lstusuario = res.data
				this.totalItems = this.lstusuario.length;
			})
			.catch ((err) => {
		});
	}
	Cancelar(): void {
		this.$router.push({ path: '/' });
	}
	Insertar(): void {
		this.$router.push({ path: '/usuario-administrar', query: { operacion: 'Insert' } });
	}
	Actualizar(dataidusuario: string,dataidempresa: number): void {
		this.$router.push({ path: '/usuario-administrar', query: { idusuario: String(dataidusuario),idempresa: String(dataidempresa), operacion: 'Update' } });
	}
	Eliminar(data: clase_usuario): void {
		swal({
			title: 'Esta seguro de esta operacion?',
			text: "Eliminacion de Registro" + data.idusuario + data.idempresa
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
				axios.delete('api/Usuario', {
					headers:{
						'Content-Type': 'application/json'
					},
					data: data }).then(() => {
					axios.get('api/Usuario/ConsultarUsuario', this.config)
						.then((res) => { this.lstusuario = res.data })
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
