<template>
	<v-card class="v-alert--no-icon" style="width: 50%; padding: 20px">
		<v-toolbar>
			<v-toolbar-title>Datos de Continente</v-toolbar-title>
		</v-toolbar>
		<v-form ref="form" style="padding-top:20px">
            <v-card-text>
                <v-layout wrap row>
                    <v-flex sm2>
                        <h4 class="mb-0">IDContinente:</h4>
                        <template v-if="operacion == 'Update'">
                            <v-text-field v-model="continente.idcontinente" @input="continente.idcontinente = $event.toUpperCase()" required readonly hint="Ingrese IDContinente"></v-text-field>
                        </template>
                        <template v-else>
                            <v-text-field v-model="continente.idcontinente" required clearable hint="Ingrese IDContinente"></v-text-field>
                        </template>
                    </v-flex>
                </v-layout>
                <v-layout wrap row>
                    <v-flex sm12>
                        <h4 class="mb-0">Descripcion:</h4>
                        <v-text-field v-model="continente.descripcion" @input="continente.descripcion = $event.toUpperCase()" required clearable hint="Ingrese Descripcion"></v-text-field>
                    </v-flex>
                </v-layout>
            </v-card-text>
		</v-form>
		<v-card-actions>
			<v-btn color="green" style="width: 50%" @click="Grabar">Grabar</v-btn>
			<v-btn color="red" style="width: 50%" @click="Cancelar">Cancelar</v-btn>
		</v-card-actions>
		<v-footer class="pa-3">
			{{ error }}
			<v-spacer></v-spacer>
			<div>&copy; {{ new Date().getFullYear() }}</div>
		</v-footer>
	</v-card>
</template>

<script src="./administrar.continente.ts"></script>
