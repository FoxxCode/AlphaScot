import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_tramos {
	idtramo!: number;
	etiqueta!: string;
	horainicio!: string;
	horafinal!: string;
}

@Component
export default class ConsultarTramosComponent extends Vue {
	headers: Array < any > = [
	{ text: 'IDTramo',align: 'left', sortable: false,value: 'idtramo'},
	{ text: 'Etiqueta',align: 'left', sortable: false,value: 'etiqueta'},
	{ text: 'HoraInicio',align: 'left', sortable: false,value: 'horainicio'},
	{ text: 'HoraFinal',align: 'left', sortable: false,value: 'horafinal'},
	]
	lsttramos: clase_tramos[] = [];
	public config = { headers: { 'Content-Type': 'application/json' } };
	public buscartramos = '';
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
		axios.get('api/tramos/ConsultarTramos', this.config)
			.then((res) => {
				this.lsttramos = res.data
				this.totalItems = this.lsttramos.length;
			})
			.catch ((err) => {
		});
	}
	Cancelar(): void {
		this.$router.push({ path: '/' });
	}
	Insertar(): void {
		this.$router.push({ path: '/tramos-administrar', query: { operacion: 'Insert' } });
	}
	Actualizar(dataidtramo: number): void {
		this.$router.push({ path: '/tramos-administrar', query: { idtramo: String(dataidtramo), operacion: 'Update' } });
	}
	Eliminar(data: clase_tramos): void {
		swal({
			title: 'Esta seguro de esta operacion?',
			text: "Eliminacion de Registro" + data.idtramo
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
				axios.delete('api/Tramos', {
					headers:{
						'Content-Type': 'application/json'
					},
					data: data }).then(() => {
					axios.get('api/Tramos/ConsultarTramos', this.config)
						.then((res) => { this.lsttramos = res.data })
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
