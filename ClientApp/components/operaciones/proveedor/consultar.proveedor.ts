import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_proveedor {
	idproveedor!: number;
	idtipo!: number;
	etiqueta!: string;
	idciudad!: number;
	idpais!: number;
	descripcion!: string;
}

@Component
export default class ConsultarProveedorComponent extends Vue {
	headers: Array < any > = [
	{ text: 'IDProveedor',align: 'left', sortable: false,value: 'idproveedor'},
	{ text: 'IDTipo',align: 'left', sortable: false,value: 'idtipo'},
	{ text: 'Etiqueta',align: 'left', sortable: false,value: 'etiqueta'},
	{ text: 'IDCiudad',align: 'left', sortable: false,value: 'idciudad'},
	{ text: 'IDPais',align: 'left', sortable: false,value: 'idpais'},
	{ text: 'Descripcion',align: 'left', sortable: false,value: 'descripcion'},
	]
	lstproveedor: clase_proveedor[] = [];
	public config = { headers: { 'Content-Type': 'application/json' } };
	public buscarproveedor = '';
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
		axios.get('api/proveedor/ConsultarProveedor', this.config)
			.then((res) => {
				this.lstproveedor = res.data
				this.totalItems = this.lstproveedor.length;
			})
			.catch ((err) => {
		});
	}
	Cancelar(): void {
		this.$router.push({ path: '/' });
	}
	Insertar(): void {
		this.$router.push({ path: '/proveedor-administrar', query: { operacion: 'Insert' } });
	}
	Actualizar(dataidproveedor: number): void {
		this.$router.push({ path: '/proveedor-administrar', query: { idproveedor: String(dataidproveedor), operacion: 'Update' } });
	}
	Eliminar(data: clase_proveedor): void {
		swal({
			title: 'Esta seguro de esta operacion?',
			text: "Eliminacion de Registro" + data.idproveedor
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
				axios.delete('api/Proveedor', {
					headers:{
						'Content-Type': 'application/json'
					},
					data: data }).then(() => {
					axios.get('api/Proveedor/ConsultarProveedor', this.config)
						.then((res) => { this.lstproveedor = res.data })
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
