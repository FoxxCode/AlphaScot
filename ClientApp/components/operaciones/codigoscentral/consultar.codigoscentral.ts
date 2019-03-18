import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_codigoscentral {
	idcodigo!: string;
	fecha!: any;
	idcuenta!: string;
	idcentral!: number;
}

@Component
export default class ConsultarCodigosCentralComponent extends Vue {
	headers: Array < any > = [
	{ text: 'IDCodigo',align: 'left', sortable: false,value: 'idcodigo'},
	{ text: 'Fecha',align: 'left', sortable: false,value: 'fecha'},
	{ text: 'IDCuenta',align: 'left', sortable: false,value: 'idcuenta'},
	{ text: 'IDCentral',align: 'left', sortable: false,value: 'idcentral'},
	]
	lstcodigoscentral: clase_codigoscentral[] = [];
	public config = { headers: { 'Content-Type': 'application/json' } };
	public buscarcodigoscentral = '';
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
		axios.get('api/codigoscentral/ConsultarCodigosCentral', this.config)
			.then((res) => {
				this.lstcodigoscentral = res.data
				this.totalItems = this.lstcodigoscentral.length;
			})
			.catch ((err) => {
		});
	}
	Cancelar(): void {
		this.$router.push({ path: '/' });
	}
	Insertar(): void {
		this.$router.push({ path: '/codigoscentral-administrar', query: { operacion: 'Insert' } });
	}
	Actualizar(dataidcodigo: string,datafecha: any,dataidcuenta: string,dataidcentral: number): void {
		this.$router.push({ path: '/codigoscentral-administrar', query: { idcodigo: String(dataidcodigo),fecha: String(datafecha),idcuenta: String(dataidcuenta),idcentral: String(dataidcentral), operacion: 'Update' } });
	}
	Eliminar(data: clase_codigoscentral): void {
		swal({
			title: 'Esta seguro de esta operacion?',
			text: "Eliminacion de Registro" + data.idcodigo + data.fecha + data.idcuenta + data.idcentral
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
				axios.delete('api/CodigosCentral', {
					headers:{
						'Content-Type': 'application/json'
					},
					data: data }).then(() => {
					axios.get('api/CodigosCentral/ConsultarCodigosCentral', this.config)
						.then((res) => { this.lstcodigoscentral = res.data })
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
