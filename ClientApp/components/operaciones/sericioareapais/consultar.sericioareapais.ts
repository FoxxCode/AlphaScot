import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_sericioareapais {
	idareapais!: number;
	idservicio!: number;
	idarea!: number;
	idpais!: number;
	fecharegistro!: any;
}

@Component
export default class ConsultarSericioAreaPaisComponent extends Vue {
	headers: Array < any > = [
	{ text: 'IDAreaPais',align: 'left', sortable: false,value: 'idareapais'},
	{ text: 'IDServicio',align: 'left', sortable: false,value: 'idservicio'},
	{ text: 'IDArea',align: 'left', sortable: false,value: 'idarea'},
	{ text: 'IDPais',align: 'left', sortable: false,value: 'idpais'},
	{ text: 'FechaRegistro',align: 'left', sortable: false,value: 'fecharegistro'},
	]
	lstsericioareapais: clase_sericioareapais[] = [];
	public config = { headers: { 'Content-Type': 'application/json' } };
	public buscarsericioareapais = '';
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
		axios.get('api/sericioareapais/ConsultarSericioAreaPais', this.config)
			.then((res) => {
				this.lstsericioareapais = res.data
				this.totalItems = this.lstsericioareapais.length;
			})
			.catch ((err) => {
		});
	}
	Cancelar(): void {
		this.$router.push({ path: '/' });
	}
	Insertar(): void {
		this.$router.push({ path: '/sericioareapais-administrar', query: { operacion: 'Insert' } });
	}
	Actualizar(dataidareapais: number,dataidservicio: number): void {
		this.$router.push({ path: '/sericioareapais-administrar', query: { idareapais: String(dataidareapais),idservicio: String(dataidservicio), operacion: 'Update' } });
	}
	Eliminar(data: clase_sericioareapais): void {
		swal({
			title: 'Esta seguro de esta operacion?',
			text: "Eliminacion de Registro" + data.idareapais + data.idservicio
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
				axios.delete('api/SericioAreaPais', {
					headers:{
						'Content-Type': 'application/json'
					},
					data: data }).then(() => {
					axios.get('api/SericioAreaPais/ConsultarSericioAreaPais', this.config)
						.then((res) => { this.lstsericioareapais = res.data })
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
