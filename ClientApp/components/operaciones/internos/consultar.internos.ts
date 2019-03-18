import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_internos {
	idinterno!: string;
	idcentral!: number;
	descripcion!: string;
	etiqueta!: string;
}

@Component
export default class ConsultarInternosComponent extends Vue {
	headers: Array < any > = [
	{ text: 'IDInterno',align: 'left', sortable: false,value: 'idinterno'},
	{ text: 'IDCentral',align: 'left', sortable: false,value: 'idcentral'},
	{ text: 'Descripcion',align: 'left', sortable: false,value: 'descripcion'},
	{ text: 'Etiqueta',align: 'left', sortable: false,value: 'etiqueta'},
	]
	lstinternos: clase_internos[] = [];
	public config = { headers: { 'Content-Type': 'application/json' } };
	public buscarinternos = '';
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
		axios.get('api/internos/ConsultarInternos', this.config)
			.then((res) => {
				this.lstinternos = res.data
				this.totalItems = this.lstinternos.length;
			})
			.catch ((err) => {
		});
	}
	Cancelar(): void {
		this.$router.push({ path: '/' });
	}
	Insertar(): void {
		this.$router.push({ path: '/internos-administrar', query: { operacion: 'Insert' } });
	}
	Actualizar(dataidinterno: string,dataidcentral: number): void {
		this.$router.push({ path: '/internos-administrar', query: { idinterno: String(dataidinterno),idcentral: String(dataidcentral), operacion: 'Update' } });
	}
	Eliminar(data: clase_internos): void {
		swal({
			title: 'Esta seguro de esta operacion?',
			text: "Eliminacion de Registro" + data.idinterno + data.idcentral
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
				axios.delete('api/Internos', {
					headers:{
						'Content-Type': 'application/json'
					},
					data: data }).then(() => {
					axios.get('api/Internos/ConsultarInternos', this.config)
						.then((res) => { this.lstinternos = res.data })
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
