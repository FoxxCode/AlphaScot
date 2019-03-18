import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_costointernacional {
	iddia!: number;
	idtramo!: number;
	idtarifa!: number;
	idservicio!: number;
	idareapais!: number;
	costo!: number;
}

@Component
export default class ConsultarCostoInterNacionalComponent extends Vue {
	headers: Array < any > = [
	{ text: 'IDDia',align: 'left', sortable: false,value: 'iddia'},
	{ text: 'IDTramo',align: 'left', sortable: false,value: 'idtramo'},
	{ text: 'IDTarifa',align: 'left', sortable: false,value: 'idtarifa'},
	{ text: 'IDServicio',align: 'left', sortable: false,value: 'idservicio'},
	{ text: 'IDAreaPais',align: 'left', sortable: false,value: 'idareapais'},
	{ text: 'Costo',align: 'left', sortable: false,value: 'costo'},
	]
	lstcostointernacional: clase_costointernacional[] = [];
	public config = { headers: { 'Content-Type': 'application/json' } };
	public buscarcostointernacional = '';
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
		axios.get('api/costointernacional/ConsultarCostoInterNacional', this.config)
			.then((res) => {
				this.lstcostointernacional = res.data
				this.totalItems = this.lstcostointernacional.length;
			})
			.catch ((err) => {
		});
	}
	Cancelar(): void {
		this.$router.push({ path: '/' });
	}
	Insertar(): void {
		this.$router.push({ path: '/costointernacional-administrar', query: { operacion: 'Insert' } });
	}
	Actualizar(dataiddia: number,dataidtramo: number,dataidtarifa: number,dataidservicio: number,dataidareapais: number): void {
		this.$router.push({ path: '/costointernacional-administrar', query: { iddia: String(dataiddia),idtramo: String(dataidtramo),idtarifa: String(dataidtarifa),idservicio: String(dataidservicio),idareapais: String(dataidareapais), operacion: 'Update' } });
	}
	Eliminar(data: clase_costointernacional): void {
		swal({
			title: 'Esta seguro de esta operacion?',
			text: "Eliminacion de Registro" + data.iddia + data.idtramo + data.idtarifa + data.idservicio + data.idareapais
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
				axios.delete('api/CostoInterNacional', {
					headers:{
						'Content-Type': 'application/json'
					},
					data: data }).then(() => {
					axios.get('api/CostoInterNacional/ConsultarCostoInterNacional', this.config)
						.then((res) => { this.lstcostointernacional = res.data })
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
