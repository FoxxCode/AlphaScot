import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_pais {
	idpais!: number;
	idcontinente!: number;
	descripcion!: string;
}

@Component
export default class ConsultarPaisComponent extends Vue {
	headers: Array < any > = [
	{ text: 'IDPais',align: 'left', sortable: false,value: 'idpais'},
	{ text: 'IDContinente',align: 'left', sortable: false,value: 'idcontinente'},
	{ text: 'Descripcion',align: 'left', sortable: false,value: 'descripcion'},
	]
	lstpais: clase_pais[] = [];
	public config = { headers: { 'Content-Type': 'application/json' } };
	public buscarpais = '';
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
		axios.get('api/pais/ConsultarPais', this.config)
			.then((res) => {
				this.lstpais = res.data
				this.totalItems = this.lstpais.length;
			})
			.catch ((err) => {
		});
	}
	Cancelar(): void {
		this.$router.push({ path: '/' });
	}
	Insertar(): void {
		this.$router.push({ path: '/pais-administrar', query: { operacion: 'Insert' } });
	}
	Actualizar(dataidpais: number): void {
		this.$router.push({ path: '/pais-administrar', query: { idpais: String(dataidpais), operacion: 'Update' } });
	}
	Eliminar(data: clase_pais): void {
		swal({
			title: 'Esta seguro de esta operacion?',
			text: "Eliminacion de Registro" + data.idpais
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
				axios.delete('api/Pais', {
					headers:{
						'Content-Type': 'application/json'
					},
					data: data }).then(() => {
					axios.get('api/Pais/ConsultarPais', this.config)
						.then((res) => { this.lstpais = res.data })
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
