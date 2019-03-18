import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_proveedorservicio {
	idservicio!: number;
	idproveedor!: number;
	descripcion!: string;
	etiqueta!: string;
}

@Component
export default class ConsultarProveedorServicioComponent extends Vue {
	headers: Array < any > = [
	{ text: 'IDServicio',align: 'left', sortable: false,value: 'idservicio'},
	{ text: 'IDProveedor',align: 'left', sortable: false,value: 'idproveedor'},
	{ text: 'Descripcion',align: 'left', sortable: false,value: 'descripcion'},
	{ text: 'Etiqueta',align: 'left', sortable: false,value: 'etiqueta'},
	]
	lstproveedorservicio: clase_proveedorservicio[] = [];
	public config = { headers: { 'Content-Type': 'application/json' } };
	public buscarproveedorservicio = '';
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
		axios.get('api/proveedorservicio/ConsultarProveedorServicio', this.config)
			.then((res) => {
				this.lstproveedorservicio = res.data
				this.totalItems = this.lstproveedorservicio.length;
			})
			.catch ((err) => {
		});
	}
	Cancelar(): void {
		this.$router.push({ path: '/' });
	}
	Insertar(): void {
		this.$router.push({ path: '/proveedorservicio-administrar', query: { operacion: 'Insert' } });
	}
	Actualizar(dataidservicio: number,dataidproveedor: number): void {
		this.$router.push({ path: '/proveedorservicio-administrar', query: { idservicio: String(dataidservicio),idproveedor: String(dataidproveedor), operacion: 'Update' } });
	}
	Eliminar(data: clase_proveedorservicio): void {
		swal({
			title: 'Esta seguro de esta operacion?',
			text: "Eliminacion de Registro" + data.idservicio + data.idproveedor
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
				axios.delete('api/ProveedorServicio', {
					headers:{
						'Content-Type': 'application/json'
					},
					data: data }).then(() => {
					axios.get('api/ProveedorServicio/ConsultarProveedorServicio', this.config)
						.then((res) => { this.lstproveedorservicio = res.data })
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
