import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_continente {
	idcontinente!: number;
	descripcion!: string;
}

@Component
export default class ConsultarContinenteComponent extends Vue {
	headers: Array < any > = [
	{ text: 'IDContinente',align: 'left', sortable: false,value: 'idcontinente'},
	{ text: 'Descripcion',align: 'left', sortable: false,value: 'descripcion'},
	]
	lstcontinente: clase_continente[] = [];
	public config = { headers: { 'Content-Type': 'application/json' } };
	public buscarcontinente = '';
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
		axios.get('api/continente/ConsultarContinente', this.config)
			.then((res) => {
				this.lstcontinente = res.data
				this.totalItems = this.lstcontinente.length;
			})
			.catch ((err) => {
		});
	}
	Cancelar(): void {
		this.$router.push({ path: '/' });
	}
	Insertar(): void {
		this.$router.push({ path: '/continente-administrar', query: { operacion: 'Insert' } });
	}
	Actualizar(dataidcontinente: number): void {
		this.$router.push({ path: '/continente-administrar', query: { idcontinente: String(dataidcontinente), operacion: 'Update' } });
	}
	Eliminar(data: clase_continente): void {
		swal({
			title: 'Esta seguro de esta operacion?',
			text: "Eliminacion de Registro" + data.idcontinente
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
				axios.delete('api/Continente', {
					headers:{
						'Content-Type': 'application/json'
					},
					data: data }).then(() => {
					axios.get('api/Continente/ConsultarContinente', this.config)
						.then((res) => { this.lstcontinente = res.data })
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
