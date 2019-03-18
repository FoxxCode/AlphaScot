import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_cuentas {
	idcuenta!: string;
	idcentral!: number;
	etiqueta!: string;
	descripcion!: string;
}

@Component
export default class ConsultarCuentasComponent extends Vue {
	headers: Array < any > = [
	{ text: 'IDCuenta',align: 'left', sortable: false,value: 'idcuenta'},
	{ text: 'IDCentral',align: 'left', sortable: false,value: 'idcentral'},
	{ text: 'Etiqueta',align: 'left', sortable: false,value: 'etiqueta'},
	{ text: 'Descripcion',align: 'left', sortable: false,value: 'descripcion'},
	]
	lstcuentas: clase_cuentas[] = [];
	public config = { headers: { 'Content-Type': 'application/json' } };
	public buscarcuentas = '';
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
		axios.get('api/cuentas/ConsultarCuentas', this.config)
			.then((res) => {
				this.lstcuentas = res.data
				this.totalItems = this.lstcuentas.length;
			})
			.catch ((err) => {
		});
	}
	Cancelar(): void {
		this.$router.push({ path: '/' });
	}
	Insertar(): void {
		this.$router.push({ path: '/cuentas-administrar', query: { operacion: 'Insert' } });
	}
	Actualizar(dataidcuenta: string,dataidcentral: number): void {
		this.$router.push({ path: '/cuentas-administrar', query: { idcuenta: String(dataidcuenta),idcentral: String(dataidcentral), operacion: 'Update' } });
	}
	Eliminar(data: clase_cuentas): void {
		swal({
			title: 'Esta seguro de esta operacion?',
			text: "Eliminacion de Registro" + data.idcuenta + data.idcentral
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
				axios.delete('api/Cuentas', {
					headers:{
						'Content-Type': 'application/json'
					},
					data: data }).then(() => {
					axios.get('api/Cuentas/ConsultarCuentas', this.config)
						.then((res) => { this.lstcuentas = res.data })
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
