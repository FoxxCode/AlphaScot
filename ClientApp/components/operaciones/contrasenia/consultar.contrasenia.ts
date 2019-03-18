import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_contrasenia {
	idusuario!: string;
	fecharegistro!: any;
	clave!: string;
}

@Component
export default class ConsultarContraseniaComponent extends Vue {
	headers: Array < any > = [
	{ text: 'IDUsuario',align: 'left', sortable: false,value: 'idusuario'},
	{ text: 'FechaRegistro',align: 'left', sortable: false,value: 'fecharegistro'},
	{ text: 'Clave',align: 'left', sortable: false,value: 'clave'},
	]
	lstcontrasenia: clase_contrasenia[] = [];
	public config = { headers: { 'Content-Type': 'application/json' } };
	public buscarcontrasenia = '';
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
		axios.get('api/contrasenia/ConsultarContrasenia', this.config)
			.then((res) => {
				this.lstcontrasenia = res.data
				this.totalItems = this.lstcontrasenia.length;
			})
			.catch ((err) => {
		});
	}
	Cancelar(): void {
		this.$router.push({ path: '/' });
	}
	Insertar(): void {
		this.$router.push({ path: '/contrasenia-administrar', query: { operacion: 'Insert' } });
	}
	Actualizar(dataidusuario: string,datafecharegistro: any): void {
		this.$router.push({ path: '/contrasenia-administrar', query: { idusuario: String(dataidusuario),fecharegistro: String(datafecharegistro), operacion: 'Update' } });
	}
	Eliminar(data: clase_contrasenia): void {
		swal({
			title: 'Esta seguro de esta operacion?',
			text: "Eliminacion de Registro" + data.idusuario + data.fecharegistro
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
				axios.delete('api/Contrasenia', {
					headers:{
						'Content-Type': 'application/json'
					},
					data: data }).then(() => {
					axios.get('api/Contrasenia/ConsultarContrasenia', this.config)
						.then((res) => { this.lstcontrasenia = res.data })
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
