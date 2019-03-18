import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_costeo {
	idllamada!: string;
	idinternousuario!: number;
	idusuariodepto!: number;
	idinterno!: string;
	idusuariocuenta!: number;
	idcuenta!: string;
	idcentral!: number;
	idlinea!: string;
	idproveedor!: number;
	idtramo!: number;
	idtarifa!: number;
	id!: string;
	fecha!: any;
	hora!: any;
	duracion!: any;
	numero!: string;
	costo!: number;
}

@Component
export default class ConsultarCosteoComponent extends Vue {
	headers: Array < any > = [
	{ text: 'IDLlamada',align: 'left', sortable: false,value: 'idllamada'},
	{ text: 'IDInternoUsuario',align: 'left', sortable: false,value: 'idinternousuario'},
	{ text: 'IDUsuarioDepto',align: 'left', sortable: false,value: 'idusuariodepto'},
	{ text: 'IDInterno',align: 'left', sortable: false,value: 'idinterno'},
	{ text: 'IDUsuarioCuenta',align: 'left', sortable: false,value: 'idusuariocuenta'},
	{ text: 'IDCuenta',align: 'left', sortable: false,value: 'idcuenta'},
	{ text: 'IDCentral',align: 'left', sortable: false,value: 'idcentral'},
	{ text: 'IDLinea',align: 'left', sortable: false,value: 'idlinea'},
	{ text: 'IDProveedor',align: 'left', sortable: false,value: 'idproveedor'},
	{ text: 'IDTramo',align: 'left', sortable: false,value: 'idtramo'},
	{ text: 'IDTarifa',align: 'left', sortable: false,value: 'idtarifa'},
	{ text: 'ID',align: 'left', sortable: false,value: 'id'},
	{ text: 'Fecha',align: 'left', sortable: false,value: 'fecha'},
	{ text: 'Hora',align: 'left', sortable: false,value: 'hora'},
	{ text: 'Duracion',align: 'left', sortable: false,value: 'duracion'},
	{ text: 'Numero',align: 'left', sortable: false,value: 'numero'},
	{ text: 'Costo',align: 'left', sortable: false,value: 'costo'},
	]
	lstcosteo: clase_costeo[] = [];
	public config = { headers: { 'Content-Type': 'application/json' } };
	public buscarcosteo = '';
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
		axios.get('api/costeo/ConsultarCosteo', this.config)
			.then((res) => {
				this.lstcosteo = res.data
				this.totalItems = this.lstcosteo.length;
			})
			.catch ((err) => {
		});
	}
	Cancelar(): void {
		this.$router.push({ path: '/' });
	}
	Insertar(): void {
		this.$router.push({ path: '/costeo-administrar', query: { operacion: 'Insert' } });
	}
	Actualizar(dataidllamada: string): void {
		this.$router.push({ path: '/costeo-administrar', query: { idllamada: String(dataidllamada), operacion: 'Update' } });
	}
	Eliminar(data: clase_costeo): void {
		swal({
			title: 'Esta seguro de esta operacion?',
			text: "Eliminacion de Registro" + data.idllamada
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
				axios.delete('api/Costeo', {
					headers:{
						'Content-Type': 'application/json'
					},
					data: data }).then(() => {
					axios.get('api/Costeo/ConsultarCosteo', this.config)
						.then((res) => { this.lstcosteo = res.data })
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
