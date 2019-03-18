import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_gruposcuentascuenta {
	idcuenta!: string;
	idcentral!: number;
	idgrupo!: number;
	fecharegistro!: any;
}

@Component
export default class ConsultarGruposCuentasCuentaComponent extends Vue {
	headers: Array < any > = [
	{ text: 'IDCuenta',align: 'left', sortable: false,value: 'idcuenta'},
	{ text: 'IDCentral',align: 'left', sortable: false,value: 'idcentral'},
	{ text: 'IDGrupo',align: 'left', sortable: false,value: 'idgrupo'},
	{ text: 'FechaRegistro',align: 'left', sortable: false,value: 'fecharegistro'},
	]
	lstgruposcuentascuenta: clase_gruposcuentascuenta[] = [];
	public config = { headers: { 'Content-Type': 'application/json' } };
	public buscargruposcuentascuenta = '';
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
		axios.get('api/gruposcuentascuenta/ConsultarGruposCuentasCuenta', this.config)
			.then((res) => {
				this.lstgruposcuentascuenta = res.data
				this.totalItems = this.lstgruposcuentascuenta.length;
			})
			.catch ((err) => {
		});
	}
	Cancelar(): void {
		this.$router.push({ path: '/' });
	}
	Insertar(): void {
		this.$router.push({ path: '/gruposcuentascuenta-administrar', query: { operacion: 'Insert' } });
	}
	Actualizar(dataidcuenta: string,dataidcentral: number,dataidgrupo: number): void {
		this.$router.push({ path: '/gruposcuentascuenta-administrar', query: { idcuenta: String(dataidcuenta),idcentral: String(dataidcentral),idgrupo: String(dataidgrupo), operacion: 'Update' } });
	}
	Eliminar(data: clase_gruposcuentascuenta): void {
		swal({
			title: 'Esta seguro de esta operacion?',
			text: "Eliminacion de Registro" + data.idcuenta + data.idcentral + data.idgrupo
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
				axios.delete('api/GruposCuentasCuenta', {
					headers:{
						'Content-Type': 'application/json'
					},
					data: data }).then(() => {
					axios.get('api/GruposCuentasCuenta/ConsultarGruposCuentasCuenta', this.config)
						.then((res) => { this.lstgruposcuentascuenta = res.data })
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
