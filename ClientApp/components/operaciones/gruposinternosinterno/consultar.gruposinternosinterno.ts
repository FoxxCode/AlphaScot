import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_gruposinternosinterno {
	idinterno!: string;
	idcentral!: number;
	idgrupo!: number;
	fecharegistro!: any;
}

@Component
export default class ConsultarGruposInternosInternoComponent extends Vue {
	headers: Array < any > = [
	{ text: 'IDInterno',align: 'left', sortable: false,value: 'idinterno'},
	{ text: 'IDCentral',align: 'left', sortable: false,value: 'idcentral'},
	{ text: 'IDGrupo',align: 'left', sortable: false,value: 'idgrupo'},
	{ text: 'FechaRegistro',align: 'left', sortable: false,value: 'fecharegistro'},
	]
	lstgruposinternosinterno: clase_gruposinternosinterno[] = [];
	public config = { headers: { 'Content-Type': 'application/json' } };
	public buscargruposinternosinterno = '';
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
		axios.get('api/gruposinternosinterno/ConsultarGruposInternosInterno', this.config)
			.then((res) => {
				this.lstgruposinternosinterno = res.data
				this.totalItems = this.lstgruposinternosinterno.length;
			})
			.catch ((err) => {
		});
	}
	Cancelar(): void {
		this.$router.push({ path: '/' });
	}
	Insertar(): void {
		this.$router.push({ path: '/gruposinternosinterno-administrar', query: { operacion: 'Insert' } });
	}
	Actualizar(dataidinterno: string,dataidcentral: number,dataidgrupo: number): void {
		this.$router.push({ path: '/gruposinternosinterno-administrar', query: { idinterno: String(dataidinterno),idcentral: String(dataidcentral),idgrupo: String(dataidgrupo), operacion: 'Update' } });
	}
	Eliminar(data: clase_gruposinternosinterno): void {
		swal({
			title: 'Esta seguro de esta operacion?',
			text: "Eliminacion de Registro" + data.idinterno + data.idcentral + data.idgrupo
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
				axios.delete('api/GruposInternosInterno', {
					headers:{
						'Content-Type': 'application/json'
					},
					data: data }).then(() => {
					axios.get('api/GruposInternosInterno/ConsultarGruposInternosInterno', this.config)
						.then((res) => { this.lstgruposinternosinterno = res.data })
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
