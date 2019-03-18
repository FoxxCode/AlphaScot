import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_paises {
	idpais!: number;
	descripcion!: string;
}

@Component
export default class ConsultarPaisesComponent extends Vue {
	headers: Array < any > = [
	{ text: 'idPais',align: 'left', sortable: false,value: 'idpais'},
	{ text: 'Descripcion',align: 'left', sortable: false,value: 'descripcion'},
	]
    lstpaises: clase_paises[] = [];
	public config = { headers: { 'Content-Type': 'application/json' } };
	public buscarpaises = '';
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
		axios.get('api/paises/ConsultarPaises', this.config)
			.then((res) => {
				this.lstpaises = res.data
				this.totalItems = this.lstpaises.length;
			})
			.catch ((err) => {
		});
	}
	Cancelar(): void {
		this.$router.push({ path: '/' });
	}
	Insertar(): void {
		this.$router.push({ path: '/paises-administrar', query: { operacion: 'Insert' } });
	}
	Actualizar(dataidpais: number): void {
		this.$router.push({ path: '/paises-administrar', query: { idpais: String(dataidpais), operacion: 'Update' } });
	}
    Eliminar(data: clase_paises): void {
		swal({
			title: 'Esta seguro de esta operacion?',
			text: "Eliminacion de Registro" + data.idpais
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
				axios.delete('api/Paises', {
					headers:{
						'Content-Type': 'application/json'
					},
					data: data }).then(() => {
					axios.get('api/Paises/ConsultarPaises', this.config)
						.then((res) => { this.lstpaises = res.data })
						.catch((err) => { });
				}).catch((err) => { })
			}
		})
	}
}
