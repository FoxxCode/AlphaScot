<template>
	<v-card class="v-alert--no-icon" style="width: 40%; padding: 20px">
		<v-toolbar>
			<v-toolbar-title>Datos de Ciudades</v-toolbar-title>
		</v-toolbar>
		<v-form ref="form" style="padding-top:20px">
			<v-card-text>
                <v-layout wrap>
                    <v-flex sm12>
                        <h4 class="mb-0">Descripcion:</h4>
                        <v-text-field v-model="ciudades.descripcion" @input="ciudades.descripcion = $event.toUpperCase()" required clearable hint="Ingrese Descripcion"></v-text-field>
                    </v-flex>
                    <v-flex sm6>
                        <h4 class="mb-0">Seleccion Pais:</h4>
                        <v-autocomplete v-model="pais"
                                  :items="lstpaises"
                                  item-text="descripcion"
                                  item-value="idpais"
                                  label="Seleccione Pais"
                                  persistent-hint
                                  return-object
                                  single-line
                                  autocomplete
                                  color="#1A237E"></v-autocomplete>
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

<script src="./administrar.ciudades.ts"></script>
