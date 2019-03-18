import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_comunicacionempresa {
	idcomunicacion!: number;
	idempresa!: number;
	idtipocomunicacion!: string;
	valor!: string;
	pordefecto!: boolean;
}

@Component
export default class ConsultarComunicacionEmpresaComponent extends Vue {
	headers: Array < any > = [
	{ text: 'IDComunicacion',align: 'left', sortable: false,value: 'idcomunicacion'},
	{ text: 'IDEmpresa',align: 'left', sortable: false,value: 'idempresa'},
	{ text: 'IDTipoComunicacion',align: 'left', sortable: false,value: 'idtipocomunicacion'},
	{ text: 'Valor',align: 'left', sortable: false,value: 'valor'},
	{ text: 'PorDefecto',align: 'left', sortable: false,value: 'pordefecto'},
	]
	lstcomunicacionempresa: clase_comunicacionempresa[] = [];
	public config = { headers: { 'Content-Type': 'application/json' } };
	public buscarcomunicacionempresa = '';
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
		axios.get('api/comunicacionempresa/ConsultarComunicacionEmpresa', this.config)
			.then((res) => {
				this.lstcomunicacionempresa = res.data
				this.totalItems = this.lstcomunicacionempresa.length;
			})
			.catch ((err) => {
		});
	}
	Cancelar(): void {
		this.$router.push({ path: '/' });
	}
	Insertar(): void {
		this.$router.push({ path: '/comunicacionempresa-administrar', query: { operacion: 'Insert' } });
	}
	Actualizar(dataidcomunicacion: number,dataidempresa: number): void {
		this.$router.push({ path: '/comunicacionempresa-administrar', query: { idcomunicacion: String(dataidcomunicacion),idempresa: String(dataidempresa), operacion: 'Update' } });
	}
	Eliminar(data: clase_comunicacionempresa): void {
		swal({
			title: 'Esta seguro de esta operacion?',
			text: "Eliminacion de Registro" + data.idcomunicacion + data.idempresa
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
				axios.delete('api/ComunicacionEmpresa', {
					headers:{
						'Content-Type': 'application/json'
					},
					data: data }).then(() => {
					axios.get('api/ComunicacionEmpresa/ConsultarComunicacionEmpresa', this.config)
						.then((res) => { this.lstcomunicacionempresa = res.data })
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
