import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_patrones {
	idpatron!: string;
	descripcion!: string;
}

@Component
export default class ConsultarPatronesComponent extends Vue {
	headers: Array < any > = [
	{ text: 'IDPatron',align: 'left', sortable: false,value: 'idpatron'},
	{ text: 'Descripcion',align: 'left', sortable: false,value: 'descripcion'},
	]
	lstpatrones: clase_patrones[] = [];
	public config = { headers: { 'Content-Type': 'application/json' } };
	public buscarpatrones = '';
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
		axios.get('api/patrones/ConsultarPatrones', this.config)
			.then((res) => {
				this.lstpatrones = res.data
				this.totalItems = this.lstpatrones.length;
			})
			.catch ((err) => {
		});
	}
	Cancelar(): void {
		this.$router.push({ path: '/' });
	}
	Insertar(): void {
		this.$router.push({ path: '/patrones-administrar', query: { operacion: 'Insert' } });
	}
	Actualizar(dataidpatron: string): void {
		this.$router.push({ path: '/patrones-administrar', query: { idpatron: String(dataidpatron), operacion: 'Update' } });
	}
	Eliminar(data: clase_patrones): void {
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
				axios.delete('api/Patrones', {
					headers:{
						'Content-Type': 'application/json'
					},
					data: data }).then(() => {
					axios.get('api/Patrones/ConsultarPatrones', this.config)
						.then((res) => { this.lstpatrones = res.data })
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
