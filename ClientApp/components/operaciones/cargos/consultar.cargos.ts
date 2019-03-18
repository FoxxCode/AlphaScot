import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_cargos {
	idcargo!: number;
	descripcion!: string;
}

@Component
export default class ConsultarCargosComponent extends Vue {
	headers: Array < any > = [
	{ text: 'IDCargo',align: 'left', sortable: false,value: 'idcargo'},
	{ text: 'Descripcion',align: 'left', sortable: false,value: 'descripcion'},
	]
	lstcargos: clase_cargos[] = [];
	public config = { headers: { 'Content-Type': 'application/json' } };
	public buscarcargos = '';
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
		axios.get('api/cargos/ConsultarCargos', this.config)
			.then((res) => {
				this.lstcargos = res.data
				this.totalItems = this.lstcargos.length;
			})
			.catch ((err) => {
		});
	}
	Cancelar(): void {
		this.$router.push({ path: '/' });
	}
	Insertar(): void {
		this.$router.push({ path: '/cargos-administrar', query: { operacion: 'Insert' } });
	}
	Actualizar(dataidcargo: number): void {
		this.$router.push({ path: '/cargos-administrar', query: { idcargo: String(dataidcargo), operacion: 'Update' } });
	}
	Eliminar(data: clase_cargos): void {
		swal({
			title: 'Esta seguro de esta operacion?',
			text: "Eliminacion de Registro" + data.idcargo
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
				axios.delete('api/Cargos', {
					headers:{
						'Content-Type': 'application/json'
					},
					data: data }).then(() => {
					axios.get('api/Cargos/ConsultarCargos', this.config)
						.then((res) => { this.lstcargos = res.data })
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
