<template>
	<v-card class="v-alert--no-icon" style="width: 40%; padding: 20px">
		<v-toolbar>
			<v-toolbar-title>Datos de Usuario</v-toolbar-title>
		</v-toolbar>
		<v-form ref="form" style="padding-top:20px">
			<v-card-text>
				<v-layout wrap>
					<v-flex sm12>
						<h4 class="mb-0">IDUsuario:</h4>
						<v-text-field v-model="usuario.idusuario" @input="usuario.idusuario = $event.toUpperCase()" required readonly hint="Ingrese IDUsuario"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">IDEmpresa:</h4>
						<v-text-field v-model="usuario.idempresa" @input="usuario.idempresa = $event.toUpperCase()" required readonly hint="Ingrese IDEmpresa"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">IDComunicacion:</h4>
						<v-text-field v-model="usuario.idcomunicacion" @input="usuario.idcomunicacion = $event.toUpperCase()" required clearable hint="Ingrese IDComunicacion"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">Descripcion:</h4>
						<v-text-field v-model="usuario.descripcion" @input="usuario.descripcion = $event.toUpperCase()" clearable hint="Ingrese Descripcion"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">Encargado:</h4>
						<v-text-field v-model="usuario.encargado" @input="usuario.encargado = $event.toUpperCase()" clearable hint="Ingrese Encargado"></v-text-field>
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

<script src="./administrar.usuario.ts"></script>
