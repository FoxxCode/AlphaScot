import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_comunicacionusuario {
	idcomunicacion!: number;
	idtipocomunicacion!: string;
	valor!: string;
	pordefecto!: boolean;
}

@Component
export default class ConsultarComunicacionUsuarioComponent extends Vue {
	headers: Array < any > = [
	{ text: 'IDComunicacion',align: 'left', sortable: false,value: 'idcomunicacion'},
	{ text: 'IDTipoComunicacion',align: 'left', sortable: false,value: 'idtipocomunicacion'},
	{ text: 'Valor',align: 'left', sortable: false,value: 'valor'},
	{ text: 'PorDefecto',align: 'left', sortable: false,value: 'pordefecto'},
	]
	lstcomunicacionusuario: clase_comunicacionusuario[] = [];
	public config = { headers: { 'Content-Type': 'application/json' } };
	public buscarcomunicacionusuario = '';
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
		axios.get('api/comunicacionusuario/ConsultarComunicacionUsuario', this.config)
			.then((res) => {
				this.lstcomunicacionusuario = res.data
				this.totalItems = this.lstcomunicacionusuario.length;
			})
			.catch ((err) => {
		});
	}
	Cancelar(): void {
		this.$router.push({ path: '/' });
	}
	Insertar(): void {
		this.$router.push({ path: '/comunicacionusuario-administrar', query: { operacion: 'Insert' } });
	}
	Actualizar(dataidcomunicacion: number): void {
		this.$router.push({ path: '/comunicacionusuario-administrar', query: { idcomunicacion: String(dataidcomunicacion), operacion: 'Update' } });
	}
	Eliminar(data: clase_comunicacionusuario): void {
		swal({
			title: 'Esta seguro de esta operacion?',
			text: "Eliminacion de Registro" + data.idcomunicacion
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
				axios.delete('api/ComunicacionUsuario', {
					headers:{
						'Content-Type': 'application/json'
					},
					data: data }).then(() => {
					axios.get('api/ComunicacionUsuario/ConsultarComunicacionUsuario', this.config)
						.then((res) => { this.lstcomunicacionusuario = res.data })
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
