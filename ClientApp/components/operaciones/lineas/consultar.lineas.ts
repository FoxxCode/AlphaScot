import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_lineas {
	idlinea!: string;
	idcentral!: number;
	idproveedor!: number;
	etiqueta!: string;
	descripcion!: string;
	numero!: string;
	reportaentrada!: boolean;
	reportasalida!: boolean;
}

@Component
export default class ConsultarLineasComponent extends Vue {
	headers: Array < any > = [
	{ text: 'IDLinea',align: 'left', sortable: false,value: 'idlinea'},
	{ text: 'IDCentral',align: 'left', sortable: false,value: 'idcentral'},
	{ text: 'IDProveedor',align: 'left', sortable: false,value: 'idproveedor'},
	{ text: 'Etiqueta',align: 'left', sortable: false,value: 'etiqueta'},
	{ text: 'Descripcion',align: 'left', sortable: false,value: 'descripcion'},
	{ text: 'Numero',align: 'left', sortable: false,value: 'numero'},
	{ text: 'ReportaEntrada',align: 'left', sortable: false,value: 'reportaentrada'},
	{ text: 'ReportaSalida',align: 'left', sortable: false,value: 'reportasalida'},
	]
	lstlineas: clase_lineas[] = [];
	public config = { headers: { 'Content-Type': 'application/json' } };
	public buscarlineas = '';
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
		axios.get('api/lineas/ConsultarLineas', this.config)
			.then((res) => {
				this.lstlineas = res.data
				this.totalItems = this.lstlineas.length;
			})
			.catch ((err) => {
		});
	}
	Cancelar(): void {
		this.$router.push({ path: '/' });
	}
	Insertar(): void {
		this.$router.push({ path: '/lineas-administrar', query: { operacion: 'Insert' } });
	}
	Actualizar(dataidlinea: string,dataidcentral: number): void {
		this.$router.push({ path: '/lineas-administrar', query: { idlinea: String(dataidlinea),idcentral: String(dataidcentral), operacion: 'Update' } });
	}
	Eliminar(data: clase_lineas): void {
		swal({
			title: 'Esta seguro de esta operacion?',
			text: "Eliminacion de Registro" + data.idlinea + data.idcentral
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
				axios.delete('api/Lineas', {
					headers:{
						'Content-Type': 'application/json'
					},
					data: data }).then(() => {
					axios.get('api/Lineas/ConsultarLineas', this.config)
						.then((res) => { this.lstlineas = res.data })
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
