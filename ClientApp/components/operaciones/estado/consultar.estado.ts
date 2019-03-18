import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_estado {
	idestado!: number;
	descripcion!: string;
	etiqueta!: string;
}

@Component
export default class ConsultarEstadoComponent extends Vue {
	headers: Array < any > = [
	{ text: 'IDEstado',align: 'left', sortable: false,value: 'idestado'},
	{ text: 'Descripcion',align: 'left', sortable: false,value: 'descripcion'},
	{ text: 'Etiqueta',align: 'left', sortable: false,value: 'etiqueta'},
	]
	lstestado: clase_estado[] = [];
	public config = { headers: { 'Content-Type': 'application/json' } };
	public buscarestado = '';
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
		axios.get('api/estado/ConsultarEstado', this.config)
			.then((res) => {
				this.lstestado = res.data
				this.totalItems = this.lstestado.length;
			})
			.catch ((err) => {
		});
	}
	Cancelar(): void {
		this.$router.push({ path: '/' });
	}
	Insertar(): void {
		this.$router.push({ path: '/estado-administrar', query: { operacion: 'Insert' } });
	}
	Actualizar(dataidestado: number): void {
		this.$router.push({ path: '/estado-administrar', query: { idestado: String(dataidestado), operacion: 'Update' } });
	}
	Eliminar(data: clase_estado): void {
		swal({
			title: 'Esta seguro de esta operacion?',
			text: "Eliminacion de Registro" + data.idestado
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
				axios.delete('api/Estado', {
					headers:{
						'Content-Type': 'application/json'
					},
					data: data }).then(() => {
					axios.get('api/Estado/ConsultarEstado', this.config)
						.then((res) => { this.lstestado = res.data })
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
