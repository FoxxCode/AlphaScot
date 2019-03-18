<template>
	<v-card class="v-alert--no-icon" style="width: 40%; padding: 20px">
		<v-toolbar>
			<v-toolbar-title>Datos de UsuarioInterno</v-toolbar-title>
		</v-toolbar>
		<v-form ref="form" style="padding-top:20px">
			<v-card-text>
				<v-layout wrap>
					<v-flex sm12>
						<h4 class="mb-0">IDInternoUsuario:</h4>
						<v-text-field v-model="usuariointerno.idinternousuario" @input="usuariointerno.idinternousuario = $event.toUpperCase()" required readonly hint="Ingrese IDInternoUsuario"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">IDInterno:</h4>
						<v-text-field v-model="usuariointerno.idinterno" @input="usuariointerno.idinterno = $event.toUpperCase()" required clearable hint="Ingrese IDInterno"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">IDCentral:</h4>
						<v-text-field v-model="usuariointerno.idcentral" @input="usuariointerno.idcentral = $event.toUpperCase()" required clearable hint="Ingrese IDCentral"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">IDUsuario:</h4>
						<v-text-field v-model="usuariointerno.idusuario" @input="usuariointerno.idusuario = $event.toUpperCase()" required clearable hint="Ingrese IDUsuario"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">IDEmpresa:</h4>
						<v-text-field v-model="usuariointerno.idempresa" @input="usuariointerno.idempresa = $event.toUpperCase()" required clearable hint="Ingrese IDEmpresa"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">FechaRegistro:</h4>
						<v-text-field v-model="usuariointerno.fecharegistro" @input="usuariointerno.fecharegistro = $event.toUpperCase()" required clearable hint="Ingrese FechaRegistro"></v-text-field>
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

<script src="./administrar.usuariointerno.ts"></script>
