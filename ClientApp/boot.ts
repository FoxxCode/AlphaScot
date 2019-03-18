	import 'whatwg-fetch';

import Vue from 'vue';
import VueRouter from 'vue-router';
import Vuetify from 'vuetify';

const App =require('./components/app/app.vue');
import store from './store/store';
import colors from 'vuetify/es5/util/colors'

Vue.use(VueRouter);
Vue.use(Vuetify, {
    theme: {
        primary: colors.grey.darken3,
        secondary: colors.teal.darken4,
        accent: colors.indigo.base,
        error: '#FF5252',
        info: '#2196F3',
        success: '#4CAF50',
        warning: '#FFC107'
    }
});

const routes = [
    { path: '/', component: require('./components/inicio/inicio.vue') },
    { path: '/principal', component: require('./components/principal/principal.vue') },
    { path: '/login', component: require('./components/login/login.vue') },
    { path: '/areas-consultar', component: require('./components/operaciones/areas/consultar.areas.vue') },
    { path: '/areas-administrar', component: require('./components/operaciones/areas/administrar.areas.vue') },
    { path: '/cargos-consultar', component: require('./components/operaciones/cargos/consultar.cargos.vue') },
    { path: '/cargos-administrar', component: require('./components/operaciones/cargos/administrar.cargos.vue') },
    { path: '/central-consultar', component: require('./components/operaciones/central/consultar.central.vue') },
    { path: '/central-administrar', component: require('./components/operaciones/central/administrar.central.vue') },
    { path: '/ciudad-consultar', component: require('./components/operaciones/ciudad/consultar.ciudad.vue') },
    { path: '/ciudad-administrar', component: require('./components/operaciones/ciudad/administrar.ciudad.vue') },
    { path: '/codigoscentral-consultar', component: require('./components/operaciones/codigoscentral/consultar.codigoscentral.vue') },
    { path: '/codigoscentral-administrar', component: require('./components/operaciones/codigoscentral/administrar.codigoscentral.vue') },
    { path: '/comunicacionempresa-consultar', component: require('./components/operaciones/comunicacionempresa/consultar.comunicacionempresa.vue') },
    { path: '/comunicacionempresa-administrar', component: require('./components/operaciones/comunicacionempresa/administrar.comunicacionempresa.vue') },
    { path: '/comunicacionusuario-consultar', component: require('./components/operaciones/comunicacionusuario/consultar.comunicacionusuario.vue') },
    { path: '/comunicacionusuario-administrar', component: require('./components/operaciones/comunicacionusuario/administrar.comunicacionusuario.vue') },
    { path: '/continente-consultar', component: require('./components/operaciones/continente/consultar.continente.vue') },
    { path: '/continente-administrar', component: require('./components/operaciones/continente/administrar.continente.vue') },
    { path: '/contrasenia-consultar', component: require('./components/operaciones/contrasenia/consultar.contrasenia.vue') },
    { path: '/contrasenia-administrar', component: require('./components/operaciones/contrasenia/administrar.contrasenia.vue') },
    { path: '/costeo-consultar', component: require('./components/operaciones/costeo/consultar.costeo.vue') },
    { path: '/costeo-administrar', component: require('./components/operaciones/costeo/administrar.costeo.vue') },
    { path: '/costointernacional-consultar', component: require('./components/operaciones/costointernacional/consultar.costointernacional.vue') },
    { path: '/costointernacional-administrar', component: require('./components/operaciones/costointernacional/administrar.costointernacional.vue') },
    { path: '/costosnacional-consultar', component: require('./components/operaciones/costosnacional/consultar.costosnacional.vue') },
    { path: '/costosnacional-administrar', component: require('./components/operaciones/costosnacional/administrar.costosnacional.vue') },
    { path: '/cuentas-consultar', component: require('./components/operaciones/cuentas/consultar.cuentas.vue') },
    { path: '/cuentas-administrar', component: require('./components/operaciones/cuentas/administrar.cuentas.vue') },
    { path: '/departamento-consultar', component: require('./components/operaciones/departamento/consultar.departamento.vue') },
    { path: '/departamento-administrar', component: require('./components/operaciones/departamento/administrar.departamento.vue') },
    { path: '/direccionempresa-consultar', component: require('./components/operaciones/direccionempresa/consultar.direccionempresa.vue') },
    { path: '/direccionempresa-administrar', component: require('./components/operaciones/direccionempresa/administrar.direccionempresa.vue') },
    { path: '/direccionusuario-consultar', component: require('./components/operaciones/direccionusuario/consultar.direccionusuario.vue') },
    { path: '/direccionusuario-administrar', component: require('./components/operaciones/direccionusuario/administrar.direccionusuario.vue') },
    { path: '/empresa-consultar', component: require('./components/operaciones/empresa/consultar.empresa.vue') },
    { path: '/empresa-administrar', component: require('./components/operaciones/empresa/administrar.empresa.vue') },
    { path: '/estado-consultar', component: require('./components/operaciones/estado/consultar.estado.vue') },
    { path: '/estado-administrar', component: require('./components/operaciones/estado/administrar.estado.vue') },
    { path: '/forma-consultar', component: require('./components/operaciones/forma/consultar.forma.vue') },
    { path: '/forma-administrar', component: require('./components/operaciones/forma/administrar.forma.vue') },
    { path: '/formaaccesso-consultar', component: require('./components/operaciones/formaaccesso/consultar.formaaccesso.vue') },
    { path: '/formaaccesso-administrar', component: require('./components/operaciones/formaaccesso/administrar.formaaccesso.vue') },
    { path: '/grupolinealineas-consultar', component: require('./components/operaciones/grupolinealineas/consultar.grupolinealineas.vue') },
    { path: '/grupolinealineas-administrar', component: require('./components/operaciones/grupolinealineas/administrar.grupolinealineas.vue') },
    { path: '/gruposcuentas-consultar', component: require('./components/operaciones/gruposcuentas/consultar.gruposcuentas.vue') },
    { path: '/gruposcuentas-administrar', component: require('./components/operaciones/gruposcuentas/administrar.gruposcuentas.vue') },
    { path: '/gruposcuentascuenta-consultar', component: require('./components/operaciones/gruposcuentascuenta/consultar.gruposcuentascuenta.vue') },
    { path: '/gruposcuentascuenta-administrar', component: require('./components/operaciones/gruposcuentascuenta/administrar.gruposcuentascuenta.vue') },
    { path: '/gruposinternos-consultar', component: require('./components/operaciones/gruposinternos/consultar.gruposinternos.vue') },
    { path: '/gruposinternos-administrar', component: require('./components/operaciones/gruposinternos/administrar.gruposinternos.vue') },
    { path: '/gruposinternosinterno-consultar', component: require('./components/operaciones/gruposinternosinterno/consultar.gruposinternosinterno.vue') },
    { path: '/gruposinternosinterno-administrar', component: require('./components/operaciones/gruposinternosinterno/administrar.gruposinternosinterno.vue') },
    { path: '/gruposlineas-consultar', component: require('./components/operaciones/gruposlineas/consultar.gruposlineas.vue') },
    { path: '/gruposlineas-administrar', component: require('./components/operaciones/gruposlineas/administrar.gruposlineas.vue') },
    { path: '/internos-consultar', component: require('./components/operaciones/internos/consultar.internos.vue') },
    { path: '/internos-administrar', component: require('./components/operaciones/internos/administrar.internos.vue') },
    { path: '/lineas-consultar', component: require('./components/operaciones/lineas/consultar.lineas.vue') },
    { path: '/lineas-administrar', component: require('./components/operaciones/lineas/administrar.lineas.vue') },
    { path: '/numeracion-consultar', component: require('./components/operaciones/numeracion/consultar.numeracion.vue') },
    { path: '/numeracion-administrar', component: require('./components/operaciones/numeracion/administrar.numeracion.vue') },
    { path: '/pais-consultar', component: require('./components/operaciones/pais/consultar.pais.vue') },
    { path: '/pais-administrar', component: require('./components/operaciones/pais/administrar.pais.vue') },
    { path: '/patrones-consultar', component: require('./components/operaciones/patrones/consultar.patrones.vue') },
    { path: '/patrones-administrar', component: require('./components/operaciones/patrones/administrar.patrones.vue') },
    { path: '/proveedor-consultar', component: require('./components/operaciones/proveedor/consultar.proveedor.vue') },
    { path: '/proveedor-administrar', component: require('./components/operaciones/proveedor/administrar.proveedor.vue') },
    { path: '/proveedorservicio-consultar', component: require('./components/operaciones/proveedorservicio/consultar.proveedorservicio.vue') },
    { path: '/proveedorservicio-administrar', component: require('./components/operaciones/proveedorservicio/administrar.proveedorservicio.vue') },
    { path: '/rolempresa-consultar', component: require('./components/operaciones/rolempresa/consultar.rolempresa.vue') },
    { path: '/rolempresa-administrar', component: require('./components/operaciones/rolempresa/administrar.rolempresa.vue') },
    { path: '/roles-consultar', component: require('./components/operaciones/roles/consultar.roles.vue') },
    { path: '/roles-administrar', component: require('./components/operaciones/roles/administrar.roles.vue') },
    { path: '/sericioareapais-consultar', component: require('./components/operaciones/sericioareapais/consultar.sericioareapais.vue') },
    { path: '/sericioareapais-administrar', component: require('./components/operaciones/sericioareapais/administrar.sericioareapais.vue') },
    { path: '/servicionumeracion-consultar', component: require('./components/operaciones/servicionumeracion/consultar.servicionumeracion.vue') },
    { path: '/servicionumeracion-administrar', component: require('./components/operaciones/servicionumeracion/administrar.servicionumeracion.vue') },
    { path: '/serviciopatrones-consultar', component: require('./components/operaciones/serviciopatrones/consultar.serviciopatrones.vue') },
    { path: '/serviciopatrones-administrar', component: require('./components/operaciones/serviciopatrones/administrar.serviciopatrones.vue') },
    { path: '/servicios-consultar', component: require('./components/operaciones/servicios/consultar.servicios.vue') },
    { path: '/servicios-administrar', component: require('./components/operaciones/servicios/administrar.servicios.vue') },
    { path: '/smdr-consultar', component: require('./components/operaciones/smdr/consultar.smdr.vue') },
    { path: '/smdr-administrar', component: require('./components/operaciones/smdr/administrar.smdr.vue') },
    { path: '/smdrorigen-consultar', component: require('./components/operaciones/smdrorigen/consultar.smdrorigen.vue') },
    { path: '/smdrorigen-administrar', component: require('./components/operaciones/smdrorigen/administrar.smdrorigen.vue') },
    { path: '/tarifa-consultar', component: require('./components/operaciones/tarifa/consultar.tarifa.vue') },
    { path: '/tarifa-administrar', component: require('./components/operaciones/tarifa/administrar.tarifa.vue') },
    { path: '/tarifatramos-consultar', component: require('./components/operaciones/tarifatramos/consultar.tarifatramos.vue') },
    { path: '/tarifatramos-administrar', component: require('./components/operaciones/tarifatramos/administrar.tarifatramos.vue') },
    { path: '/tipocomunicacion-consultar', component: require('./components/operaciones/tipocomunicacion/consultar.tipocomunicacion.vue') },
    { path: '/tipocomunicacion-administrar', component: require('./components/operaciones/tipocomunicacion/administrar.tipocomunicacion.vue') },
    { path: '/tipoproveedor-consultar', component: require('./components/operaciones/tipoproveedor/consultar.tipoproveedor.vue') },
    { path: '/tipoproveedor-administrar', component: require('./components/operaciones/tipoproveedor/administrar.tipoproveedor.vue') },
    { path: '/tramos-consultar', component: require('./components/operaciones/tramos/consultar.tramos.vue') },
    { path: '/tramos-administrar', component: require('./components/operaciones/tramos/administrar.tramos.vue') },
    { path: '/usuario-consultar', component: require('./components/operaciones/usuario/consultar.usuario.vue') },
    { path: '/usuario-administrar', component: require('./components/operaciones/usuario/administrar.usuario.vue') },
    { path: '/usuariocuenta-consultar', component: require('./components/operaciones/usuariocuenta/consultar.usuariocuenta.vue') },
    { path: '/usuariocuenta-administrar', component: require('./components/operaciones/usuariocuenta/administrar.usuariocuenta.vue') },
    { path: '/usuariodepto-consultar', component: require('./components/operaciones/usuariodepto/consultar.usuariodepto.vue') },
    { path: '/usuariodepto-administrar', component: require('./components/operaciones/usuariodepto/administrar.usuariodepto.vue') },
    { path: '/usuariointerno-consultar', component: require('./components/operaciones/usuariointerno/consultar.usuariointerno.vue') },
    { path: '/usuariointerno-administrar', component: require('./components/operaciones/usuariointerno/administrar.usuariointerno.vue') },
    { path: '/usuariorol-consultar', component: require('./components/operaciones/usuariorol/consultar.usuariorol.vue') },
    { path: '/usuariorol-administrar', component: require('./components/operaciones/usuariorol/administrar.usuariorol.vue') },
    { path: '/zona-consultar', component: require('./components/operaciones/zona/consultar.zona.vue') },
    { path: '/zona-administrar', component: require('./components/operaciones/zona/administrar.zona.vue') },
];

const router = new VueRouter({ mode: 'history', routes: routes })
new Vue({
    el: '#app-root',
    router,
    render: h => h(App),
    store,
    data: {
        auth: false
    },
    created() {
        if (localStorage.auth == "true") {
            this.$store.commit('login');
        }
    },
    methods: {
        loginLS() {
            localStorage.auth = this.auth;
        }
    }
});

