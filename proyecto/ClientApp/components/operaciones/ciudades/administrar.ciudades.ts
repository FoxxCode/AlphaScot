import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';
import swal from 'sweetalert2';

class clase_ciudades {
	idciudad!: number;
	descripcion!: string;
	idpais!: number;
}

class clase_paises {
    idpais!: number;
    descripcion!: string;
}

@Component
export default class AdministrarCiudadesComponent extends Vue {
	public ciudades = new clase_ciudades();
	public config = { headers: { 'Content-Type': 'application/json' } };
	public error: string = '';
    operacion = '';
    lstpaises: clase_ciudades[] = [];
    pais = new clase_paises();

	created() {
	}
    mounted() {
        axios.get('api/paises/ConsultarPaises', this.config).then((res) => {
                this.lstpaises = res.data
            }).catch((err) => { });
		this.operacion = this.$route.query.operacion;
		if (this.operacion == 'Update') {
			this.ciudades.idciudad = Number(this.$route.query.idciudad);
			const params = new URLSearchParams();
			params.append('idciudad', this.ciudades.idciudad.toString());
			axios.get('api/ciudades/BuscarCiudades?' + params, this.config).then((res) => {
                this.ciudades = res.data
                this.getpais(this.ciudades.idpais);
			}).catch((err) => {});
		};
    }
    getpais(id: number) {
        this.pais.idpais = id;
        this.pais.idpais = Number(this.pais.idpais);
        const params = new URLSearchParams();
        params.append('idpais', this.pais.idpais.toString());
        axios.get('api/paises/BuscarPaises?' + params, this.config).then((res) => {
            this.pais = res.data
        }).catch((err) => { });
    }
	Cancelar(): void {
		this.$router.push({ path: '/ciudades-consultar' });
    }
    select(val:number) {
       
        }
    Grabar(): void {
        this.ciudades.idpais = this.pais.idpais;
		if (this.operacion == 'Update') {
			axios.put('api/Ciudades', this.ciudades, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Modificado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/ciudades-consultar' })
				}).catch((err) => {
				})
		}
		else {
			axios.post('api/ciudades', this.ciudades, this.config)
				.then(() => {
					swal({
						type: 'success',
						title: 'Su registro fue Ingresado',
						showConfirmButton: false,
						timer: 1500
					})
					this.$router.push({ path: '/ciudades-consultar' })
				}).catch((err) => {
				})
		}
	}
}
