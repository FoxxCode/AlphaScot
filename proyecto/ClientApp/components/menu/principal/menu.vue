<template>
    <v-list dense>
        <v-list-tile v-for="item in menuItems" :key="item.title" @click="" :to="item.path">
            <v-list-tile-action><v-icon v-text="item.icon"></v-icon></v-list-tile-action>
            <v-list-tile-title v-text="item.title"></v-list-tile-title>
        </v-list-tile>
        <v-list-group>
            <v-list-tile slot="activator" color="white" class="primary">
                <v-list-tile-action><v-icon color="white">style</v-icon></v-list-tile-action>
                <v-list-tile-title>Archivo</v-list-tile-title>
            </v-list-tile>
            <v-list-tile v-for="(param, i) in menuParametros" :key="param.title" @click="" :to="param.path">
                <v-list-tile-avatar>
                </v-list-tile-avatar>
                <v-list-tile-avatar>
                    <v-icon v-text="param.icon"></v-icon>
                </v-list-tile-avatar>
                <v-list-tile-content>
                    <v-list-tile-title v-text="param.title" />
                </v-list-tile-content>
            </v-list-tile>
        </v-list-group>
        <v-list-tile v-for="item in menuSalir" :key="item.title" @click="logout()" :to="item.path">
            <v-list-tile-action><v-icon v-text="item.icon"></v-icon></v-list-tile-action>
            <v-list-tile-title v-text="item.title"></v-list-tile-title>
        </v-list-tile>
    </v-list>
</template>

<script src="./menu.ts"></script>