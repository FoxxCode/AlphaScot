<template>
	<v-card class="v-alert--no-icon" style="width: 40%; padding: 20px">
		<v-toolbar>
			<v-toolbar-title>Datos de ServicioNumeracion</v-toolbar-title>
		</v-toolbar>
		<v-form ref="form" style="padding-top:20px">
			<v-card-text>
				<v-layout wrap>
					<v-flex sm12>
						<h4 class="mb-0">IDRango:</h4>
						<v-text-field v-model="servicionumeracion.idrango" @input="servicionumeracion.idrango = $event.toUpperCase()" required readonly hint="Ingrese IDRango"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">IDServicio:</h4>
						<v-text-field v-model="servicionumeracion.idservicio" @input="servicionumeracion.idservicio = $event.toUpperCase()" required readonly hint="Ingrese IDServicio"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">IDCiudad:</h4>
						<v-text-field v-model="servicionumeracion.idciudad" @input="servicionumeracion.idciudad = $event.toUpperCase()" required clearable hint="Ingrese IDCiudad"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">IDPais:</h4>
						<v-text-field v-model="servicionumeracion.idpais" @input="servicionumeracion.idpais = $event.toUpperCase()" required clearable hint="Ingrese IDPais"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">Descripcion:</h4>
						<v-text-field v-model="servicionumeracion.descripcion" @input="servicionumeracion.descripcion = $event.toUpperCase()" required clearable hint="Ingrese Descripcion"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">Etiqueta:</h4>
						<v-text-field v-model="servicionumeracion.etiqueta" @input="servicionumeracion.etiqueta = $event.toUpperCase()" clearable hint="Ingrese Etiqueta"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">NumeroInicio:</h4>
						<v-text-field v-model="servicionumeracion.numeroinicio" @input="servicionumeracion.numeroinicio = $event.toUpperCase()" required clearable hint="Ingrese NumeroInicio"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">NumeroFinal:</h4>
						<v-text-field v-model="servicionumeracion.numerofinal" @input="servicionumeracion.numerofinal = $event.toUpperCase()" required clearable hint="Ingrese NumeroFinal"></v-text-field>
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

<script src="./administrar.servicionumeracion.ts"></script>
