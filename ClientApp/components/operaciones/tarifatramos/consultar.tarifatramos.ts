import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_tarifatramos {
	idtramo!: number;
	idtarifa!: number;
	etiqueta!: string;
	horainicio!: string;
	horafinal!: string;
}

@Component
export default class ConsultarTarifaTramosComponent extends Vue {
	headers: Array < any > = [
	{ text: 'IDTramo',align: 'left', sortable: false,value: 'idtramo'},
	{ text: 'IDTarifa',align: 'left', sortable: false,value: 'idtarifa'},
	{ text: 'Etiqueta',align: 'left', sortable: false,value: 'etiqueta'},
	{ text: 'HoraInicio',align: 'left', sortable: false,value: 'horainicio'},
	{ text: 'HoraFinal',align: 'left', sortable: false,value: 'horafinal'},
	]
	lsttarifatramos: clase_tarifatramos[] = [];
	public config = { headers: { 'Content-Type': 'application/json' } };
	public buscartarifatramos = '';
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
		axios.get('api/tarifatramos/ConsultarTarifaTramos', this.config)
			.then((res) => {
				this.lsttarifatramos = res.data
				this.totalItems = this.lsttarifatramos.length;
			})
			.catch ((err) => {
		});
	}
	Cancelar(): void {
		this.$router.push({ path: '/' });
	}
	Insertar(): void {
		this.$router.push({ path: '/tarifatramos-administrar', query: { operacion: 'Insert' } });
	}
	Actualizar(dataidtramo: number): void {
		this.$router.push({ path: '/tarifatramos-administrar', query: { idtramo: String(dataidtramo), operacion: 'Update' } });
	}
	Eliminar(data: clase_tarifatramos): void {
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
				axios.delete('api/TarifaTramos', {
					headers:{
						'Content-Type': 'application/json'
					},
					data: data }).then(() => {
					axios.get('api/TarifaTramos/ConsultarTarifaTramos', this.config)
						.then((res) => { this.lsttarifatramos = res.data })
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
