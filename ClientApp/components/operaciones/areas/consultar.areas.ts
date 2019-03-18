import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_areas {
	idarea!: number;
	descripcion!: string;
	etiqueta!: string;
}

@Component
export default class ConsultarAreasComponent extends Vue {
	headers: Array < any > = [
	{ text: 'IDArea',align: 'left', sortable: false,value: 'idarea'},
	{ text: 'Descripcion',align: 'left', sortable: false,value: 'descripcion'},
	{ text: 'Etiqueta',align: 'left', sortable: false,value: 'etiqueta'},
	]
	lstareas: clase_areas[] = [];
	public config = { headers: { 'Content-Type': 'application/json' } };
	public buscarareas = '';
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
		axios.get('api/areas/ConsultarAreas', this.config)
			.then((res) => {
				this.lstareas = res.data
				this.totalItems = this.lstareas.length;
			})
			.catch ((err) => {
		});
	}
	Cancelar(): void {
		this.$router.push({ path: '/' });
	}
	Insertar(): void {
		this.$router.push({ path: '/areas-administrar', query: { operacion: 'Insert' } });
	}
	Actualizar(dataidarea: number): void {
		this.$router.push({ path: '/areas-administrar', query: { idarea: String(dataidarea), operacion: 'Update' } });
	}
	Eliminar(data: clase_areas): void {
		swal({
			title: 'Esta seguro de esta operacion?',
			text: "Eliminacion de Registro" + data.idarea
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
				axios.delete('api/Areas', {
					headers:{
						'Content-Type': 'application/json'
					},
					data: data }).then(() => {
					axios.get('api/Areas/ConsultarAreas', this.config)
						.then((res) => { this.lstareas = res.data })
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
