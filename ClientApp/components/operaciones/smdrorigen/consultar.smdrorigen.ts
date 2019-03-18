import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_smdrorigen {
	idllamada!: string;
	idestado!: number;
	trama!: string;
}

@Component
export default class ConsultarSMDROrigenComponent extends Vue {
	headers: Array < any > = [
	{ text: 'IDLlamada',align: 'left', sortable: false,value: 'idllamada'},
	{ text: 'IDEstado',align: 'left', sortable: false,value: 'idestado'},
	{ text: 'Trama',align: 'left', sortable: false,value: 'trama'},
	]
	lstsmdrorigen: clase_smdrorigen[] = [];
	public config = { headers: { 'Content-Type': 'application/json' } };
	public buscarsmdrorigen = '';
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
		axios.get('api/smdrorigen/ConsultarSMDROrigen', this.config)
			.then((res) => {
				this.lstsmdrorigen = res.data
				this.totalItems = this.lstsmdrorigen.length;
			})
			.catch ((err) => {
		});
	}
	Cancelar(): void {
		this.$router.push({ path: '/' });
	}
	Insertar(): void {
		this.$router.push({ path: '/smdrorigen-administrar', query: { operacion: 'Insert' } });
	}
	Actualizar(dataidllamada: string): void {
		this.$router.push({ path: '/smdrorigen-administrar', query: { idllamada: String(dataidllamada), operacion: 'Update' } });
	}
	Eliminar(data: clase_smdrorigen): void {
		swal({
			title: 'Esta seguro de esta operacion?',
			text: "Eliminacion de Registro" + data.idllamada
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
				axios.delete('api/SMDROrigen', {
					headers:{
						'Content-Type': 'application/json'
					},
					data: data }).then(() => {
					axios.get('api/SMDROrigen/ConsultarSMDROrigen', this.config)
						.then((res) => { this.lstsmdrorigen = res.data })
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
