import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_direccionempresa {
	iddireccion!: number;
	idempresa!: number;
	idzona!: string;
	idciudad!: number;
	idpais!: number;
	descripcion!: string;
	numero!: number;
	pordefecto!: boolean;
}

@Component
export default class ConsultarDireccionEmpresaComponent extends Vue {
	headers: Array < any > = [
	{ text: 'IDDireccion',align: 'left', sortable: false,value: 'iddireccion'},
	{ text: 'IDEmpresa',align: 'left', sortable: false,value: 'idempresa'},
	{ text: 'IDZona',align: 'left', sortable: false,value: 'idzona'},
	{ text: 'IDCiudad',align: 'left', sortable: false,value: 'idciudad'},
	{ text: 'IDPais',align: 'left', sortable: false,value: 'idpais'},
	{ text: 'Descripcion',align: 'left', sortable: false,value: 'descripcion'},
	{ text: 'Numero',align: 'left', sortable: false,value: 'numero'},
	{ text: 'PorDefecto',align: 'left', sortable: false,value: 'pordefecto'},
	]
	lstdireccionempresa: clase_direccionempresa[] = [];
	public config = { headers: { 'Content-Type': 'application/json' } };
	public buscardireccionempresa = '';
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
		axios.get('api/direccionempresa/ConsultarDireccionEmpresa', this.config)
			.then((res) => {
				this.lstdireccionempresa = res.data
				this.totalItems = this.lstdireccionempresa.length;
			})
			.catch ((err) => {
		});
	}
	Cancelar(): void {
		this.$router.push({ path: '/' });
	}
	Insertar(): void {
		this.$router.push({ path: '/direccionempresa-administrar', query: { operacion: 'Insert' } });
	}
	Actualizar(dataiddireccion: number,dataidempresa: number): void {
		this.$router.push({ path: '/direccionempresa-administrar', query: { iddireccion: String(dataiddireccion),idempresa: String(dataidempresa), operacion: 'Update' } });
	}
	Eliminar(data: clase_direccionempresa): void {
		swal({
			title: 'Esta seguro de esta operacion?',
			text: "Eliminacion de Registro" + data.iddireccion + data.idempresa
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
				axios.delete('api/DireccionEmpresa', {
					headers:{
						'Content-Type': 'application/json'
					},
					data: data }).then(() => {
					axios.get('api/DireccionEmpresa/ConsultarDireccionEmpresa', this.config)
						.then((res) => { this.lstdireccionempresa = res.data })
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
