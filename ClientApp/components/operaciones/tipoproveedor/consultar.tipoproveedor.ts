import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_tipoproveedor {
	idtipo!: number;
	descripcion!: string;
}

@Component
export default class ConsultarTipoProveedorComponent extends Vue {
	headers: Array < any > = [
	{ text: 'IDTipo',align: 'left', sortable: false,value: 'idtipo'},
	{ text: 'Descripcion',align: 'left', sortable: false,value: 'descripcion'},
	]
	lsttipoproveedor: clase_tipoproveedor[] = [];
	public config = { headers: { 'Content-Type': 'application/json' } };
	public buscartipoproveedor = '';
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
		axios.get('api/tipoproveedor/ConsultarTipoProveedor', this.config)
			.then((res) => {
				this.lsttipoproveedor = res.data
				this.totalItems = this.lsttipoproveedor.length;
			})
			.catch ((err) => {
		});
	}
	Cancelar(): void {
		this.$router.push({ path: '/' });
	}
	Insertar(): void {
		this.$router.push({ path: '/tipoproveedor-administrar', query: { operacion: 'Insert' } });
	}
	Actualizar(dataidtipo: number): void {
		this.$router.push({ path: '/tipoproveedor-administrar', query: { idtipo: String(dataidtipo), operacion: 'Update' } });
	}
	Eliminar(data: clase_tipoproveedor): void {
		swal({
			title: 'Esta seguro de esta operacion?',
			text: "Eliminacion de Registro" + data.idtipo
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
				axios.delete('api/TipoProveedor', {
					headers:{
						'Content-Type': 'application/json'
					},
					data: data }).then(() => {
					axios.get('api/TipoProveedor/ConsultarTipoProveedor', this.config)
						.then((res) => { this.lsttipoproveedor = res.data })
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
