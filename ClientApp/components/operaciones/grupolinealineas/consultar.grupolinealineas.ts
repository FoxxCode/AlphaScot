import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_grupolinealineas {
	idgrupo!: number;
	idlinea!: string;
	idcentral!: number;
	fecharegistro!: any;
}

@Component
export default class ConsultarGrupoLineaLineasComponent extends Vue {
	headers: Array < any > = [
	{ text: 'IDGrupo',align: 'left', sortable: false,value: 'idgrupo'},
	{ text: 'IDLinea',align: 'left', sortable: false,value: 'idlinea'},
	{ text: 'IDCentral',align: 'left', sortable: false,value: 'idcentral'},
	{ text: 'Fecharegistro',align: 'left', sortable: false,value: 'fecharegistro'},
	]
	lstgrupolinealineas: clase_grupolinealineas[] = [];
	public config = { headers: { 'Content-Type': 'application/json' } };
	public buscargrupolinealineas = '';
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
		axios.get('api/grupolinealineas/ConsultarGrupoLineaLineas', this.config)
			.then((res) => {
				this.lstgrupolinealineas = res.data
				this.totalItems = this.lstgrupolinealineas.length;
			})
			.catch ((err) => {
		});
	}
	Cancelar(): void {
		this.$router.push({ path: '/' });
	}
	Insertar(): void {
		this.$router.push({ path: '/grupolinealineas-administrar', query: { operacion: 'Insert' } });
	}
	Actualizar(dataidgrupo: number,dataidlinea: string,dataidcentral: number): void {
		this.$router.push({ path: '/grupolinealineas-administrar', query: { idgrupo: String(dataidgrupo),idlinea: String(dataidlinea),idcentral: String(dataidcentral), operacion: 'Update' } });
	}
	Eliminar(data: clase_grupolinealineas): void {
		swal({
			title: 'Esta seguro de esta operacion?',
			text: "Eliminacion de Registro" + data.idgrupo + data.idlinea + data.idcentral
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
				axios.delete('api/GrupoLineaLineas', {
					headers:{
						'Content-Type': 'application/json'
					},
					data: data }).then(() => {
					axios.get('api/GrupoLineaLineas/ConsultarGrupoLineaLineas', this.config)
						.then((res) => { this.lstgrupolinealineas = res.data })
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
