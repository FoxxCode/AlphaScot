import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_central {
	idcentral!: number;
	idciudad!: number;
	idpais!: number;
	idempresa!: number;
	descripcion!: string;
	codigo!: string;
	procesaentrada!: boolean;
	procesasalida!: boolean;
	procesacuentas!: boolean;
}

@Component
export default class ConsultarCentralComponent extends Vue {
	headers: Array < any > = [
	{ text: 'IDCentral',align: 'left', sortable: false,value: 'idcentral'},
	{ text: 'IDCiudad',align: 'left', sortable: false,value: 'idciudad'},
	{ text: 'IDPais',align: 'left', sortable: false,value: 'idpais'},
	{ text: 'IDEmpresa',align: 'left', sortable: false,value: 'idempresa'},
	{ text: 'Descripcion',align: 'left', sortable: false,value: 'descripcion'},
	{ text: 'Codigo',align: 'left', sortable: false,value: 'codigo'},
	{ text: 'ProcesaEntrada',align: 'left', sortable: false,value: 'procesaentrada'},
	{ text: 'ProcesaSalida',align: 'left', sortable: false,value: 'procesasalida'},
	{ text: 'ProcesaCuentas',align: 'left', sortable: false,value: 'procesacuentas'},
	]
	lstcentral: clase_central[] = [];
	public config = { headers: { 'Content-Type': 'application/json' } };
	public buscarcentral = '';
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
		axios.get('api/central/ConsultarCentral', this.config)
			.then((res) => {
				this.lstcentral = res.data
				this.totalItems = this.lstcentral.length;
			})
			.catch ((err) => {
		});
	}
	Cancelar(): void {
		this.$router.push({ path: '/' });
	}
	Insertar(): void {
		this.$router.push({ path: '/central-administrar', query: { operacion: 'Insert' } });
	}
	Actualizar(dataidcentral: number): void {
		this.$router.push({ path: '/central-administrar', query: { idcentral: String(dataidcentral), operacion: 'Update' } });
	}
	Eliminar(data: clase_central): void {
		swal({
			title: 'Esta seguro de esta operacion?',
			text: "Eliminacion de Registro" + data.idcentral
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
				axios.delete('api/Central', {
					headers:{
						'Content-Type': 'application/json'
					},
					data: data }).then(() => {
					axios.get('api/Central/ConsultarCentral', this.config)
						.then((res) => { this.lstcentral = res.data })
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
