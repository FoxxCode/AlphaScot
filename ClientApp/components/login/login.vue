<template>
    <section>
        <v-content>
            <v-container fluid fill-height>
                <v-layout align-center justify-center>
                    <v-flex xs12 sm8 md4>
                        <v-card class="elevation-12">
                            <v-toolbar dark color="primary">
                                <v-flex xs1>
                                    <v-icon>account_balance</v-icon>
                                </v-flex>
                                <v-toolbar-title>Ingreso a Proyecto</v-toolbar-title>
                            </v-toolbar>
                            <v-card-text>
                                <v-form>
                                    <v-text-field v-model="login.idusuario" color="#1A237E" prepend-icon="person" name="login" label="Usuario" type="text"  :rules="[() => !!login.idusuario || 'Este Campo es requerido']"></v-text-field>
                                    <v-text-field v-model="login.password" color="#1A237E" id="password" prepend-icon="lock" name="password" label="Contraseña" type="password"  :rules="[() => !!login.password || 'Este Campo es requerido']"></v-text-field>
                                </v-form>
                            </v-card-text>
                            <v-card-actions>
                                <v-spacer></v-spacer>
                                <v-btn color="secondary" @click="ingresar">Ingresar</v-btn>
                                <v-btn color="error" @click="cancelar">Cancelar</v-btn>
                            </v-card-actions>
                        </v-card>
                    </v-flex>
                </v-layout>
            </v-container>
        </v-content>
    </section>
</template>
<script src="./login.ts"></script>
