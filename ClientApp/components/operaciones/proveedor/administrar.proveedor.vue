<template>
	<v-card class="v-alert--no-icon" style="width: 40%; padding: 20px">
		<v-toolbar>
			<v-toolbar-title>Datos de Proveedor</v-toolbar-title>
		</v-toolbar>
		<v-form ref="form" style="padding-top:20px">
			<v-card-text>
				<v-layout wrap>
					<v-flex sm12>
						<h4 class="mb-0">IDProveedor:</h4>
						<v-text-field v-model="proveedor.idproveedor" @input="proveedor.idproveedor = $event.toUpperCase()" required readonly hint="Ingrese IDProveedor"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">IDTipo:</h4>
						<v-text-field v-model="proveedor.idtipo" @input="proveedor.idtipo = $event.toUpperCase()" required clearable hint="Ingrese IDTipo"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">Etiqueta:</h4>
						<v-text-field v-model="proveedor.etiqueta" @input="proveedor.etiqueta = $event.toUpperCase()" clearable hint="Ingrese Etiqueta"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">IDCiudad:</h4>
						<v-text-field v-model="proveedor.idciudad" @input="proveedor.idciudad = $event.toUpperCase()" required clearable hint="Ingrese IDCiudad"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">IDPais:</h4>
						<v-text-field v-model="proveedor.idpais" @input="proveedor.idpais = $event.toUpperCase()" clearable hint="Ingrese IDPais"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">Descripcion:</h4>
						<v-text-field v-model="proveedor.descripcion" @input="proveedor.descripcion = $event.toUpperCase()" clearable hint="Ingrese Descripcion"></v-text-field>
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

<script src="./administrar.proveedor.ts"></script>
