import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_direccionusuario {
	iddireccion!: number;
	idusuario!: string;
	idzona!: string;
	idciudad!: number;
	idpais!: number;
	descripcion!: string;
	numero!: number;
	pordefecto!: boolean;
}

@Component
export default class ConsultarDireccionUsuarioComponent extends Vue {
	headers: Array < any > = [
	{ text: 'IDDireccion',align: 'left', sortable: false,value: 'iddireccion'},
	{ text: 'IDUsuario',align: 'left', sortable: false,value: 'idusuario'},
	{ text: 'IDZona',align: 'left', sortable: false,value: 'idzona'},
	{ text: 'IDCiudad',align: 'left', sortable: false,value: 'idciudad'},
	{ text: 'IDPais',align: 'left', sortable: false,value: 'idpais'},
	{ text: 'Descripcion',align: 'left', sortable: false,value: 'descripcion'},
	{ text: 'Numero',align: 'left', sortable: false,value: 'numero'},
	{ text: 'PorDefecto',align: 'left', sortable: false,value: 'pordefecto'},
	]
	lstdireccionusuario: clase_direccionusuario[] = [];
	public config = { headers: { 'Content-Type': 'application/json' } };
	public buscardireccionusuario = '';
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
		axios.get('api/direccionusuario/ConsultarDireccionUsuario', this.config)
			.then((res) => {
				this.lstdireccionusuario = res.data
				this.totalItems = this.lstdireccionusuario.length;
			})
			.catch ((err) => {
		});
	}
	Cancelar(): void {
		this.$router.push({ path: '/' });
	}
	Insertar(): void {
		this.$router.push({ path: '/direccionusuario-administrar', query: { operacion: 'Insert' } });
	}
	Actualizar(dataiddireccion: number,dataidusuario: string): void {
		this.$router.push({ path: '/direccionusuario-administrar', query: { iddireccion: String(dataiddireccion),idusuario: String(dataidusuario), operacion: 'Update' } });
	}
	Eliminar(data: clase_direccionusuario): void {
		swal({
			title: 'Esta seguro de esta operacion?',
			text: "Eliminacion de Registro" + data.iddireccion + data.idusuario
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
				axios.delete('api/DireccionUsuario', {
					headers:{
						'Content-Type': 'application/json'
					},
					data: data }).then(() => {
					axios.get('api/DireccionUsuario/ConsultarDireccionUsuario', this.config)
						.then((res) => { this.lstdireccionusuario = res.data })
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
