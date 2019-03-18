import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_ciudad {
	idciudad!: number;
	idpais!: number;
	descripcion!: string;
}

@Component
export default class ConsultarCiudadComponent extends Vue {
	headers: Array < any > = [
	{ text: 'IDCiudad',align: 'left', sortable: false,value: 'idciudad'},
	{ text: 'IDPais',align: 'left', sortable: false,value: 'idpais'},
	{ text: 'Descripcion',align: 'left', sortable: false,value: 'descripcion'},
	]
	lstciudad: clase_ciudad[] = [];
	public config = { headers: { 'Content-Type': 'application/json' } };
	public buscarciudad = '';
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
		axios.get('api/ciudad/ConsultarCiudad', this.config)
			.then((res) => {
				this.lstciudad = res.data
				this.totalItems = this.lstciudad.length;
			})
			.catch ((err) => {
		});
	}
	Cancelar(): void {
		this.$router.push({ path: '/' });
	}
	Insertar(): void {
		this.$router.push({ path: '/ciudad-administrar', query: { operacion: 'Insert' } });
	}
	Actualizar(dataidciudad: number,dataidpais: number): void {
		this.$router.push({ path: '/ciudad-administrar', query: { idciudad: String(dataidciudad),idpais: String(dataidpais), operacion: 'Update' } });
	}
	Eliminar(data: clase_ciudad): void {
		swal({
			title: 'Esta seguro de esta operacion?',
			text: "Eliminacion de Registro" + data.idciudad + data.idpais
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
				axios.delete('api/Ciudad', {
					headers:{
						'Content-Type': 'application/json'
					},
					data: data }).then(() => {
					axios.get('api/Ciudad/ConsultarCiudad', this.config)
						.then((res) => { this.lstciudad = res.data })
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
