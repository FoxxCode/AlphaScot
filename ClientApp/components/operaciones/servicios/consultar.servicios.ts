import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_servicios {
	idservicio!: number;
	descripcion!: string;
	etiqueta!: string;
}

@Component
export default class ConsultarServiciosComponent extends Vue {
	headers: Array < any > = [
	{ text: 'IDServicio',align: 'left', sortable: false,value: 'idservicio'},
	{ text: 'Descripcion',align: 'left', sortable: false,value: 'descripcion'},
	{ text: 'Etiqueta',align: 'left', sortable: false,value: 'etiqueta'},
	]
	lstservicios: clase_servicios[] = [];
	public config = { headers: { 'Content-Type': 'application/json' } };
	public buscarservicios = '';
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
		axios.get('api/servicios/ConsultarServicios', this.config)
			.then((res) => {
				this.lstservicios = res.data
				this.totalItems = this.lstservicios.length;
			})
			.catch ((err) => {
		});
	}
	Cancelar(): void {
		this.$router.push({ path: '/' });
	}
	Insertar(): void {
		this.$router.push({ path: '/servicios-administrar', query: { operacion: 'Insert' } });
	}
	Actualizar(dataidservicio: number): void {
		this.$router.push({ path: '/servicios-administrar', query: { idservicio: String(dataidservicio), operacion: 'Update' } });
	}
	Eliminar(data: clase_servicios): void {
		swal({
			title: 'Esta seguro de esta operacion?',
			text: "Eliminacion de Registro" + data.idservicio
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
				axios.delete('api/Servicios', {
					headers:{
						'Content-Type': 'application/json'
					},
					data: data }).then(() => {
					axios.get('api/Servicios/ConsultarServicios', this.config)
						.then((res) => { this.lstservicios = res.data })
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
