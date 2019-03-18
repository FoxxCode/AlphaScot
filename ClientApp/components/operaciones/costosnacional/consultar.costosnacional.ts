import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_costosnacional {
	iddia!: number;
	idtramo!: number;
	idtarifa!: number;
	idservicio!: number;
	idrango!: number;
	costo!: number;
}

@Component
export default class ConsultarCostosNacionalComponent extends Vue {
	headers: Array < any > = [
	{ text: 'IDDia',align: 'left', sortable: false,value: 'iddia'},
	{ text: 'IDTramo',align: 'left', sortable: false,value: 'idtramo'},
	{ text: 'IDTarifa',align: 'left', sortable: false,value: 'idtarifa'},
	{ text: 'IDServicio',align: 'left', sortable: false,value: 'idservicio'},
	{ text: 'IDRango',align: 'left', sortable: false,value: 'idrango'},
	{ text: 'Costo',align: 'left', sortable: false,value: 'costo'},
	]
	lstcostosnacional: clase_costosnacional[] = [];
	public config = { headers: { 'Content-Type': 'application/json' } };
	public buscarcostosnacional = '';
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
		axios.get('api/costosnacional/ConsultarCostosNacional', this.config)
			.then((res) => {
				this.lstcostosnacional = res.data
				this.totalItems = this.lstcostosnacional.length;
			})
			.catch ((err) => {
		});
	}
	Cancelar(): void {
		this.$router.push({ path: '/' });
	}
	Insertar(): void {
		this.$router.push({ path: '/costosnacional-administrar', query: { operacion: 'Insert' } });
	}
	Actualizar(dataiddia: number,dataidtramo: number,dataidtarifa: number,dataidservicio: number,dataidrango: number): void {
		this.$router.push({ path: '/costosnacional-administrar', query: { iddia: String(dataiddia),idtramo: String(dataidtramo),idtarifa: String(dataidtarifa),idservicio: String(dataidservicio),idrango: String(dataidrango), operacion: 'Update' } });
	}
	Eliminar(data: clase_costosnacional): void {
		swal({
			title: 'Esta seguro de esta operacion?',
			text: "Eliminacion de Registro" + data.iddia + data.idtramo + data.idtarifa + data.idservicio + data.idrango
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
				axios.delete('api/CostosNacional', {
					headers:{
						'Content-Type': 'application/json'
					},
					data: data }).then(() => {
					axios.get('api/CostosNacional/ConsultarCostosNacional', this.config)
						.then((res) => { this.lstcostosnacional = res.data })
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
