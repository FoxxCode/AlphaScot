<template>
    <v-app id="inspire" class='app-login'>
        <v-toolbar v-if="!$store.state.auth" class="primary" dark fixed clipped-left app>
            <v-toolbar-side-icon @click.stop="inicio()"><v-icon>account_balance</v-icon></v-toolbar-side-icon>
            <v-toolbar-title>Proyecto</v-toolbar-title>
            <v-spacer></v-spacer>
            <v-toolbar-items class="hidden-sm-and-down">
                <v-btn flat>Quienes Somos</v-btn>
                <v-btn flat>Nuestros Servicios</v-btn>
                <v-btn flat>Nuestros Clientes</v-btn>
                <v-btn flat @click="Login()">Ingresar al Sistema</v-btn>
            </v-toolbar-items>
        </v-toolbar>
        <v-navigation-drawer v-if="$store.state.auth" persistent clipped enable-resize-watcher v-model="drawer" app>
            <MenuComponentUsuario v-if="tipo_login() == '3'"></MenuComponentUsuario>
        </v-navigation-drawer>
        <v-toolbar v-if="$store.state.auth" dark fixed clipped-left app>
            <v-toolbar-side-icon @click.stop="drawer = !drawer"></v-toolbar-side-icon>
            <v-toolbar-title>Proyecto</v-toolbar-title>
            <v-spacer></v-spacer>
            <v-toolbar-items class="hidden-sm-and-down">
                <v-btn flat @click="logout()">Salir del Sistema</v-btn>
            </v-toolbar-items>
        </v-toolbar>
        <main class="body-background">
            <v-content>
                <v-container grid-list-xl>
                    <router-view></router-view>
                </v-container>
            </v-content>
        </main>
        <v-footer class="primary" app fixed>
            <span class="white--text">Alpha Systems &copy; 2018</span>
        </v-footer>
    </v-app>
</template>

<script src="./app.ts"></script>
<style>
    .router-link-exact-active {
        background: gray;
    }

    .navigation-drawer > .list .router-link-exact-active.list__tile--active > :first-child .icon {
        color: #fff
    }

    .navigation-drawer > .list .router-link-exact-active.list__tile--active .list__tile__title {
        color: #fff;
    }
</style>
