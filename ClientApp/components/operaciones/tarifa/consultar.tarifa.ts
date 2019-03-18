import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_tarifa {
	idtarifa!: number;
	idservicio!: number;
	descripcion!: string;
	idciudad!: number;
	idpais!: number;
	etiqueta!: string;
}

@Component
export default class ConsultarTarifaComponent extends Vue {
	headers: Array < any > = [
	{ text: 'IDTarifa',align: 'left', sortable: false,value: 'idtarifa'},
	{ text: 'IDServicio',align: 'left', sortable: false,value: 'idservicio'},
	{ text: 'Descripcion',align: 'left', sortable: false,value: 'descripcion'},
	{ text: 'IDCiudad',align: 'left', sortable: false,value: 'idciudad'},
	{ text: 'IDPais',align: 'left', sortable: false,value: 'idpais'},
	{ text: 'Etiqueta',align: 'left', sortable: false,value: 'etiqueta'},
	]
	lsttarifa: clase_tarifa[] = [];
	public config = { headers: { 'Content-Type': 'application/json' } };
	public buscartarifa = '';
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
		axios.get('api/tarifa/ConsultarTarifa', this.config)
			.then((res) => {
				this.lsttarifa = res.data
				this.totalItems = this.lsttarifa.length;
			})
			.catch ((err) => {
		});
	}
	Cancelar(): void {
		this.$router.push({ path: '/' });
	}
	Insertar(): void {
		this.$router.push({ path: '/tarifa-administrar', query: { operacion: 'Insert' } });
	}
	Actualizar(dataidtarifa: number): void {
		this.$router.push({ path: '/tarifa-administrar', query: { idtarifa: String(dataidtarifa), operacion: 'Update' } });
	}
	Eliminar(data: clase_tarifa): void {
		swal({
			title: 'Esta seguro de esta operacion?',
			text: "Eliminacion de Registro" + data.idtarifa
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
				axios.delete('api/Tarifa', {
					headers:{
						'Content-Type': 'application/json'
					},
					data: data }).then(() => {
					axios.get('api/Tarifa/ConsultarTarifa', this.config)
						.then((res) => { this.lsttarifa = res.data })
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
