<template>
	<v-card class="v-alert--no-icon" style="width: 40%; padding: 20px">
		<v-toolbar>
			<v-toolbar-title>Datos de DireccionUsuario</v-toolbar-title>
		</v-toolbar>
		<v-form ref="form" style="padding-top:20px">
			<v-card-text>
				<v-layout wrap>
					<v-flex sm12>
						<h4 class="mb-0">IDDireccion:</h4>
						<v-text-field v-model="direccionusuario.iddireccion" @input="direccionusuario.iddireccion = $event.toUpperCase()" required readonly hint="Ingrese IDDireccion"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">IDUsuario:</h4>
						<v-text-field v-model="direccionusuario.idusuario" @input="direccionusuario.idusuario = $event.toUpperCase()" required readonly hint="Ingrese IDUsuario"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">IDZona:</h4>
						<v-text-field v-model="direccionusuario.idzona" @input="direccionusuario.idzona = $event.toUpperCase()" required clearable hint="Ingrese IDZona"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">IDCiudad:</h4>
						<v-text-field v-model="direccionusuario.idciudad" @input="direccionusuario.idciudad = $event.toUpperCase()" required clearable hint="Ingrese IDCiudad"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">IDPais:</h4>
						<v-text-field v-model="direccionusuario.idpais" @input="direccionusuario.idpais = $event.toUpperCase()" required clearable hint="Ingrese IDPais"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">Descripcion:</h4>
						<v-text-field v-model="direccionusuario.descripcion" @input="direccionusuario.descripcion = $event.toUpperCase()" clearable hint="Ingrese Descripcion"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">Numero:</h4>
						<v-text-field v-model="direccionusuario.numero" @input="direccionusuario.numero = $event.toUpperCase()" clearable hint="Ingrese Numero"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">PorDefecto:</h4>
						<v-text-field v-model="direccionusuario.pordefecto" @input="direccionusuario.pordefecto = $event.toUpperCase()" required clearable hint="Ingrese PorDefecto"></v-text-field>
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

<script src="./administrar.direccionusuario.ts"></script>
