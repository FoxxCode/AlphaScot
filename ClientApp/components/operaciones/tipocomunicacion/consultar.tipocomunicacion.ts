import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_tipocomunicacion {
	idtipocomunicacion!: string;
	descripcion!: string;
}

@Component
export default class ConsultarTipoComunicacionComponent extends Vue {
	headers: Array < any > = [
	{ text: 'IDTipoComunicacion',align: 'left', sortable: false,value: 'idtipocomunicacion'},
	{ text: 'Descripcion',align: 'left', sortable: false,value: 'descripcion'},
	]
	lsttipocomunicacion: clase_tipocomunicacion[] = [];
	public config = { headers: { 'Content-Type': 'application/json' } };
	public buscartipocomunicacion = '';
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
		axios.get('api/tipocomunicacion/ConsultarTipoComunicacion', this.config)
			.then((res) => {
				this.lsttipocomunicacion = res.data
				this.totalItems = this.lsttipocomunicacion.length;
			})
			.catch ((err) => {
		});
	}
	Cancelar(): void {
		this.$router.push({ path: '/' });
	}
	Insertar(): void {
		this.$router.push({ path: '/tipocomunicacion-administrar', query: { operacion: 'Insert' } });
	}
	Actualizar(dataidtipocomunicacion: string): void {
		this.$router.push({ path: '/tipocomunicacion-administrar', query: { idtipocomunicacion: String(dataidtipocomunicacion), operacion: 'Update' } });
	}
	Eliminar(data: clase_tipocomunicacion): void {
		swal({
			title: 'Esta seguro de esta operacion?',
			text: "Eliminacion de Registro" + data.idtipocomunicacion
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
				axios.delete('api/TipoComunicacion', {
					headers:{
						'Content-Type': 'application/json'
					},
					data: data }).then(() => {
					axios.get('api/TipoComunicacion/ConsultarTipoComunicacion', this.config)
						.then((res) => { this.lsttipocomunicacion = res.data })
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
