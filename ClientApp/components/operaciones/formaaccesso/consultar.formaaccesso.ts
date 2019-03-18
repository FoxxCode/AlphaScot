import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_formaaccesso {
	idrol!: number;
	idforma!: number;
	acceso!: boolean;
	insercion!: boolean;
	modificacion!: boolean;
	eliminacion!: boolean;
	consulta!: boolean;
	impresion!: boolean;
	operacion!: boolean;
}

@Component
export default class ConsultarFormaAccessoComponent extends Vue {
	headers: Array < any > = [
	{ text: 'IDRol',align: 'left', sortable: false,value: 'idrol'},
	{ text: 'IDForma',align: 'left', sortable: false,value: 'idforma'},
	{ text: 'Acceso',align: 'left', sortable: false,value: 'acceso'},
	{ text: 'Insercion',align: 'left', sortable: false,value: 'insercion'},
	{ text: 'Modificacion',align: 'left', sortable: false,value: 'modificacion'},
	{ text: 'Eliminacion',align: 'left', sortable: false,value: 'eliminacion'},
	{ text: 'Consulta',align: 'left', sortable: false,value: 'consulta'},
	{ text: 'Impresion',align: 'left', sortable: false,value: 'impresion'},
	{ text: 'Operacion',align: 'left', sortable: false,value: 'operacion'},
	]
	lstformaaccesso: clase_formaaccesso[] = [];
	public config = { headers: { 'Content-Type': 'application/json' } };
	public buscarformaaccesso = '';
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
		axios.get('api/formaaccesso/ConsultarFormaAccesso', this.config)
			.then((res) => {
				this.lstformaaccesso = res.data
				this.totalItems = this.lstformaaccesso.length;
			})
			.catch ((err) => {
		});
	}
	Cancelar(): void {
		this.$router.push({ path: '/' });
	}
	Insertar(): void {
		this.$router.push({ path: '/formaaccesso-administrar', query: { operacion: 'Insert' } });
	}
	Actualizar(dataidrol: number,dataidforma: number): void {
		this.$router.push({ path: '/formaaccesso-administrar', query: { idrol: String(dataidrol),idforma: String(dataidforma), operacion: 'Update' } });
	}
	Eliminar(data: clase_formaaccesso): void {
		swal({
			title: 'Esta seguro de esta operacion?',
			text: "Eliminacion de Registro" + data.idrol + data.idforma
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
				axios.delete('api/FormaAccesso', {
					headers:{
						'Content-Type': 'application/json'
					},
					data: data }).then(() => {
					axios.get('api/FormaAccesso/ConsultarFormaAccesso', this.config)
						.then((res) => { this.lstformaaccesso = res.data })
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
