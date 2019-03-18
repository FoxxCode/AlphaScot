import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_forma {
	idforma!: number;
	titulo!: string;
}

@Component
export default class ConsultarFormaComponent extends Vue {
	headers: Array < any > = [
	{ text: 'IDForma',align: 'left', sortable: false,value: 'idforma'},
	{ text: 'Titulo',align: 'left', sortable: false,value: 'titulo'},
	]
	lstforma: clase_forma[] = [];
	public config = { headers: { 'Content-Type': 'application/json' } };
	public buscarforma = '';
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
		axios.get('api/forma/ConsultarForma', this.config)
			.then((res) => {
				this.lstforma = res.data
				this.totalItems = this.lstforma.length;
			})
			.catch ((err) => {
		});
	}
	Cancelar(): void {
		this.$router.push({ path: '/' });
	}
	Insertar(): void {
		this.$router.push({ path: '/forma-administrar', query: { operacion: 'Insert' } });
	}
	Actualizar(dataidforma: number): void {
		this.$router.push({ path: '/forma-administrar', query: { idforma: String(dataidforma), operacion: 'Update' } });
	}
	Eliminar(data: clase_forma): void {
		swal({
			title: 'Esta seguro de esta operacion?',
			text: "Eliminacion de Registro" + data.idforma
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
				axios.delete('api/Forma', {
					headers:{
						'Content-Type': 'application/json'
					},
					data: data }).then(() => {
					axios.get('api/Forma/ConsultarForma', this.config)
						.then((res) => { this.lstforma = res.data })
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
