<template>
	<v-card class="v-alert--no-icon" style="width: 40%; padding: 20px">
		<v-toolbar>
			<v-toolbar-title>Datos de Ciudad</v-toolbar-title>
		</v-toolbar>
		<v-form ref="form" style="padding-top:20px">
			<v-card-text>
				<v-layout wrap>
					<v-flex sm12>
						<h4 class="mb-0">IDCiudad:</h4>
						<v-text-field v-model="ciudad.idciudad" @input="ciudad.idciudad = $event.toUpperCase()" required readonly hint="Ingrese IDCiudad"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">IDPais:</h4>
						<v-text-field v-model="ciudad.idpais" @input="ciudad.idpais = $event.toUpperCase()" required readonly hint="Ingrese IDPais"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">Descripcion:</h4>
						<v-text-field v-model="ciudad.descripcion" @input="ciudad.descripcion = $event.toUpperCase()" clearable hint="Ingrese Descripcion"></v-text-field>
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

<script src="./administrar.ciudad.ts"></script>
