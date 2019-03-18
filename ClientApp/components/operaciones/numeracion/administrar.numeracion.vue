<template>
	<v-card class="v-alert--no-icon" style="width: 40%; padding: 20px">
		<v-toolbar>
			<v-toolbar-title>Datos de Numeracion</v-toolbar-title>
		</v-toolbar>
		<v-form ref="form" style="padding-top:20px">
			<v-card-text>
				<v-layout wrap>
					<v-flex sm12>
						<h4 class="mb-0">IDRango:</h4>
						<v-text-field v-model="numeracion.idrango" @input="numeracion.idrango = $event.toUpperCase()" required readonly hint="Ingrese IDRango"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">Descripcion:</h4>
						<v-text-field v-model="numeracion.descripcion" @input="numeracion.descripcion = $event.toUpperCase()" required clearable hint="Ingrese Descripcion"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">Etiqueta:</h4>
						<v-text-field v-model="numeracion.etiqueta" @input="numeracion.etiqueta = $event.toUpperCase()" clearable hint="Ingrese Etiqueta"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">NumeroInicio:</h4>
						<v-text-field v-model="numeracion.numeroinicio" @input="numeracion.numeroinicio = $event.toUpperCase()" required clearable hint="Ingrese NumeroInicio"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">NumeroFinal:</h4>
						<v-text-field v-model="numeracion.numerofinal" @input="numeracion.numerofinal = $event.toUpperCase()" required clearable hint="Ingrese NumeroFinal"></v-text-field>
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

<script src="./administrar.numeracion.ts"></script>
