import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_serviciopatrones {
	idpatron!: string;
	idtarifa!: number;
	descripcion!: string;
}

@Component
export default class ConsultarServicioPatronesComponent extends Vue {
	headers: Array < any > = [
	{ text: 'IDPatron',align: 'left', sortable: false,value: 'idpatron'},
	{ text: 'IDTarifa',align: 'left', sortable: false,value: 'idtarifa'},
	{ text: 'Descripcion',align: 'left', sortable: false,value: 'descripcion'},
	]
	lstserviciopatrones: clase_serviciopatrones[] = [];
	public config = { headers: { 'Content-Type': 'application/json' } };
	public buscarserviciopatrones = '';
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
		axios.get('api/serviciopatrones/ConsultarServicioPatrones', this.config)
			.then((res) => {
				this.lstserviciopatrones = res.data
				this.totalItems = this.lstserviciopatrones.length;
			})
			.catch ((err) => {
		});
	}
	Cancelar(): void {
		this.$router.push({ path: '/' });
	}
	Insertar(): void {
		this.$router.push({ path: '/serviciopatrones-administrar', query: { operacion: 'Insert' } });
	}
	Actualizar(dataidpatron: string): void {
		this.$router.push({ path: '/serviciopatrones-administrar', query: { idpatron: String(dataidpatron), operacion: 'Update' } });
	}
	Eliminar(data: clase_serviciopatrones): void {
		swal({
			title: 'Esta seguro de esta operacion?',
			text: "Eliminacion de Registro" + data.idpatron
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
				axios.delete('api/ServicioPatrones', {
					headers:{
						'Content-Type': 'application/json'
					},
					data: data }).then(() => {
					axios.get('api/ServicioPatrones/ConsultarServicioPatrones', this.config)
						.then((res) => { this.lstserviciopatrones = res.data })
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
