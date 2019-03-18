<template>
	<v-card class="v-alert--no-icon" style="width: 40%; padding: 20px">
		<v-toolbar>
			<v-toolbar-title>Datos de DireccionEmpresa</v-toolbar-title>
		</v-toolbar>
		<v-form ref="form" style="padding-top:20px">
			<v-card-text>
				<v-layout wrap>
					<v-flex sm12>
						<h4 class="mb-0">IDDireccion:</h4>
						<v-text-field v-model="direccionempresa.iddireccion" @input="direccionempresa.iddireccion = $event.toUpperCase()" required readonly hint="Ingrese IDDireccion"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">IDEmpresa:</h4>
						<v-text-field v-model="direccionempresa.idempresa" @input="direccionempresa.idempresa = $event.toUpperCase()" required readonly hint="Ingrese IDEmpresa"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">IDZona:</h4>
						<v-text-field v-model="direccionempresa.idzona" @input="direccionempresa.idzona = $event.toUpperCase()" required clearable hint="Ingrese IDZona"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">IDCiudad:</h4>
						<v-text-field v-model="direccionempresa.idciudad" @input="direccionempresa.idciudad = $event.toUpperCase()" required clearable hint="Ingrese IDCiudad"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">IDPais:</h4>
						<v-text-field v-model="direccionempresa.idpais" @input="direccionempresa.idpais = $event.toUpperCase()" required clearable hint="Ingrese IDPais"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">Descripcion:</h4>
						<v-text-field v-model="direccionempresa.descripcion" @input="direccionempresa.descripcion = $event.toUpperCase()" clearable hint="Ingrese Descripcion"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">Numero:</h4>
						<v-text-field v-model="direccionempresa.numero" @input="direccionempresa.numero = $event.toUpperCase()" clearable hint="Ingrese Numero"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">PorDefecto:</h4>
						<v-text-field v-model="direccionempresa.pordefecto" @input="direccionempresa.pordefecto = $event.toUpperCase()" required clearable hint="Ingrese PorDefecto"></v-text-field>
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

<script src="./administrar.direccionempresa.ts"></script>
