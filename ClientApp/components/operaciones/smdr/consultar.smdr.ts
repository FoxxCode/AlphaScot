import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_smdr {
	idllamada!: string;
	idestado!: number;
	codigo!: string;
	fecha!: string;
	hora!: string;
	duracion!: string;
	linea!: string;
	interno!: string;
	cuenta!: string;
	numero!: string;
}

@Component
export default class ConsultarSMDRComponent extends Vue {
	headers: Array < any > = [
	{ text: 'IDLlamada',align: 'left', sortable: false,value: 'idllamada'},
	{ text: 'IDEstado',align: 'left', sortable: false,value: 'idestado'},
	{ text: 'Codigo',align: 'left', sortable: false,value: 'codigo'},
	{ text: 'Fecha',align: 'left', sortable: false,value: 'fecha'},
	{ text: 'Hora',align: 'left', sortable: false,value: 'hora'},
	{ text: 'Duracion',align: 'left', sortable: false,value: 'duracion'},
	{ text: 'Linea',align: 'left', sortable: false,value: 'linea'},
	{ text: 'Interno',align: 'left', sortable: false,value: 'interno'},
	{ text: 'Cuenta',align: 'left', sortable: false,value: 'cuenta'},
	{ text: 'Numero',align: 'left', sortable: false,value: 'numero'},
	]
	lstsmdr: clase_smdr[] = [];
	public config = { headers: { 'Content-Type': 'application/json' } };
	public buscarsmdr = '';
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
		axios.get('api/smdr/ConsultarSMDR', this.config)
			.then((res) => {
				this.lstsmdr = res.data
				this.totalItems = this.lstsmdr.length;
			})
			.catch ((err) => {
		});
	}
	Cancelar(): void {
		this.$router.push({ path: '/' });
	}
	Insertar(): void {
		this.$router.push({ path: '/smdr-administrar', query: { operacion: 'Insert' } });
	}
	Actualizar(dataidllamada: string): void {
		this.$router.push({ path: '/smdr-administrar', query: { idllamada: String(dataidllamada), operacion: 'Update' } });
	}
	Eliminar(data: clase_smdr): void {
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
				axios.delete('api/SMDR', {
					headers:{
						'Content-Type': 'application/json'
					},
					data: data }).then(() => {
					axios.get('api/SMDR/ConsultarSMDR', this.config)
						.then((res) => { this.lstsmdr = res.data })
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
