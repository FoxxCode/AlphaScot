import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_servicionumeracion {
	idrango!: number;
	idservicio!: number;
	idciudad!: number;
	idpais!: number;
	descripcion!: string;
	etiqueta!: string;
	numeroinicio!: string;
	numerofinal!: string;
}

@Component
export default class ConsultarServicioNumeracionComponent extends Vue {
	headers: Array < any > = [
	{ text: 'IDRango',align: 'left', sortable: false,value: 'idrango'},
	{ text: 'IDServicio',align: 'left', sortable: false,value: 'idservicio'},
	{ text: 'IDCiudad',align: 'left', sortable: false,value: 'idciudad'},
	{ text: 'IDPais',align: 'left', sortable: false,value: 'idpais'},
	{ text: 'Descripcion',align: 'left', sortable: false,value: 'descripcion'},
	{ text: 'Etiqueta',align: 'left', sortable: false,value: 'etiqueta'},
	{ text: 'NumeroInicio',align: 'left', sortable: false,value: 'numeroinicio'},
	{ text: 'NumeroFinal',align: 'left', sortable: false,value: 'numerofinal'},
	]
	lstservicionumeracion: clase_servicionumeracion[] = [];
	public config = { headers: { 'Content-Type': 'application/json' } };
	public buscarservicionumeracion = '';
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
		axios.get('api/servicionumeracion/ConsultarServicioNumeracion', this.config)
			.then((res) => {
				this.lstservicionumeracion = res.data
				this.totalItems = this.lstservicionumeracion.length;
			})
			.catch ((err) => {
		});
	}
	Cancelar(): void {
		this.$router.push({ path: '/' });
	}
	Insertar(): void {
		this.$router.push({ path: '/servicionumeracion-administrar', query: { operacion: 'Insert' } });
	}
	Actualizar(dataidrango: number,dataidservicio: number): void {
		this.$router.push({ path: '/servicionumeracion-administrar', query: { idrango: String(dataidrango),idservicio: String(dataidservicio), operacion: 'Update' } });
	}
	Eliminar(data: clase_servicionumeracion): void {
		swal({
			title: 'Esta seguro de esta operacion?',
			text: "Eliminacion de Registro" + data.idrango + data.idservicio
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
				axios.delete('api/ServicioNumeracion', {
					headers:{
						'Content-Type': 'application/json'
					},
					data: data }).then(() => {
					axios.get('api/ServicioNumeracion/ConsultarServicioNumeracion', this.config)
						.then((res) => { this.lstservicionumeracion = res.data })
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
