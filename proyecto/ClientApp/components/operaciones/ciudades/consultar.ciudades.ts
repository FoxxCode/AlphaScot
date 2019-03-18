import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

interface clase_ciudades {
	idciudad: number;
	descripcion: string;
	idpais: number;
}
interface clase_paises {
    idpais: number;
    descripcion: string;
}
@Component
export default class ConsultarCiudadesComponent extends Vue {
	headers: Array < any > = [
	{ text: 'Descripcion',align: 'left', sortable: false,value: 'descripcion'},
	{ text: 'IdPais',align: 'left', sortable: false,value: 'idpais'},
	]
    lstciudades: clase_ciudades[] = [];
	public config = { headers: { 'Content-Type': 'application/json' } };
	public buscarciudades = '';
	public rowsPerPageText = 'Registros por Pagina:';
	public rowsperpageitems: number[] = [10, 50, 100];
	public rowsPerPage = 0;
	public totalItems = 0;
    lstpaises: clase_paises[] = [];

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
            })
            .catch((err) => {
            });
		axios.get('api/ciudades/ConsultarCiudades', this.config)
			.then((res) => {
				this.lstciudades = res.data
				this.totalItems = this.lstciudades.length;
			})
			.catch ((err) => {
		});
    }
    select_pais(id: number) {
        let data: string = '';
        this.lstpaises.forEach(function (value) {
            if (value.idpais == id)
                data = value.descripcion;
        });
        return data;
    }
	Cancelar(): void {
		this.$router.push({ path: '/' });
	}
	Insertar(): void {
		this.$router.push({ path: '/ciudades-administrar', query: { operacion: 'Insert' } });
	}
	Actualizar(dataidciudad: number): void {
		this.$router.push({ path: '/ciudades-administrar', query: { idciudad: String(dataidciudad), operacion: 'Update' } });
	}
	Eliminar(data: clase_ciudades): void {
		swal({
			title: 'Esta seguro de esta operacion?',
			text: "Eliminacion de Registro" + data.idciudad
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
				axios.delete('api/Ciudades', {
					headers:{
						'Content-Type': 'application/json'
					},
					data: data }).then(() => {
					axios.get('api/Ciudades/ConsultarCiudades', this.config)
						.then((res) => { this.lstciudades = res.data })
						.catch((err) => { });
				}).catch((err) => { })
			}
		})
	}
}
