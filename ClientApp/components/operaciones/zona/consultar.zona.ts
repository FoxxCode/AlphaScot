import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_zona {
	idzona!: string;
	descripcion!: string;
}

@Component
export default class ConsultarZonaComponent extends Vue {
	headers: Array < any > = [
	{ text: 'IDZona',align: 'left', sortable: false,value: 'idzona'},
	{ text: 'Descripcion',align: 'left', sortable: false,value: 'descripcion'},
	]
	lstzona: clase_zona[] = [];
	public config = { headers: { 'Content-Type': 'application/json' } };
	public buscarzona = '';
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
		axios.get('api/zona/ConsultarZona', this.config)
			.then((res) => {
				this.lstzona = res.data
				this.totalItems = this.lstzona.length;
			})
			.catch ((err) => {
		});
	}
	Cancelar(): void {
		this.$router.push({ path: '/' });
	}
	Insertar(): void {
		this.$router.push({ path: '/zona-administrar', query: { operacion: 'Insert' } });
	}
	Actualizar(dataidzona: string): void {
		this.$router.push({ path: '/zona-administrar', query: { idzona: String(dataidzona), operacion: 'Update' } });
	}
	Eliminar(data: clase_zona): void {
		swal({
			title: 'Esta seguro de esta operacion?',
			text: "Eliminacion de Registro" + data.idzona
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
				axios.delete('api/Zona', {
					headers:{
						'Content-Type': 'application/json'
					},
					data: data }).then(() => {
					axios.get('api/Zona/ConsultarZona', this.config)
						.then((res) => { this.lstzona = res.data })
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
