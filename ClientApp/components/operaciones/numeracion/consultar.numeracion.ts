import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_numeracion {
	idrango!: number;
	descripcion!: string;
	etiqueta!: string;
	numeroinicio!: string;
	numerofinal!: string;
}

@Component
export default class ConsultarNumeracionComponent extends Vue {
	headers: Array < any > = [
	{ text: 'IDRango',align: 'left', sortable: false,value: 'idrango'},
	{ text: 'Descripcion',align: 'left', sortable: false,value: 'descripcion'},
	{ text: 'Etiqueta',align: 'left', sortable: false,value: 'etiqueta'},
	{ text: 'NumeroInicio',align: 'left', sortable: false,value: 'numeroinicio'},
	{ text: 'NumeroFinal',align: 'left', sortable: false,value: 'numerofinal'},
	]
	lstnumeracion: clase_numeracion[] = [];
	public config = { headers: { 'Content-Type': 'application/json' } };
	public buscarnumeracion = '';
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
		axios.get('api/numeracion/ConsultarNumeracion', this.config)
			.then((res) => {
				this.lstnumeracion = res.data
				this.totalItems = this.lstnumeracion.length;
			})
			.catch ((err) => {
		});
	}
	Cancelar(): void {
		this.$router.push({ path: '/' });
	}
	Insertar(): void {
		this.$router.push({ path: '/numeracion-administrar', query: { operacion: 'Insert' } });
	}
	Actualizar(dataidrango: number): void {
		this.$router.push({ path: '/numeracion-administrar', query: { idrango: String(dataidrango), operacion: 'Update' } });
	}
	Eliminar(data: clase_numeracion): void {
		swal({
			title: 'Esta seguro de esta operacion?',
			text: "Eliminacion de Registro" + data.idrango
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
				axios.delete('api/Numeracion', {
					headers:{
						'Content-Type': 'application/json'
					},
					data: data }).then(() => {
					axios.get('api/Numeracion/ConsultarNumeracion', this.config)
						.then((res) => { this.lstnumeracion = res.data })
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
